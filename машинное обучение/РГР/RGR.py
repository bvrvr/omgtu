import streamlit as st
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.preprocessing import StandardScaler
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split
from sklearn.metrics import mean_squared_error
import pickle
from catboost import CatBoostClassifier

# Страница 1: Информация о студенте
def page_1():
    st.title("Информация о студенте")

    col1, col2 = st.columns([2, 1])

    with col1:
        st.subheader("ФИО: Буряк Варвара Николаевна")
        st.subheader("Номер учебной группы: ФИТ-232")
        st.subheader("Тема РГР: Прогнозирование наличия сердечного заболевания")

    with col2:
        st.image("photo.jpg", caption="Фотография", width=200)

# Страница 2: Информация о наборе данных
def page_2():
    st.title("Информация о наборе данных")

    st.header("Описание предметной области датасета")
    st.write("""
        Данный датасет содержит информацию о различных характеристиках пациентов,
        такие как возраст, пол, уровень холестерина и т.д., которые влияют на вероятность наличия проблем с сердцем.
    """)

    st.header("Признаки")
    st.write("""
        - `age` — возраст
        - `sex` — пол (1 = мужчина, 0 = женщина)
        - `cp` — тип боли в груди:

            1.   типичная стенокардия
            2.   атипичная стенокардия
            3.   неангинальная боль
            4.   бессимптомная

        - `trestbps` — артериальное давление в состоянии покоя (в мм рт. ст. при поступлении в больницу)
        - `chol` — уровень холестерина в сыворотке крови (мг/дл)
        - `fbs` — уровень сахара в крови натощак > 120 мг/дл (1 = да, 0 = нет)
        - `restecg` — результаты электрокардиограммы в состоянии покоя:

            0.   нормальные (отсутствие патологий)
            1.   наличие аномалий волны ST-T (изменения, указывающие на ишемию)
            2.   вероятная или подтвержденная гипертрофия левого желудочка по критериям Эстеса

        - `thalach` — максимальная достигнутая частота сердечных сокращений (чем выше, тем лучше сердце реагирует на нагрузку)
        - `exang` — индуцированная нагрузкой стенокардия (1 = да, 0 = нет)
        - `oldpeak` — депрессия сегмента ST, вызванная физической нагрузкой по сравнению с состоянием покоя (чем больше значение, тем хуже кровоснабжение сердца)
        - `slope` — наклон пикового ST-сегмента при нагрузке:

            1.   восходящий (нормальная реакция сердца, низкий риск ишемии)
            2.   плоский (возможные проблемы с кровоснабжением)
            3.   нисходящий (высокий риск ишемической болезни сердца)

        - `ca` — количество крупных сосудов (0-3), окрашенных при флюороскопии (0 = норма)
        - `thal` — кротовок в сердечной мышце:

            1.   3 = нормальный
            2.   6 = фиксированный дефект (постоянное нарушение кровотока, возможно из-за рубцевания или инфаркта)
            3.   7 = обратимый дефект (уменьшенный кровоток во время нагрузки, но нормальный в покое, что может указывать на ишемию)

        - `num` — диагноз ишемической болезни сердца:

            0.   сужение диаметра < 50% (норма или незначительная ишемия)
            1.   сужение диаметра > 50% (значительное нарушение кровотока, требует лечения)
    """)

    st.header("Предобработка данных")
    st.write("""
        Для предобработки данных использовалась стандартная нормализация признаков и обработка пропущенных значений.
    """)

# Страница 3: Визуализации зависимостей
def page_3():
    st.title("Визуализации зависимостей в наборе данных")
        
    df = pd.read_csv('heart_disease.csv')
    
    st.write("Описание данных:")
    st.write(df.describe())
    
    # 1. Гистограмма распределения возраста пациентов
    fig, ax = plt.subplots(figsize=(6, 4))
    sns.histplot(df['age'], kde=True, ax=ax)
    ax.set_title('Распределение возраста пациентов')
    st.pyplot(fig)

    # 2. Тепловая карта корреляций
    fig, ax = plt.subplots(figsize=(12, 8))
    correlation_matrix = df.corr()
    sns.heatmap(correlation_matrix, annot=True, cmap='coolwarm', ax=ax)
    ax.set_title('Корреляционная матрица')
    st.pyplot(fig)

    # 3. Зависимость частоты сердечных сокращений от возраста пациента
    fig, ax = plt.subplots(figsize=(6, 4))
    sns.scatterplot(x=df['age'], y=df['thalach'], ax=ax)
    ax.set_title('Зависимость частоты сердечных сокращений от возраста пациента')
    st.pyplot(fig)

    # 4. Зависимость уровня холестерина от пола пациента
    fig, ax = plt.subplots(figsize=(6, 4))
    sns.boxplot(x=df['sex'], y=df['chol'], ax=ax)
    ax.set_title('Зависимость уровня холестерина от пола пациента')
    st.pyplot(fig)


models = {}
model_files = [
    'decision_tree_model.pkl',
    'xgb_model.pkl',
    'catboost_model.cbm',
    'random_forest_model.pkl',
    'stacked_model.pkl',
    'mlp_model.pkl'
]

for model_file in model_files:
    try:
        if model_file.endswith('.cbm'):
            models[model_file] = CatBoostClassifier()
            models[model_file].load_model(f'{model_file}')
        else:
            with open(f'{model_file}', 'rb') as f:
                models[model_file] = pickle.load(f)
    except Exception as e:
        st.write(f'Ошибка при загрузке модели {model_file}: {e}')
        print(e)

encoding_dict = {
    'sex': {0: 'Female', 1: 'Male'},
    'cp': {1: 'Typical Angina', 2: 'Atypical Angina', 3: 'Non-anginal Pain', 4: 'Asymptomatic'},
    'fbs': {0: 'No', 1: 'Yes'},
    'restecg': {0: 'Normal', 1: 'Having ST-T wave abnormality', 2: 'Showing probable or definite left ventricular hypertrophy'},
    'exang': {0: 'No', 1: 'Yes'},
    'slope': {1: 'Up', 2: 'Flat', 3: 'Down'},
    'ca': {0: '0', 1: '1', 2: '2', 3: '3'},
    'thal': {3: 'Normal', 6: 'Fixed Defect', 7: 'Reversible Defect'}
}

# Страница 4: Интерфейс для предсказания
def page_4():
    st.title("Предсказание наличия сердечного заболевания")

    st.write("Введите значения для предсказания:")

    # Ввод числовых значений
    col1, col2, col3 = st.columns(3)

    with col1:
        age = st.number_input('Возраст', min_value=0, value=60)
        sex = st.selectbox('Пол', ['Female', 'Male'])
        cp = st.selectbox('Тип боли в груди', list(encoding_dict['cp'].values()))
        trestbps = st.number_input('Систолическое АД (мм рт. ст.)', min_value=0, value=140)

    with col2:
        chol = st.number_input('Уровень холестерина (мг/дл)', min_value=0, value=250)
        fbs = st.selectbox('Сахар натощак >120 мг/дл?', ['Yes', 'No'])
        restecg = st.selectbox('ЭКГ в покое', list(encoding_dict['restecg'].values()))
        thalach = st.number_input('Максимальный пульс', min_value=0, value=150)

    with col3:
        exang = st.selectbox('Нагрузочная стенокардия?', ['Yes', 'No'])
        oldpeak = st.number_input('Oldpeak (депрессия ST)', min_value=0.0, value=2.0)
        slope = st.selectbox('Склон ST сегмента', list(encoding_dict['slope'].values()))
        ca = st.selectbox('Количество сосудов (0-3)', list(encoding_dict['ca'].values()))
        thal = st.selectbox('Тип Thal', list(encoding_dict['thal'].values()))

    # Проверки с предупреждениями
    if age < 18:
        st.warning("Возраст пациента ниже 18 лет — модель обучена на взрослых пациентах, предсказание может быть неточным.")
    if chol < 125 or chol > 400:
        st.warning("Уровень холестерина вне типичных границ (125-400 мг/дл). Проверьте правильность ввода.")
    if thalach < 60 or thalach > 220:
        st.warning("Максимальный пульс вне физиологических норм (60-220). Возможно, ошибка в данных.")
    if oldpeak > 6:
        st.warning("Значение Oldpeak очень высокое, что может указывать на серьёзную проблему или ошибку в данных.")

    # Преобразование строк в числовые значения
    reverse_encoding = {feature: {v: k for k, v in encoding_dict[feature].items()} for feature in encoding_dict}

    input_data = [
        age,
        1 if sex == 'Male' else 0,
        reverse_encoding['cp'][cp],
        trestbps,
        chol,
        1 if fbs == 'Yes' else 0,
        reverse_encoding['restecg'][restecg],
        thalach,
        1 if exang == 'Yes' else 0,
        oldpeak,
        reverse_encoding['slope'][slope],
        int(ca),
        reverse_encoding['thal'][thal]
    ]

    # Преобразуем в numpy массив
    column_names = ['age', 'sex', 'cp', 'trestbps', 'chol', 'fbs',
                    'restecg', 'thalach', 'exang', 'oldpeak', 'slope',
                    'ca', 'thal']
    encoded_input = pd.DataFrame([input_data], columns=column_names)

    if st.button('Предсказать наличие заболевания'):
        predictions = {}
        for model_name, model in models.items():
            try:
                prediction = model.predict(encoded_input)
                predictions[model_name] = prediction[0]
            except Exception as e:
                predictions[model_name] = f"Ошибка: {e}"

        st.write("Предсказания:")
        for model_name, prediction in predictions.items():
            st.write(f"{model_name}: {prediction}")

def main():
    st.sidebar.title("Навигация")
    page = st.sidebar.radio("Перейти к странице", ["О студенте", 
                                                 "О наборе данных",
                                                 "Визуализации зависимостей",
                                                 "Получить предсказание"])

    if page == "О студенте":
        page_1()
    elif page == "О наборе данных":
        page_2()
    elif page == "Визуализации зависимостей":
        page_3()
    elif page == "Получить предсказание":
         page_4()

if __name__ == "__main__":
    main()
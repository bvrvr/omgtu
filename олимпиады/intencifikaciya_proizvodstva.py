from datetime import date

day1, month1, year1 = map(int, input('Введите дату начала периода: ').split('.'))
day2, month2, year2 = map(int, input('Введите дату окончания периода: ').split('.'))
products = int(input('Введите начальный выпуск продукции: '))

first_date = date(year1, month1, day1)
second_date = date(year2, month2, day2)

delta = second_date - first_date
days = int(delta.days)
first_day_products = products

for i in range(1, days + 1):
    products += first_day_products + i

print(products)
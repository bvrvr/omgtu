n = int(input('Введите количество фирм:'))

firm = 0
min_price = float('inf')

for i in range(n):
    x1, y1, z1, x2, y2, z2, c1, c2 = map(float, input('Введите данные:').split())
    
    v1 = (x1 * y1 * z1)
    s1 = 2*x1*y1 + 2*y1*z1 + 2*z1*x1

    v2 = (x2 * y2 * z2)
    s2 = 2*x2*y2 + 2*y2*z2 + 2*z2*x2

    milk_price = (c2*s1 - c1*s2) / (v2*s1 - v1*s2)

    if milk_price < min_price:
        min_price = milk_price
        firm = i + 1

min_price = round(min_price * 1000, 2)
print(firm, min_price)
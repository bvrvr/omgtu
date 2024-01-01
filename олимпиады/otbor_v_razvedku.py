def f(x):
    if x < 3:
        return 0
    if x == 3:
        return 1

    if x not in cash:
        cash[x] = f(x // 2) + f(x - x // 2)

    return cash[x]

cash = {}

def main():
    a = int(input())
    print(f(a))

main()
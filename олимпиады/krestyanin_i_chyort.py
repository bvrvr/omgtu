def count_combinations(MaxN):
    combinations = 0

    for N in range(1, MaxN + 1):
        for Z in range(1, 31):
            K = (2 ** Z - 1) * N
            if K <= MaxN:
                combinations += 1
            else:
                break

    return combinations

MaxN = int(input())

result = count_combinations(MaxN)
print(result)
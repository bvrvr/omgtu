X, Y, L, C1, C2, C3, C4, C5, C6 = map(int, input('Введите входные данные:').split())

P = 2*(X+Y)

if L <= P:
    S1 = L*(C2+C3) + (P-L)*(C4+C5)
    S2 = X*C1 + (L-X)*(C2+C3) + (P-L)*(C4+C5)
    S3 = Y*C1 + (L-Y)*(C2+C3) + (P-L)*(C4+C5)
    S = min(S1, S2, S3)

if L > P:
    S1 = L*C2 + P*C3 + (L-P)*C6
    S2 = X*C1 + (L-X)*C2 + (P-X)*C3 + (L-P)*C6
    S3 = Y*C1 + (L-Y)*C2 + (P-Y)*C3 + (L-P)*C6
    S = min(S1, S2, S3)

print(S)
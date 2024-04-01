graph = [(1, 2, 15), (1, 5, 14), (1, 4, 23), (2, 3, 19), (2, 4, 16), (2, 5, 15), (3, 5 ,14), (3, 6, 26), (4, 5, 25), 
         (4, 7, 23), (4, 8, 20), (5, 6, 24), (5, 8, 27), (5, 9, 18), (7, 8, 14), (8, 9, 18)]

vertex = 9

I = []
U = []
W = []
weight = 0

vrt = int(input("Введите вершину, с которой хотите начать работу алгоритма: "))

for r in graph:
     if r[0] == vrt or r[1] == vrt:
        I.append(r)

weight += min(r[2] for r in I)
W.append(min(I, key = lambda x: x[2]))
U.append(W[0][0])
U.append(W[0][1])
W.clear()
I.remove(min(I, key = lambda x: x[2]))

while len(U) < vertex:
    for edge in graph:
        if edge[0] in U and edge[1] not in U and edge not in I:
            I.append(edge)
        if edge[0] not in U and edge[1] in U and edge not in I:
            I.append(edge)
    W.append(min(I, key=lambda x: x[2]))
    for edge in W:
        if edge[0] in U and edge[1] not in U:
            weight += edge[2]
            U.append(edge[1])
            break
        if edge[0] not in U and edge[1] in U:
            weight += edge[2]
            U.append(edge[0])
            break
    W.clear()
    I.remove(min(I, key=lambda x: x[2]))

print(weight)
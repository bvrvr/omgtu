graph = set()
vertex = int(input("Введите количество вершин: "))
edge = int(input("Введите количество рёбер: "))
count = 0
while count != edge:
    entered_set = input("Введите две вершины и вес ребра, которое они образуют (через запятую): ").split(", ")
    num_set = tuple(int(i) for i in entered_set)
    graph.add(num_set)
    count += 1

def sort_elements(el):
    return el[2], el[0], el[1]
    
gra = sorted(graph, key = sort_elements)

U = []
weight = 0

U.append(gra[0][0])
U.append(gra[0][1])
weight += gra[0][2]

for r in gra:
    if len(U) == vertex:
        break
    for r in gra:
        if r[0] in U and r[1] not in U:
            U.append(r[1])
            weight += r[2]
            break
        if r[0] not in U and r[1] in U:
            U.append(r[0])
            weight += r[2]
            break

print(weight)

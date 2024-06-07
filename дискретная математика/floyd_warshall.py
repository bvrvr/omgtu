nV = 6

INF = 999

def floyd_warshall(G):
    distance = list(map(lambda i: list(map(lambda j: j, i)), G))

    for k in range(nV):
        for i in range(nV):
            for j in range(nV):
                distance[i][j] = min(distance[i][j], distance[i][k] + distance[k][j])
    print_solution(distance)

def print_solution(distance):
    for i in range(nV):
        for j in range(nV):
            if(distance[i][j] == INF):
                print("INF", end=" ")
            else:
                print(distance[i][j], end="  ")
        print(" ")


G = [[0, 10, 18, 8, INF, INF],
[10, 0, 16, 9, 21, INF],
[INF, 16, 0, INF, INF, 15],
[7, 9, INF, 0, INF, 12],
[INF, INF, INF, INF, 0, 23],
[INF, INF, 15, INF, 23, 0]]
floyd_warshall(G)
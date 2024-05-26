import heapq

graph = {
    'C': {'K': 26, 'P': 19, 'R': 86},
    'K': {'D': 16, 'L': 66},
    'P': {'C': 19, 'N': 4, 'V': 51},
    'R': {'J': 31, 'B': 22},
    'D': {'V': 21, 'K': 16},
    'L': {'M': 24, 'A': 13, 'J': 43, 'K': 66},
    'N': {'M': 21, 'P': 4},
    'V': {'M': 34, 'J': 9, 'D': 21, 'P': 51},
    'J': {'B': 44, 'R': 31, 'L': 43, 'V': 9},
    'B': {'A': 25, 'R': 22, 'J': 44},
    'M': {'L': 24, 'V': 34, 'N': 21},
    'A': {'L': 13, 'B': 25}
}

def validate_graph(graph):
    for node, edges in graph.items():
        for neighbor, distance in edges.items():
            if not isinstance(distance, (int, float)) or distance <= 0:
                print(f"Ошибка: некорректное расстояние от {node} до {neighbor}")
                return False
    return True

def dijkstra(graph, start, end):
    distances = {vertex: float('infinity') for vertex in graph}
    distances[start] = 0

    priority_queue = [(0, start)]
    
    while priority_queue:
        current_distance, current_vertex = heapq.heappop(priority_queue)

        if current_distance > distances[current_vertex]:
            continue

        for neighbor, weight in graph[current_vertex].items():
            if neighbor not in distances:
                print(f"Ошибка: Вершина {neighbor} не найдена в графе.")
                return -1

            distance = current_distance + weight

            if distance < distances[neighbor]:
                distances[neighbor] = distance
                heapq.heappush(priority_queue, (distance, neighbor))

    return distances[end] if distances[end] != float('infinity') else -1

if validate_graph(graph):
    start = 'C'
    end = 'B'
    shortest_distance = dijkstra(graph, start, end)
    if shortest_distance != -1:
        print(f"Самый короткий путь из {start} в {end} составляет {shortest_distance} километров.")
    else:
        print(f"Невозможно добраться из {start} в {end}.")
else:
    print("Граф содержит ошибки.")
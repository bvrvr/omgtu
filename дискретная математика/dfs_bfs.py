graph = {1: [2, 4], 2: [1, 5], 3: [4, 5], 4: [1, 3], 5: [2, 3], 6: [7], 7: [6, 8], 8: [7]}

#поиск в глубину

def dfs(graph, start, visited=None):
    if visited is None:
        visited = set()
    visited.add(start)
    print(start, end=' ')
    for neighbor in graph[start]:
        if neighbor not in visited:
            dfs(graph, neighbor, visited)

def explore_all(graph):
    visited = set()
    for vertex in graph:
        if vertex not in visited:
            dfs(graph, vertex, visited)

explore_all(graph)

print()

#поиск в ширину

def bfs(graph, start):
    visited = set()
    queue = [start]
    visited.add(start)

    while queue:
        node = queue.pop(0)
        print(node, end=' ')

        for neighbor in graph[node]:
            if neighbor not in visited:
                queue.append(neighbor)
                visited.add(neighbor)

    for vertex in graph:
        if vertex not in visited:
            queue.append(vertex)
            visited.add(vertex)
            while queue:
                node = queue.pop(0)
                print(node, end=' ')

                for neighbor in graph[node]:
                    if neighbor not in visited:
                        queue.append(neighbor)
                        visited.add(neighbor)

bfs(graph, 1)
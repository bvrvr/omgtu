from collections import deque

def bfs(grid, start, goal):
    rows, cols = len(grid), len(grid[0])
    
    directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]
    
    queue = deque([start])
    
    distances = [[-1] * cols for _ in range(rows)]
    distances[start[0]][start[1]] = 0
    
    while queue:
        x, y = queue.popleft()
        
        if (x, y) == goal:
            return distances[x][y]
        
        for dx, dy in directions:
            nx, ny = x + dx, y + dy
            
            if 0 <= nx < rows and 0 <= ny < cols and grid[nx][ny] == 0 and distances[nx][ny] == -1:
                distances[nx][ny] = distances[x][y] + 1
                queue.append((nx, ny))
    
    return -1

grid = [
    [0, 1, 0, 0, 0],
    [0, 1, 0, 1, 0],
    [0, 0, 0, 1, 0],
    [0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0]
]
start = (0, 0)
goal = (4, 4)

distance = bfs(grid, start, goal)
print(f"Кратчайшее расстояние: {distance}")
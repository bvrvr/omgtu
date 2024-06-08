for u in [f"{i:02}" for i in range(1, 21)]:
    with open(f"OLYMP/Cube/input_s1_{u}.txt") as file:
        lines = file.readlines()

    expected_output = open(f"OLYMP/Cube/output_s1_{u}.txt").readline().strip()

    n, m = map(int, lines[0].strip().split())
    xPos, yPos, zPos = map(int, lines[1].strip().split())

    for i in range(2, 2 + m):
        axis, cord, dir = lines[i].strip().split()
        cord = int(cord)
        dir = int(dir)

        if axis == "X" and xPos == cord:
            if dir > 0:
                yPos, zPos = zPos, n + 1 - yPos
            else:
                yPos, zPos = n + 1 - zPos, yPos
        elif axis == "Y" and yPos == cord:
            if dir > 0:
                xPos, zPos = zPos, n + 1 - xPos
            else:
                xPos, zPos = n + 1 - zPos, xPos
        elif axis == "Z" and zPos == cord:
            if dir > 0:
                xPos, yPos = yPos, n + 1 - xPos
            else:
                xPos, yPos = n + 1 - yPos, xPos

    result = f"{xPos} {yPos} {zPos}"
    print(result)
    print("True" if result == expected_output else "False")

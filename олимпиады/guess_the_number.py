def focus(num, operation, x):
    operator, operand = operation.split()
    if operand == "x":
        operand = x
    else:
        operand = int(operand)
        
    if operator == "+":
        return num + operand
    elif operator == "-":
        return num - operand
    elif operator == "*":
        return num * operand
    elif operator == "/":
        return num / operand

with open("input_s1_01.txt") as file:
    lines = file.readlines()

target_value = int(lines[-1])

for x in range(-100, 101):
    result = x
    for i in range(1, len(lines) - 1):
        result = focus(result, lines[i].strip(), x)
    if result == target_value:
        print(x)
        break

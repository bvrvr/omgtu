def add_person(num, name):
    Persons[num] = name

def find_workers(manager, records):
    workers = set()
    for index in range(0, len(records) - 1, 2):
        if records[index][0] == manager:
            workers.add(records[index + 1][0])
    return workers

Persons = {}
with open("input_s1_15.txt") as file:
    lines = file.readlines()

IDs = set(line[:4] for line in lines[:-2])

Pers = [[line[:4], line[5:].strip()] for line in lines[:-2]]

for id in IDs:
    add_person(id, 'Unknown Name')

for id in IDs:
    for record in Pers:
        if id == record[0] and record[1]:
            add_person(id, record[1])

manager = lines[-1].strip()
if not manager.isdigit():
    for record in Pers:
        if record[1] == manager:
            manager = record[0]
            break

manager_workers = find_workers(manager, Pers)

new_workers = set()
while True:
    previous_length = len(manager_workers)
    for worker in manager_workers:
        new_workers.update(find_workers(worker, Pers))
    manager_workers.update(new_workers)
    if len(manager_workers) == previous_length:
        break

if not manager_workers:
    print("NO")
else:
    for worker in sorted(manager_workers):
        print(worker, Persons[worker])

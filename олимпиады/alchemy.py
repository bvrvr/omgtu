import re

with open('input9.txt') as file:
    lines = [line.strip() for line in file.readlines()]

potion = {i + 1: lines[i] for i in range(len(lines))}

def replace_key(match):
    return potion[int(match.group())]

for key in potion.keys():
    potion[key] = re.sub(r'\b\d+\b', replace_key, potion[key])
    
    if 'WATER ' in potion[key]:
        potion[key] = 'WT' + potion[key].replace('WATER', '') + ' TW'
    if 'DUST ' in potion[key]:
        potion[key] = 'DT' + potion[key].replace('DUST', '') + ' TD'
    if 'MIX ' in potion[key]:
        potion[key] = 'MX' + potion[key].replace('MIX', '') + ' XM'
    if 'FIRE ' in potion[key]:
        potion[key] = 'FR' + potion[key].replace('FIRE', '') + ' RF'

print(potion[len(lines)].replace(' ', ''))

def create_palindrome(word):
    palindrome = ""
    length = len(word)
    middle_index = length // 2
    
    if length % 2 == 0:
        palindrome += word[middle_index]
        for i in range(1, middle_index + 1):
            palindrome += word[middle_index - i]
            if i < middle_index:
                palindrome += word[middle_index + i]
    else:
        palindrome += word[middle_index]
        for i in range(1, middle_index + 1):
            palindrome += word[middle_index - i]
            if middle_index + i < length:
                palindrome += word[middle_index + i]
    
    return palindrome

with open('input_s1_01.txt') as input_file:
    input_string = input_file.readline().strip()

words = input_string.split()

circular_list = []
middle_index = len(words) // 2

if len(words) % 2 == 0:
    circular_list.append(words[middle_index])
    for i in range(1, middle_index + 1):
        circular_list.append(words[middle_index - i])
        if middle_index + i < len(words):
            circular_list.append(words[middle_index + i])
else:
    circular_list.append(words[middle_index])
    for i in range(1, middle_index + 1):
        circular_list.append(words[middle_index - i])
        if middle_index + i < len(words):
            circular_list.append(words[middle_index + i])

palindrome_list = [create_palindrome(word) for word in circular_list]

output_string = " ".join(palindrome_list)

print(output_string)

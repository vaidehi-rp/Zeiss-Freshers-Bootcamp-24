def string_filter(input_list, predicate):
    result = [item for item in input_list if predicate(item)]
    return result

def print_screen(output_list):
    for item in output_list:
        print(item)

def starts_with_predicate(char):
    return lambda string: string[0].lower() == char.lower()

def ends_with_predicate(character):
    return lambda string: string[-1].lower() == character.lower()

string_list = ["Car", "Zeiss", "Arrow", "Air", "Bow"]

filtered_list_starts_with = string_filter(string_list, starts_with_predicate("a"))

print("Strings starting with 'A': ")
print_screen(filtered_list_starts_with)

filtered_list_ends_with = string_filter(string_list, ends_with_predicate("r"))

print("Strings ending with 'R': ")
print_screen(filtered_list_ends_with)

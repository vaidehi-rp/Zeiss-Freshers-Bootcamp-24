class ConsoleDisplayController:
    content = ''

    def set_content(self, array):
        self.content = array

    def display(self):
        for item in self.content:
            print(item)


class StartsWithStrategy:
    starts_with = ''

    def set_starts_with(self, key):
        self.starts_with = key

    def invoke(self, item):
        return item[0].lower() == self.starts_with.lower()


class StringListFilterController:
    return_arr = []
    strategy_obj = StartsWithStrategy()

    def set_list(self, str_list):
        self.str_list = str_list

    def filter(self):
        for string in self.str_list:
            if self.strategy_obj.invoke(string):
                self.return_arr.append(string)

    def get_list(self):
        return self.return_arr


def main():
    string_list = ["Arrow", "Bow", "Wood", "Air"]
    example_object = ConsoleDisplayController()
    filter_object = StringListFilterController()

    filter_object.set_list(string_list)
    filter_object.strategy_obj.set_starts_with('a')
    filter_object.filter()

    example_object.set_content(filter_object.get_list())
    example_object.display()


if __name__ == "__main__":
    main()

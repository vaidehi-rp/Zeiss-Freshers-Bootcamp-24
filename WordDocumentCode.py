from abc import ABC, abstractmethod

class WordDocument:
    def __init__(self, document_parts=None):
        self.document_parts = document_parts or []

    def add_document_part(self, document_part):
        self.document_parts.append(document_part)

    def open_document(self):
        for part in self.document_parts:
            part.paint()

    def save_document(self):
        for part in self.document_parts:
            part.save()
            
class DocumentPart(ABC):
    name = ''
    position = ''

    @abstractmethod
    def paint(self):
        pass

    @abstractmethod
    def save(self):
        pass

class Header(DocumentPart):
    def __init__(self, title):
        self.title = title

    def paint(self):
        print("Paint Header", self.title)

    def save(self):
        print("Save Header")

class Footer(DocumentPart):
    def __init__(self, text):
        self.text = text

    def paint(self):
        print("Paint Footer", self.text)

    def save(self):
        print("Save Footer")

class Hyperlink(DocumentPart):
    def __init__(self, url, text):
        self.url = url
        self.text = text

    def paint(self):
        print("Paint Hyperlink", self.url, self.text)

    def save(self):
        print("Save Hyperlink")

class Paragraph(DocumentPart):
    def __init__(self, content):
        self.content = content

    def paint(self):
        print("Paint Paragraph", self.content)

    def save(self):
        print("Save Paragraph")



header_obj = Header("Hello World")
hyperlink_obj = Hyperlink("www.Zeiss.com", "CZ")
footer_obj = Footer("Footer1")
paragraph_obj = Paragraph("Paragraph1")

document_part_list = [header_obj, footer_obj, hyperlink_obj, paragraph_obj]

word_doc = WordDocument(document_part_list)

word_doc.open_document()
print()
word_doc.save_document()

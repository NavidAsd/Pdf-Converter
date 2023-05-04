from pdf2docx import Converter ,parse

pdffile =r'E:\C#\Web\Core\PdfConverter\front\file converter\styles\my\test2.pdf'
wordfile = 'doctest.rtf'

cv =Converter (pdffile)
a = cv.convert(wordfile,start=0,end=None)
cv.close()
print(a)
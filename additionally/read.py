#генерация штрих кода
#import barcode
#from barcode.writer import ImageWriter

#ean = barcode.get('ean13', '345678910212')
#ean.get_fullcode()
#filename = ean.save('img/ean13_svg3')
#filename = ean.save('ean13', options)

#ean = barcode.get('ean13', '345678910212', writer=ImageWriter())
#filename = ean.save('img/ean13_png3')

#чтение штрих кода
from pyzbar.pyzbar import decode
from PIL import Image

image_barcode = Image.open('C:\img')
decoded = decode(image_barcode)
f = open('C:\result.txt','w')  # открытие в режиме записи
f.write(decoded[0].data.decode("utf-8"))
f.close()
print(decoded[0].data.decode("utf-8"))
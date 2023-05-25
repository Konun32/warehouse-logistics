# Разработка системы технического зрения логистики склада

## Файлы проекта
Папка __Kursovay__ - это проект unity.

В папке __additionally__ располагаются дополнительные файлы. Рассмотрим их более подробно:

- __img__ - в данную папку сохраняются изображения, сделанные камерой.
- __read.py__ - файл с кодом обработки штрих кода на языке python.
- __result.txt__ - файл, в который сохраняется значене штрих кода, снятого с изображения.

Перед началом работы необходимо настроить пути в файлах:
- __BarcodeScanner.cs__ 
```
string scriptPath = "Путь к read.py";
string imagePath = "Путь для сохранения фотографии/img/image.png";
string resultFilePath = "Путь к result.txt";
```
- __read.me__
```
image_barcode = Image.open("Путь до сохранённого изображения")
f = open('Путь до файла result.txt','w')
```

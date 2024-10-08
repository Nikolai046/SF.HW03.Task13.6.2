# Word Frequency Analyzer
## Описание проекта
Word Frequency Analyzer - это консольное приложение на C#, разработанное для анализа текстовых файлов и определения частоты встречаемости слов. Программа игнорирует общеупотребительные слова (такие как предлоги, союзы и междометия) и выводит топ-10 наиболее часто встречающихся слов в тексте.
## Основные функции
- Чтение текстового файла для анализа
- Исключение общеупотребительных слов из анализа
- Подсчет частоты встречаемости каждого слова
- Вывод топ-10 наиболее часто встречающихся слов
## Требования
- .NET 6.0 или выше
- Файл с текстом для анализа (Text1.txt)
- Файл со списком исключаемых слов (ExcludedWords.txt)
## Структура проекта
- Program.cs: Основной файл программы, содержащий логику анализа текста.
- Text1.txt: Файл с текстом для анализа.
- ExcludedWords.txt: Файл со списком исключаемых слов.
## Использование
- Поместите текст для анализа в файл Text1.txt в корневой директории проекта.
- Убедитесь, что файл ExcludedWords.txt содержит список слов для исключения из анализа.
- Запустите программу.
- Программа выведет топ-10 наиболее часто встречающихся слов и их частоту.
- Настройка списка исключаемых слов
- Файл ExcludedWords.txt содержит список слов, которые будут исключены из анализа. Вы можете изменить этот список, добавляя или удаляя слова. Каждое слово должно быть на новой строке. Строки, начинающиеся с ###, считаются комментариями и игнорируются.

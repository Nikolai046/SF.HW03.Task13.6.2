using System.Text.RegularExpressions;

namespace SF.HW03.Task13_6_2;
class Program
{
    private static void Main(string[] args)
    {
        /// <summary>
        /// Путь к файлу с текстом для анализа.
        /// </summary>
        var textPath = Path.Combine(DirectoryExtension.GetSolutionRoot(), "Text1.txt");

        /// <summary>
        /// Содержимое текстового файла.
        /// </summary>
        var text = string.Empty;
        try
        {
            text = File.ReadAllText(textPath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            return;
        }

        // Читаем список исключаемых слов
        HashSet<string> excludedWords = ReadExcludedWords();

        // Разделяем текст на слова
        char[] separators = new char[] { ' ', '.', ',', '!', '?', ':', ';', '\n', '\r', '\t' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        // Создаем словарь для подсчета слов
        Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // Подсчитываем количество каждого слова, исключая слова из списка
        foreach (string word in words)
        {
            string cleanWord = CleanWord(word);
            if (!string.IsNullOrEmpty(cleanWord) && !excludedWords.Contains(cleanWord))
            {
                if (wordCount.ContainsKey(cleanWord))
                {
                    wordCount[cleanWord]++;
                }
                else
                {
                    wordCount[cleanWord] = 1;
                }
            }
        }

        // Сортируем слова по частоте (по убыванию)
        var sortedWords = wordCount.OrderByDescending(pair => pair.Value);

        // Выводим топ-10 самых часто встречающихся слов
        Console.WriteLine("Топ-10 самых часто встречающихся слов:");
        foreach (var pair in sortedWords.Take(10))
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }

    /// <summary>
    /// Очищает слово от не-буквенных символов и приводит его к нижнему регистру.
    /// </summary>
    /// <param name="word"> Слово для очистки.</param>
    /// <returns>Очищенное слово в нижнем регистре или пустую строку, если слово не содержит букв.</returns>
    static string CleanWord(string word)
    {
        int start = 0, end = word.Length - 1;
        while (start < word.Length && !char.IsLetter(word[start])) start++;
        while (end >= 0 && !char.IsLetter(word[end])) end--;
        return start <= end ? word[start..(end + 1)].ToLower() : string.Empty;
    }

    /// <summary>
    /// Читает список исключаемых слов из файла.
    /// </summary>
    /// <returns>HashSet, содержащий исключаемые слова.</returns>
    static HashSet<string> ReadExcludedWords()
    {
        /// <summary>
        /// Путь к файлу с исключаемыми словами.
        /// </summary>
        var excludedWordsPath = Path.Combine(DirectoryExtension.GetSolutionRoot(), "ExcludedWords.txt");
        /// <summary>
        /// Множество для хранения исключаемых слов.
        /// </summary>
        var excludedWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        /// Массив строк из файла с исключаемыми словами.
        /// </summary>
        var lines = Array.Empty<string>();
        try
        {
             lines = File.ReadAllLines(excludedWordsPath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            return excludedWords;
        }

        foreach (string line in lines)
        {
            // Пропускаем строки, начинающиеся с ###
            if (line.TrimStart().StartsWith("###"))
            {
                continue;
            }

            string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                string cleanWord = CleanWord(word);
                if (!string.IsNullOrEmpty(cleanWord))
                {
                    excludedWords.Add(cleanWord);
                }
            }
        }

        return excludedWords;
    }

}

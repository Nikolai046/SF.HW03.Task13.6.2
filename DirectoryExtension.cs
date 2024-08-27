namespace SF.HW03.Task13_6_2;

public static class DirectoryExtension
{
    /// <summary>
    /// Получает путь к корневой директории решения
    /// </summary>
    /// <returns>Строка, представляющая путь к корневой директории решения</returns>
    public static string GetSolutionRoot()
    {
        var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
        var fullname = Directory.GetParent(dir).FullName;
        var projectRoot = fullname.Substring(0, fullname.Length - 4);
        return projectRoot;
    }
}
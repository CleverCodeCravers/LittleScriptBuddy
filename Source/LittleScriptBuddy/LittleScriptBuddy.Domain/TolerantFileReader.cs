namespace LittelScriptBuddy.Domain
{
    public static class TolerantFileReader
    {
        private static string[] ReadFileInternal(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public static string[] ReadFile(string filePath)
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    return ReadFileInternal(filePath);
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }

            return Array.Empty<string>();
        }
    }
}

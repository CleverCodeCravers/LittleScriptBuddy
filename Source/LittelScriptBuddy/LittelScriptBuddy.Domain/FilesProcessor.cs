namespace LittelScriptBuddy.Domain
{
    public static class FilesProcessor
    {
        public static string ParseString(string input)
        {
            string[] words = input.Split(' ');
            var result = new List<string>();

            foreach (string word in words)
            {
                if (word == "//" || word == "lsb:" || word == "of")
                {
                    continue;
                }

                result.Add(word);
            }

            return string.Join(" ", result);
        }


        public static string GetFirstLine(string filepath)
        {
            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("// lsb:"))
                    {
                        return line;
                    }
                }
            }
            return "";
        }

        public static string GetToken(ref string rest)
        {
            string token = "";

            int spaceIndex = rest.IndexOf(' ');

            if (spaceIndex == -1)
            {
                token = rest;
                rest = "";
            }
            else
            {
                token = rest.Substring(0, spaceIndex);

                rest = rest.Substring(spaceIndex + 1).Trim();
            }

            return token;
        }

        public static bool CheckIfScriptExists(string scriptPath)
        {
            return File.Exists(scriptPath);
        }
    }
}

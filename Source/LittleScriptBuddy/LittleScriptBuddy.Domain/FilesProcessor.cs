namespace LittelScriptBuddy.Domain
{
    public static class FilesProcessor
    {

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

        public static string[] ReplaceLineWithContent(string[] filecontent, int rowIndex, string insertThis)
        {
            List<string> newFileContent = new List<string>(filecontent);

            newFileContent.RemoveAt(rowIndex);
            newFileContent.Insert(rowIndex, insertThis);

            return newFileContent.ToArray();
        }

    }
}

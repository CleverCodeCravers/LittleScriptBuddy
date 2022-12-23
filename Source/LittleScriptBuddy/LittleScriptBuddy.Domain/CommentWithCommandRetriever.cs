using System.Dynamic;

namespace LittelScriptBuddy.Domain
{
    public static class CommentWithCommandRetriever
    {
        public static GetCommentResult Get(string[] filecontent)
        {
            for (int i = 0; i < filecontent.Length; i++)
            {
                string? row = filecontent[i];
                var trimmed = row.Trim();

                if (trimmed.StartsWith("//lsb:"))
                    return new GetCommentResult(i, trimmed);
            }

            return new GetCommentResult(-1, string.Empty);
        }

        public static string ExtractCommandOnly(string commentWithCommand)
        {
            var comment = commentWithCommand;
            var sliced = comment.Remove(0, "//lsb:".Length);

            return sliced.Trim();
        }
    }
}

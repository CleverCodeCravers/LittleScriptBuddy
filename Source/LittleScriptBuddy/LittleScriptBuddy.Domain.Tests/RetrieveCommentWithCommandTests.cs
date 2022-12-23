using NUnit.Framework;


namespace LittelScriptBuddy.Domain.Tests;

[TestFixture]
public class RetrieveCommentWithCommandGetTests
{
    [Test]
    public void Given_a_file_content_the_class_retrieves_the_comment_with_a_lsb_command()
    {
        var filecontent = @"This
is
some
//lsb: Collection of IThing
file
content.".Split(Environment.NewLine);

        var result = CommentWithCommandRetriever.Get(filecontent);

        Assert.AreEqual("//lsb: Collection of IThing", result.Comment);
    }

    [Test]
    public void Whitespaces_in_front_of_the_comment_do_not_hinder_the_extraction_of_the_command()
    {
        var filecontent = @"This
is
some
          //lsb: Collection of IThing
file
content.".Split(Environment.NewLine);

        var result = CommentWithCommandRetriever.Get(filecontent);

        Assert.AreEqual("//lsb: Collection of IThing", result.Comment);
    }


}

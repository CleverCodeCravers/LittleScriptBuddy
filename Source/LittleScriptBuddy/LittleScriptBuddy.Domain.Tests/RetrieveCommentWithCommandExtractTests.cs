using NUnit.Framework;


namespace LittelScriptBuddy.Domain.Tests;

[TestFixture]
public class RetrieveCommentWithCommandExtractTests
{
    [Test]
    public void Given_a_comment_it_should_extract_the_command()
    {
        var comment = "//lsb: collection.ps1 IWhatever";

        var result = CommentWithCommandRetriever.ExtractCommandOnly(comment);

        Assert.AreEqual("collection.ps1 IWhatever", result);
    }

//    [Test]
//    public void Whitespaces_in_front_of_the_comment_do_not_hinder_the_extraction_of_the_command()
//    {
//        var filecontent = @"This
//is
//some
//          //lsb: Collection of IThing
//file
//content.".Split(Environment.NewLine);

//        var result = CommentWithCommandRetriever.Get(filecontent);

//        Assert.AreEqual("//lsb: Collection of IThing", result);
//    }
}

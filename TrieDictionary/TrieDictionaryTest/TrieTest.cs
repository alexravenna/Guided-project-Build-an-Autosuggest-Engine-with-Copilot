namespace TrieDictionaryTest;

[TestClass]
public class TrieTest
{
    //Test that a word is inserted in the trie
    [TestMethod]
    public void InsertWord()
    {
        //Arrange
        Trie trie = new Trie();
        string word = "hello";

        //Act
        trie.Insert(word);

        //Assert
        Assert.IsTrue(trie.Search(word));
    }

    // Test that a word is deleted from the trie
    [TestMethod]
    public void DeleteWord()
    {
        //Arrange
        Trie trie = new Trie();
        string word = "hello";

        //Act
        trie.Insert(word);
        trie.Delete(word);

        //Assert
        Assert.IsFalse(trie.Search(word));
    }

    // Test that a word is not inserted twice in the trie
    [TestMethod]
    public void InsertWordTwice()
    {
        //Arrange
        Trie trie = new Trie();
        string word = "hello";

        //Act
        trie.Insert(word);
        trie.Insert(word);

        //Assert
        Assert.IsTrue(trie.Search(word));
    }

    // Test that a word is deleted from the trie
    [TestMethod]
    public void DeleteWordTwice()
    {
        //Arrange
        Trie trie = new Trie();
        string word = "hello";

        //Act
        trie.Insert(word);
        trie.Delete(word);
        trie.Delete(word);

        //Assert
        Assert.IsFalse(trie.Search(word));
    }

    // Test that a word is not deleted from the trie if it is not present
    [TestMethod]
    public void DeleteWordNotPresent()
    {
        //Arrange
        Trie trie = new Trie();
        string word = "hello";

        //Act
        trie.Delete(word);

        //Assert
        Assert.IsFalse(trie.Search(word));
    }

    // Test that a word is deleted from the trie if it is a prefix of another word
    [TestMethod]
    public void DeleteWordPrefix()
    {
        //Arrange
        Trie trie = new Trie();
        string word1 = "hello";
        string word2 = "hell";

        //Act
        trie.Insert(word1);
        trie.Insert(word2);
        trie.Delete(word2);

        //Assert
        Assert.IsTrue(trie.Search(word1));
        Assert.IsFalse(trie.Search(word2));
    }

    // Test AutoSuggest for the prefix "cat" not present in the
    // trie containing "catastrophe, catatonic", and "caterpillar"
    [TestMethod]
    public void AutoSuggest()
    {
        //Arrange
        Trie trie = new Trie();
        string word1 = "catastrophe";
        string word2 = "catatonic";
        string word3 = "caterpillar";
        string prefix = "cat";

        //Act
        trie.Insert(word1);
        trie.Insert(word2);
        trie.Insert(word3);
        List<string> suggestions = trie.AutoSuggest(prefix);

        //Assert
        Assert.AreEqual(3, suggestions.Count);
        Assert.IsTrue(suggestions.Contains(word1));
        Assert.IsTrue(suggestions.Contains(word2));
        Assert.IsTrue(suggestions.Contains(word3));
    }

    // Test GetSpellingSuggestions for a word not present in the trie
    [TestMethod]
    public void GetSpellingSuggestions()
    {
        //Arrange
        Trie trie = new Trie();
        string word1 = "catastrophe";
        string word2 = "catatonic";
        string word3 = "caterpillar";
        string prefix = "cat";

        //Act
        trie.Insert(word1);
        trie.Insert(word2);
        trie.Insert(word3);
        List<string> suggestions = trie.GetSpellingSuggestions("caterpiller");

        //Assert
        Assert.AreEqual(1, suggestions.Count);
        Assert.AreEqual("caterpillar", suggestions[0]);
    }
}
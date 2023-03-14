using Asal.StringExtentions;

namespace Asal.StringExtentionsUnitTest
{
    [TestClass]
    public class UnitTest
    {
        #region Clear Special Characters

        [TestMethod]
        public void ClearSpecialCharactersWithoutSpaceReplacementTest()
        {
            var input = "as#df%";
            var output = "asdf";

            var res = input.ClearSpecialCharacters(false).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void ClearSpecialCharactersWithSpaceReplacementTest()
        {
            var input = "as#df%";
            var output = "as df";

            var res = input.ClearSpecialCharacters(true).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void ClearSpecialCharactersWithoutSpaceReplacementListTest()
        {
            var input = new List<string>() { "as#df%", "a##jjh^" };
            var output = new List<string>() { "asdf", "ajjh" };

            var res = input.ClearSpecialCharacters(false).Result;

            Assert.IsTrue(res.SequenceEqual(output));
        }

        [TestMethod]
        public void ClearSpecialCharactersWitSpaceReplacementListTest()
        {
            var input = new List<string>() { "as#df%", "a##jjh^" };
            var output = new List<string>() { "as df", "a jjh" };

            var res = input.ClearSpecialCharacters(true).Result;

            Assert.IsTrue(res.SequenceEqual(output));
        }
        #endregion

        #region Separate String

        [TestMethod]
        public void GetSeparatedStringTest()
        {
            var input = "HarryPotter";
            var output = "Harry Potter";

            var res = input.GetSeparatedString().Result;

            Assert.AreEqual(output, res);

        }

        [TestMethod]
        public void GetSeparatedStringListTest()
        {
            var input = new List<string> { "HarryPotter", "TheShawshankRedemption", "godFather" };
            var output = new List<string> { "Harry Potter", "The Shawshank Redemption", "god Father" };

            var res = input.GetSeparatedString().Result;

            Assert.IsTrue(res.SequenceEqual(output));

        }
        #endregion

        #region Clear digits from string

        [TestMethod]
        public void ClearDigitsFromStringWithoutSpaceReplacementTest()
        {
            var input = "88Harr4y4Potter3";
            var output = "HarryPotter";

            var res = input.ClearDigitsFromString(false).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void ClearDigitsFromStringWithSpaceReplacementTest()
        {
            var input = "88Harr4y4Potter3";
            var output = "Harr y Potter";

            var res = input.ClearDigitsFromString(true).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void ClearDigitsFromListOfStringsWithoutSpaceReplacementTest()
        {
            var input = new List<string> { "fo9o", "He33y" };
            var output = new List<string> { "foo", "Hey" };

            var res = input.ClearDigitsFromString(false).Result;

            Assert.IsTrue(res.SequenceEqual(output));
        }

        [TestMethod]
        public void ClearDigitsFromListOfStringsWithSpaceReplacementTest()
        {
            var input = new List<string> { "fo9o", "He33y" };
            var output = new List<string> { "fo o", "He  y" };

            var res = input.ClearDigitsFromString(true).Result;

            Assert.IsTrue(res.SequenceEqual(output));
        }
        #endregion

        #region Check E-mail

        [TestMethod]
        public void IsValidEmailTest()
        {
            var input = "test@test.com";

            var res = input.IsValidEmail().Result;

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void GetEmailStatusListTest()
        {
            var input = new List<string> { "test@test.com", "test@test.com.", "test.aa.com" };

            var output = new Dictionary<string, bool>();
            output.Add("test@test.com", true);
            output.Add("test@test.com.", false);
            output.Add("test.aa.com", false);

            var res = input.GetEmailsStatus().Result;

            Assert.IsTrue(res.SequenceEqual(output));
        }
        #endregion

        #region Extract Email(s) from string
        [TestMethod]
        public void ExtractValidEmailsFromStringTest()
        {
            var input = "Hi, This is a test string with e-mail: test@test.com and this method will extract valid emails in the string, test2@test.com but no valid ones like: test.com Or test@.test.com and etc..";

            var output = new List<string> { "test@test.com", "test2@test.com" };

            var res = input.ExtractEmailsFromString().Result;

            Assert.IsTrue(res.SequenceEqual(output));
        }

        #endregion
    }
}
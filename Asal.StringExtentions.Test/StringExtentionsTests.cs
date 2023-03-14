namespace Asal.StringExtentions.Test
{
    [TestClass]
    public class StringExtentionsTests
    {
        #region Clear Special Characters

        [TestMethod]
        public void ClearSpecialCharactersWithoutSpaceReplacementTest()
        {
            var input = "as#df%";
            var output = "asdf";

            var res = input.ClearSpecialCharacters();

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void ClearSpecialCharactersWithSpaceReplacementTest()
        {
            var input = "as#df%";
            var output = "as df";

            var res = input.ClearSpecialCharacters(true);

            Assert.AreEqual(output, res);
        }

        #endregion

        #region Humanize

        [TestMethod]
        public void HumanizeTest()
        {
            var input = "HarryPotter";
            var output = "Harry Potter";

            var res = input.Humanize();

            Assert.AreEqual(output, res);
        }

        #endregion

        #region Clear digits 

        [TestMethod]
        public void ClearDigitsWithoutSpaceReplacementTest()
        {
            var input = "88Harr4y4Potter3";
            var output = "HarryPotter";

            var res = input.ClearDigits();

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void ClearDigitsFromStringWithSpaceReplacementTest()
        {
            var input = "88Harr4y4Potter3";
            var output = "Harr y Potter";

            var res = input.ClearDigits(true);

            Assert.AreEqual(output, res);
        }

        #endregion

        #region Check E-mail

        [TestMethod]
        public void IsValidEmailTest()
        {
            var input = "test@test.com";

            var res = input.IsValidEmail();

            Assert.IsTrue(res);
        }

        #endregion

        #region Extract valid Email(s)

        [TestMethod]
        public void ExtractValidEmailsFromStringTest()
        {
            var input = "Hi, This is a test string with e-mail: test@test.com and this method will extract valid emails in the string, test2@test.com but no valid ones like: test.com Or test@.test.com and etc..";

            var output = new List<string> { "test@test.com", "test2@test.com" };

            var res = input.ExtractEmails();

            Assert.IsTrue(res.SequenceEqual(output));
        }

        #endregion
    }
}
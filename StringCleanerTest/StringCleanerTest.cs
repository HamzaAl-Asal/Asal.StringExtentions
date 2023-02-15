using Asal.StringCleaner;

namespace StringCleanerTest
{
    [TestClass]
    public class StringCleanerTest
    {
        #region Test Clear Sepcial Characters
        [TestMethod]
        public void TestClearSpecialCharacters()
        {
            string input = "Hamz#a";
            string output = "Hamza";

            var res = StringCleanerHelper.ClearSpecialCharacters(input, false).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void TestReplaceSpecialCharacterWithSpace()
        {
            string input = "Hamz#a";
            string output = "Hamz a";

            var res = StringCleanerHelper.ClearSpecialCharacters(input, true).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void TestClearSpecialCharactersFromList()
        {
            var input = new List<string> { "Hamz#a", "$#ggfh%f" };
            var output = new List<string> { "Hamza", "ggfhf" };

            var res = StringCleanerHelper.ClearSpecialCharacters(input, false).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }

        [TestMethod]
        public void TestReplaceSpecialCharacterWithSpaceFromList()
        {
            var input = new List<string> { "Hamz#a", "$#ggfh%f" };
            var output = new List<string> { "Hamz a", "ggfh f" };

            var res = StringCleanerHelper.ClearSpecialCharacters(input, true).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }
        #endregion

        #region Test Separate String
        [TestMethod]
        public void TestGetSeparatedString()
        {
            string input = "harryPotter";
            string output = "harry Potter";

            var res = StringCleanerHelper.GetSeparatedString(input).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void TestGetSeparatedStringFromList()
        {
            var input = new List<string> { "harryPotter", "TheShawshankRedemption" };
            var output = new List<string> { "harry Potter", "The Shawshank Redemption" };

            var res = StringCleanerHelper.GetSeparatedString(input).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }

        [TestMethod]
        public void TestGetSeparatedStringWhenNull()
        {
            var input = string.Empty;
            var output = string.Empty;

            var res = StringCleanerHelper.GetSeparatedString(input).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void TestGetSeparatedStringListIsEmpty()
        {
            var input = new List<string>();
            var output = new List<string>();

            var res = StringCleanerHelper.GetSeparatedString(input).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }
        #endregion

        #region Test Clear string from any digits
        [TestMethod]
        public void TestClearDigitsFromString()
        {
            var input = "Ha9mz5a";
            var output = "Hamza";

            var res = StringCleanerHelper.ClearDigitsFromString(input, false).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void TestClearDigitsFromStringWithSpace()
        {
            var input = "Ha9mz5a";
            var output = "Ha mz a";

            var res = StringCleanerHelper.ClearDigitsFromString(input, true).Result;

            Assert.AreEqual(output, res);
        }

        [TestMethod]
        public void TestClearDigitsFromListOfString()
        {
            var input = new List<string> { "Ha9mz5a", "Gorg763eous65", "34ggc3r" };
            var output = new List<string> { "Hamza", "Gorgeous", "ggcr" };


            var res = StringCleanerHelper.ClearDigitsFromString(input, false).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }

        [TestMethod]
        public void TestClearDigitsFromListOfStringWithSpace()
        {
            var input = new List<string> { "Ha9mz5a", "Gorg63eous65", "34ggc3r" };
            var output = new List<string> { "Ha mz a", "Gorg  eous", "ggc r" };


            var res = StringCleanerHelper.ClearDigitsFromString(input, true).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }
        #endregion

        #region Test String if email or Valid Email
        [TestMethod]
        public void TestValidEmail()
        {
            var input = "hamzaalasa@gmail.com";

            var res = StringCleanerHelper.IsValidEmail(input).Result;

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void TestValidEmailList()
        {
            var input = new List<string> { "hamzaalasa@gmail.com", "hamzaalasa@gmail.com.", ".hamzaalasa@gmail.com" };


            var output = new Dictionary<string, bool>();
            output.Add("hamzaalasa@gmail.com", true);
            output.Add("hamzaalasa@gmail.com.", false);
            output.Add(".hamzaalasa@gmail.com", false);

            var res = StringCleanerHelper.GetEmailsStatus(input).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }
        #endregion

        #region Test String if email or Valid Email
       
        [TestMethod]
        public void TestExtractValidEmailsFromString()
        {
            var input = "You can reach me out at hello@uibakery.io and .contact@uibakery.io, also u can contact me via hamzaalasa@gmail.com";
            var output = new List<string> { "hello@uibakery.io", "hamzaalasa@gmail.com" };
            var res = StringCleanerHelper.ExtractEmailsFromString(input).Result;

            Assert.IsTrue(output.SequenceEqual(res));
        }
        #endregion
    }
}
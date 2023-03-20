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

        #region Json

        [TestMethod]
        public void ExtractResultNameJsonPropertyValueTest()
        {
            var input = "{\"SearchTerm\":\"saw\",\"GeneralSearchDetails\":[{\"ResultName\":\"Blogs\",\"SchemaId\":27,\"pageIndex\":1,\"pageSize\":3,\"OrderByField\":[\"createdOn\"],\"isDescending\":true,\"CustomFilter\":{\"blogs_isVideo\":{\"Values\":[0],\"Operator\":\"and\",\"QueryType\":2}}}],\"WithFilter\":true}";

            var output = "Blogs";

            var res = input.ExtractJsonPropertyValue<string>("GeneralSearchDetails[0].ResultName");

            Assert.AreEqual(res, output);
        }

        [TestMethod]
        public void ExtractSchemaIdJsonPropertyValueTest()
        {
            var input = "{\"SearchTerm\":\"saw\",\"GeneralSearchDetails\":[{\"ResultName\":\"Blogs\",\"SchemaId\":27,\"pageIndex\":1,\"pageSize\":3,\"OrderByField\":[\"createdOn\"],\"isDescending\":true,\"CustomFilter\":{\"blogs_isVideo\":{\"Values\":[0],\"Operator\":\"and\",\"QueryType\":2}}}],\"WithFilter\":true}";

            var output = 27;

            var res = input.ExtractJsonPropertyValue<int>("GeneralSearchDetails[0].SchemaId");

            Assert.AreEqual(res, output);
        }

        [TestMethod]
        public void ExtractSearchTermJsonPropertyValueTest()
        {
            var input = "{\"SearchTerm\":\"saw\"}";

            var output = "saw";

            var res = input.ExtractJsonPropertyValue<string>("SearchTerm");

            Assert.AreEqual(res, output);
        }

        [TestMethod]
        public void ExtractArrayJsonPropertyValueTest()
        {
            var input = "{\"name\":\"John\",\"age\":30,\"cars\":[\"Ford\", \"BMW\", \"Fiat\"]}";

            var output = new List<string> { "Ford", "BMW", "Fiat" };

            var res = input.ExtractJsonArrayPropertyValue<string>("cars");

            Assert.IsTrue(res.SequenceEqual(output));
        }

        #endregion
    }
}
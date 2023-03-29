using Newtonsoft.Json;
using System.Runtime.CompilerServices;

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
        public void ExtractFirstSchemaIdJsonPropertyValueTest()
        {
            var input = "{\"SearchTerm\":\"saw\",\"GeneralSearchDetails\":[{\"ResultName\":\"Blogs\",\"SchemaId\":27,\"pageIndex\":1,\"pageSize\":3,\"OrderByField\":[\"createdOn\"],\"isDescending\":true,\"CustomFilter\":{\"blogs_isVideo\":{\"Values\":[0],\"Operator\":\"and\",\"QueryType\":2}}},{\"ResultName\":\"Blogs\",\"SchemaId\":28}],\"WithFilter\":true}";

            var output = 27;

            var res = input.ExtractJsonPropertyValue<int>("GeneralSearchDetails[0].SchemaId");

            Assert.AreEqual(res, output);
        }

        [TestMethod]
        public void ExtractSecondSchemaIdJsonPropertyValueTest()
        {
            var input = "{\"SearchTerm\":\"saw\",\"GeneralSearchDetails\":[{\"ResultName\":\"Blogs\",\"SchemaId\":27,\"pageIndex\":1,\"pageSize\":3,\"OrderByField\":[\"createdOn\"],\"isDescending\":true,\"CustomFilter\":{\"blogs_isVideo\":{\"Values\":[0],\"Operator\":\"and\",\"QueryType\":2}}},{\"ResultName\":\"Blogs\",\"SchemaId\":28}],\"WithFilter\":true}";

            var output = 28;

            var res = input.ExtractJsonPropertyValue<int>("GeneralSearchDetails[1].SchemaId");

            Assert.AreEqual(res, output);
        }

        [TestMethod]
        public void ExtractFirstNameJsonPropertyValueTest()
        {
            var input = "{\"data\":[{\"name\":\"test\"},{\"name\":\"test2\"}]}";

            var output = "test";

            var res = input.ExtractJsonPropertyValue<string>("data[0].name");

            Assert.AreEqual(res, output);
        }

        [TestMethod]
        public void ExtractSecondNameJsonPropertyValueTest()
        {
            var input = "{\"data\":[{\"name\":\"test\"},{\"name\":\"test2\"}]}";

            var output = "test2";

            var res = input.ExtractJsonPropertyValue<string>("data[1].name");

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
        public void ExtractJsonObjectValueTest()
        {
            var input = "{\"data\":[{\"baseObject\":{\"name\": \"test\", \"age\": 25 }},{\"name\":\"test2\"}]}";

            var output = new { name = "test", age = 25 };

            var res = input.ExtractJsonPropertyValue<object>("data[0].baseObject");

            Assert.AreEqual(JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(output));
        }

        [TestMethod]
        public void ExtractSecondJsonObjectValueTest()
        {
            var input = "{\"data\":[{\"baseObject\":[{\"name\": \"test\", \"age\": 25 }, {\"name\": \"test2\", \"age\": 27 }]},{\"name\":\"test2\"}]}";

            var output = new { name = "test", age = 25 };

            var res = input.ExtractJsonPropertyValue<object>("data[0].baseObject[0]");

            Assert.AreEqual(JsonConvert.SerializeObject(res), JsonConvert.SerializeObject(output));
        }

        [TestMethod]
        public void TryExtractJsonPropertyValueTest()
        {
            var input = "{\"data\":[{\"baseObject\":{\"name\": \"test\", \"age\": 25 }},{\"name\":\"test2\"}]}";

            var output = 25;

            var res = input.TryExtractJsonPropertyValue<int>("data[0].baseObject.age", out var result);
           
            Assert.IsTrue(res);
            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void ExtractCarsArrayJsonPropertyValueTest()
        {
            var input = "{\"name\":\"John\",\"age\":30,\"cars\":[\"Ford\", \"BMW\", \"Fiat\"]}";
            var output = new List<string> { "Ford", "BMW", "Fiat" };

            var res = input.ExtractJsonArrayPropertyValue<string>("cars");

            Assert.IsTrue(res.SequenceEqual(output));
        }

        #endregion
    }
}
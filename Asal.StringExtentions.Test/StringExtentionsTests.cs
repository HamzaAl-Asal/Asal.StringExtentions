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

        [TestMethod]
        public void XmlToJson()
        {
            string xml = @"
                            <root>
                              <person id='1'>
                                <name>Alan</name>
                                <url>http://www.google.com</url>
                              </person>
                              <person id='2'>
                                <name>Louis</name>
                                <url>http://www.yahoo.com</url>
                              </person>
                            </root>";

            var output = @"{""root"":{""person"":[{""@id"":""1"",""name"":""Alan"",""url"":""http://www.google.com""},{""@id"":""2"",""name"":""Louis"",""url"":""http://www.yahoo.com""}]}}";
            var result = xml.XmlToJson();

            Assert.AreEqual(result, output.ToString());
        }

        [TestMethod]
        public void XmlToJson2()
        {
            string xml = @"
                           <glossary>
                            <title>example glossary</title>
                                <GlossDiv>
                                <title>S</title>
                                <GlossList>
                                <GlossEntry>
                                <ID>SGML</ID>
                                <SortAs>SGML</SortAs>
                                <GlossTerm>Standard Generalized Markup Language</GlossTerm>
                                <Acronym>SGML</Acronym>
                                <Abbrev>ISO 8879:1986</Abbrev>
                                <GlossDef>
                                <para>A meta-markup language, used to create markup languages such as DocBook.</para>
                                <GlossSeeAlso>GML</GlossSeeAlso>
                                <GlossSeeAlso>XML</GlossSeeAlso>
                                </GlossDef>
                                <GlossSee>markup</GlossSee>
                                </GlossEntry>
                                </GlossList>
                                </GlossDiv>
                           </glossary>";

            var output = @"{""glossary"":{""title"":""example glossary"",""GlossDiv"":{""title"":""S"",""GlossList"":{""GlossEntry"":{""ID"":""SGML"",""SortAs"":""SGML"",""GlossTerm"":""Standard Generalized Markup Language"",""Acronym"":""SGML"",""Abbrev"":""ISO 8879:1986"",""GlossDef"":{""para"":""A meta-markup language, used to create markup languages such as DocBook."",""GlossSeeAlso"":[""GML"",""XML""]},""GlossSee"":""markup""}}}}}";
            var result = xml.XmlToJson();

            Assert.AreEqual(result, output);
        }

        [TestMethod]
        public void JsonToXml()
        {
            //no root here, so it will takes the default which is "root", or you can name it what you want with the deserilizeRootElementName param
            string json = @"{
'Id': 1,
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ],
  'Team': {
    'Id': 2,
    'Name': 'Software Developers',
    'Description': 'Creators of fine software products and services.'
  }
}";

            var xmlOutput = @"<root><Id>1</Id><Email>james@example.com</Email><Active>true</Active><CreatedDate>2013-01-20T00:00:00Z</CreatedDate><Roles>User</Roles><Roles>Admin</Roles><Team><Id>2</Id><Name>Software Developers</Name><Description>Creators of fine software products and services.</Description></Team></root>";

            var result = json.JsonToXml();

            Assert.AreEqual(result, xmlOutput);
        }

        [TestMethod]
        public void JsonToXmlWithoutRootElementName()
        {

            //the root here is glossary tag, so you can send an empty string or null to the deserilizeRootElementName param
            string json = @"{
   ""glossary"": {
      ""title"": ""example glossary"",
      ""GlossDiv"": {
         ""title"": ""S"",
         ""GlossList"": {
            ""GlossEntry"": {
               ""ID"": ""SGML"",
               ""SortAs"": ""SGML"",
               ""GlossTerm"": ""Standard Generalized Markup Language"",
               ""Acronym"": ""SGML"",
               ""Abbrev"": ""ISO 8879:1986"",
               ""GlossDef"": {
                  ""para"": ""A meta-markup language, used to create markup languages such as DocBook."",
                  ""GlossSeeAlso"": [
                     ""GML"",
                     ""XML""
                  ]
               },
               ""GlossSee"": ""markup""
            }
         }
      }
   }
}
";
            var output = @"<glossary><title>example glossary</title><GlossDiv><title>S</title><GlossList><GlossEntry><ID>SGML</ID><SortAs>SGML</SortAs><GlossTerm>Standard Generalized Markup Language</GlossTerm><Acronym>SGML</Acronym><Abbrev>ISO 8879:1986</Abbrev><GlossDef><para>A meta-markup language, used to create markup languages such as DocBook.</para><GlossSeeAlso>GML</GlossSeeAlso><GlossSeeAlso>XML</GlossSeeAlso></GlossDef><GlossSee>markup</GlossSee></GlossEntry></GlossList></GlossDiv></glossary>";
            var result = json.JsonToXml(string.Empty);

            Assert.AreEqual(result, output);
        }

        #endregion

        #region Json to Yaml
        [TestMethod]
        public void JsonToYamlFirstTest()
        {
            string json = @"{
'Id': 1,
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ],
  'Team': {
    'Id': 2,
    'Name': 'Software Developers',
    'Description': 'Creators of fine software products and services.'
  }
}";

            var xmlOutput = "Id: 1\r\nEmail: james@example.com\r\nActive: true\r\nCreatedDate: 2013-01-20T00:00:00.0000000Z\r\nRoles:\r\n- User\r\n- Admin\r\nTeam:\r\n  Id: 2\r\n  Name: Software Developers\r\n  Description: Creators of fine software products and services.";

            var result = json.JsonToYaml();

            Assert.AreEqual(result, xmlOutput);
        }

        [TestMethod]
        public void JsonToYamlSecondTest()
        {
            string jsonInput = @"{
   ""glossary"": {
      ""title"": ""example glossary"",
      ""GlossDiv"": {
         ""title"": ""S"",
         ""GlossList"": {
            ""GlossEntry"": {
               ""ID"": ""SGML"",
               ""SortAs"": ""SGML"",
               ""GlossTerm"": ""Standard Generalized Markup Language"",
               ""Acronym"": ""SGML"",
               ""Abbrev"": ""ISO 8879:1986"",
               ""GlossDef"": {
                  ""para"": ""A meta-markup language, used to create markup languages such as DocBook."",
                  ""GlossSeeAlso"": [
                     ""GML"",
                     ""XML""
                  ]
               },
               ""GlossSee"": ""markup""
            }
         }
      }
   }
}
";

            var xmlOutput = "glossary:\r\n  title: example glossary\r\n  GlossDiv:\r\n    title: S\r\n    GlossList:\r\n      GlossEntry:\r\n        ID: SGML\r\n        SortAs: SGML\r\n        GlossTerm: Standard Generalized Markup Language\r\n        Acronym: SGML\r\n        Abbrev: ISO 8879:1986\r\n        GlossDef:\r\n          para: A meta-markup language, used to create markup languages such as DocBook.\r\n          GlossSeeAlso:\r\n          - GML\r\n          - XML\r\n        GlossSee: markup";

            var result = jsonInput.JsonToYaml();

            Assert.AreEqual(result, xmlOutput);
        }
        #endregion

        #region Yaml to Json
        [TestMethod]
        public void YamlToJsonFirstTest()
        {
            string yamlInput = "Id: 1\r\nEmail: james@example.com\r\nActive: true\r\nCreatedDate: 2013-01-20T00:00:00.0000000Z\r\nRoles:\r\n- User\r\n- Admin\r\nTeam:\r\n  Id: 2\r\n  Name: Software Developers\r\n  Description: Creators of fine software products and services.\r\n";

            var jsonOutput = "{\"Id\": \"1\", \"Email\": \"james@example.com\", \"Active\": \"true\", \"CreatedDate\": \"2013-01-20T00:00:00.0000000Z\", \"Roles\": [\"User\", \"Admin\"], \"Team\": {\"Id\": \"2\", \"Name\": \"Software Developers\", \"Description\": \"Creators of fine software products and services.\"}}";

            var result = yamlInput.YamlToJson();

            Assert.AreEqual(result, jsonOutput);
        }

        [TestMethod]
        public void YamlToJsonSecondTest()
        {
            string yamlInput = "glossary:\r\n  title: example glossary\r\n  GlossDiv:\r\n    title: S\r\n    GlossList:\r\n      GlossEntry:\r\n        ID: SGML\r\n        SortAs: SGML\r\n        GlossTerm: Standard Generalized Markup Language\r\n        Acronym: SGML\r\n        Abbrev: ISO 8879:1986\r\n        GlossDef:\r\n          para: A meta-markup language, used to create markup languages such as DocBook.\r\n          GlossSeeAlso:\r\n          - GML\r\n          - XML\r\n        GlossSee: markup\r\n";

            var jsonOutput = "{\"glossary\": {\"title\": \"example glossary\", \"GlossDiv\": {\"title\": \"S\", \"GlossList\": {\"GlossEntry\": {\"ID\": \"SGML\", \"SortAs\": \"SGML\", \"GlossTerm\": \"Standard Generalized Markup Language\", \"Acronym\": \"SGML\", \"Abbrev\": \"ISO 8879:1986\", \"GlossDef\": {\"para\": \"A meta-markup language, used to create markup languages such as DocBook.\", \"GlossSeeAlso\": [\"GML\", \"XML\"]}, \"GlossSee\": \"markup\"}}}}}";

            var result = yamlInput.YamlToJson();

            Assert.AreEqual(result, jsonOutput);
        }
        #endregion
    }
}
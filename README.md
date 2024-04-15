**How to install Asal.StringExtentions ?

-You can easily install it from Manage Nuget package and write Asal so it will display for you as "Asal.StringExtentions" click download.

**How can I use it ?

-Once you downloaded the package, you can use it on the string itself.. e.g (yourStr."Choose the method that you want to use from the extentions"):-

(1)-> yourStr.ClearSpecialCharacters(optinal param) -> This extention take an optional param if you want to replace a space after the char cleared, false by default.

(2)-> yourStr.ClearDigits(optinal param) -> This extention take an optional param if you want to replace a space after the digits cleared, false by default.

(3)-> yourStr.Humanize() -> Extention to humanize string (separate str by space).

(4)-> yourStr.IsValidEmail() -> Extention to check the e-mail if it`s valid or not, return true or false.

(5)-> yourStr.ExtractEmails() -> Extention to extract all valid emails in the giving string.

(6)-> yourJsonStrBody.ExtractJsonPropertyValue(string jsonProperty)-> This extention extract a json property value that related to the giving jsonProperty parameter.

Examples:::

****lets say we have a json body like the following : jsonBody = "{"name":"John","age":30,"cars":["Ford", "BMW", "Fiat"]}"

and I want to extract the name of the json property, all you need to do is call the ExtractJsonPropertyValue extention and specify the method return type.

( var result = jsonBody.ExtractJsonPropertyValue("name"); So in this point the result will be as "John". )

Lets say I want to get a property value inside object which is the age ? lets take another Josn body..

JsonBody = "{"data":[{"baseObject":{"name": "test", "age": 25 }},{"name":"test2"}]}"

answer:

( var result = jsonBody.ExtractJsonPropertyValue("data[0].baseObject.age"); Now, the result will be 25

**what about the name ? var result = jsonBody.ExtractJsonPropertyValue("data[0].baseObject.name"); Now, the result will be "test" )

**How can i extract the object itself ? JsonBody = "{"data":[{"baseObject":{"name": "test", "age": 25 }},{"name":"test2"}]}"

//data[0] represents the first index of the array

answer: ( var result = jsonBody.ExtractJsonPropertyValue("data[0].baseObject"); so the result will be an object that contains the name with it`s value and same for the age. {"name": "test", "age": 25 } )

**How can i get the second object ? JsonBody = "{"data":[{"baseObject":[{"name": "test", "age": 25 }, {"name": "test2", "age": 27 }]},{"name":"test2"}]}"

//baseObject[0] -> represents the first object inside baseObject array //baseObject[1] -> represents the second object inside baseObject array

answer: ( var result = jsonBody.ExtractJsonPropertyValue("data[0].baseObject[1]"); so the result will be an object that contains the name with it`s value and same for the age. {"name": "test2", "age": 27 }

**Lets say i need now the first object ? var result = jsonBody.ExtractJsonPropertyValue("data[0].baseObject[0]"); so the result will be {"name": "test", "age": 25 }

*****First object name ? var result = jsonBody.ExtractJsonPropertyValue("data[0].baseObject[0].name"); )

(7)-> yourJsonStrBody.TryExtractJsonPropertyValue(string jsonProperty, out T result)-> This extention extract a json property value that related to the giving jsonProperty parameter, a the second parameter represent out result.. so you should specify the T type, no exceptions giving in the extention if it was an error it will return the default of T type in the out result and false as boolean for the method return type.

so after the call happened with success you can use the method value which is bool value Or can take the out result which is the actual data value.

Note: the extraction will be same as ExtractJsonPropertyValue(string jsonProperty) extention but without exceptions.

Example: var input = "{"data":[{"baseObject":{"name": "test", "age": 25 }},{"name":"test2"}]}";

var res = input.TryExtractJsonPropertyValue("data[0].baseObject.age", out var result);

result will be 25

//res value as bool and result have the actual data value depending on the T type

(8)-> yourJsonStrBody.ExtractJsonArrayPropertyValue(string jsonProperty)-> This extention will extract an array values, the return type of it is IEnumerable .

Example: var input = "{"name":"John","age":30,"cars":["Ford", "BMW", "Fiat"]}";

in this example let`s say that i want to get "cars" values which is an array.

answer: ( var res = input.ExtractJsonArrayPropertyValue("cars"); the res value will be List { "Ford", "BMW", "Fiat" } )

(9)-> yourXmlStr.XmlToJson()-> Extention to Convert the giving xmlString into Json string .

Example: string xmlStr = @" Alan http://www.google.com Louis http://www.yahoo.com "; var result = xmlStr.XmlToJson() the result here will be as json : { "root": { "person": [ { "name": "Alan", "url": "http://www.google.com" }, { "name": "Louis", "url": "http://www.yahoo.com" } ] } }

(10)-> yourJsonStr.JsonToXml()-> Extention to Convert the giving Json into Xml.

this Extention takes 3 params: 1=> deserializeRootElementName (Optional) default value is "root" (string):-

in case that the json didn`t have a root element to deserilize, the default for this param is "root" and it can be changible to the name that you want also if the Json have root element.. you can send this param as (string.Empty / null)
2=> writeArrayAttribute (Optional) false by default (bool):-

A value to indicate whether to write the Json.NET array attribute. This attribute helps preserve arrays when converting the written XML back to JSON.
3=> encodeSpecialCharacters (Optional) false by default (bool):-

A value to indicate whether to encode special characters when converting JSON to XML. If true, special characters like ':', '@', '?', '#' and '$' in JSON property names aren't used to specify XML namespaces, attributes or processing directives. Instead special characters are encoded and written as part of the XML element name.
Example:

Without root element tag
//which mean the giving json already have a root //root name here is "glossary", so i will send deserializeRootElementName param as empty to take my root "glossary"

string jsonStr = @" { "glossary": { "title": "example glossary", "GlossDiv": { "title": "S", "GlossList": { "GlossEntry": { "ID": "SGML", "SortAs": "SGML", "GlossTerm": "Standard Generalized Markup Language", "Acronym": "SGML", "Abbrev": "ISO 8879:1986", "GlossDef": { "para": "A meta-markup language, used to create markup languages such as DocBook.", "GlossSeeAlso": ["GML", "XML"] }, "GlossSee": "markup" } } } } } ";

var result = jsonStr.JsonToXml(string.Empty) so the result will be as Xml like the following:

<title>example glossary</title> <title>S</title> Standard Generalized Markup Language SGML ISO 8879:1986 A meta-markup language, used to create markup languages such as DocBook.

With root element tag which means the the josn did`nt have a root element like the following ex:
string jsonStr = @"{ 'Id': 1, 'Email': 'james@example.com', 'Active': true, 'CreatedDate': '2013-01-20T00:00:00Z', 'Roles': [ 'User', 'Admin' ], 'Team': { 'Id': 2, 'Name': 'Software Developers', 'Description': 'Creators of fine software products and services.' } }";

var result = jsonStr.JsonToXml() now, the result will be as xml like the following:

1 james@example.com true 2013-01-20T00:00:00Z User Admin 2 Software Developers Creators of fine software products and services.
-- as u can see the default root element has been applied to the giving json named "root".

(11)-> YourYamlString.YamlToJson() -> Extention to convert the json string body to yaml format.

Example: Let say that have the following yaml body::

string yamlBody = "Id: 1 Email: james@example.com Active: true CreatedDate: 2013-01-20T00:00:00.0000000Z Roles: - User - Admin Team: Id: 2 Name: Software Developers Description: Creators of fine software products and services.";

var result = yamlBody.YamlToJson();

now, the output result will be a new json body format like the following:

result = {"Id": "1", "Email": "james@example.com", "Active": "true", "CreatedDate": "2013-01-20T00:00:00.0000000Z", "Roles": ["User", "Admin"], "Team": {"Id": "2", "Name": "Software Developers", "Description": "Creators of fine software products and services."} };

(12)-> YourJsonString.JsonToYaml() -> Extention to convert Yaml string body to Josn string format.

Example:

let`s take a json body to convert it to Yaml::

string jsonInput = @"{ ""glossary"": { ""title"": ""example glossary"", ""GlossDiv"": { ""title"": ""S"", ""GlossList"": { ""GlossEntry"": { ""ID"": ""SGML"", ""SortAs"": ""SGML"", ""GlossTerm"": ""Standard Generalized Markup Language"", ""Acronym"": ""SGML"", ""Abbrev"": ""ISO 8879:1986"", ""GlossDef"": { ""para"": ""A meta-markup language, used to create markup languages such as DocBook."", ""GlossSeeAlso"": [ ""GML"", ""XML"" ] }, ""GlossSee"": ""markup"" } } } } } ";

var result = jsonInput.JsonToYaml();

after the extention excecuted the result will return a new Yaml string format for the giving json like the following::

result = "glossary:title: example glossary GlossDiv: title: S GlossList: GlossEntry: ID: SGML SortAs: SGML GlossTerm: Standard Generalized Markup Language Acronym: SGML Abbrev: ISO 8879:1986 GlossDef: para: A meta-markup language, used to create markup languages such as DocBook. GlossSeeAlso: - GML - XML GlossSee: markup"

(13)-> YourString.Slugify() → Extention that Turn a string into a slug by removing all accents,
special characters, additional spaces, substituting
spaces with hyphens and making it lower-case.

14)-> ToCamelCase()-> Converts the input string to camelCase format.

Example: 

var input = "hello world";
var result = input.ToCamelCase();

// result will be "helloWorld"

15)-> ToPascalCase()-> Converts the input string to PascalCase format.

Example:

var input = "hello world";
var result = input.ToPascalCase();

// result will be "HelloWorld"

16)-> ToSnakeCase()-> Converts the input string to snake_case format.

Example:
 
var input = "hello world";
var result = input.ToSnakeCase();

// result will be "hello_world"

17) ToKebabCase()-> Converts the input string to kebab-case format.

Example:

var input = "hello world";
var result = input.ToKebabCase();

// result will be "hello-world"

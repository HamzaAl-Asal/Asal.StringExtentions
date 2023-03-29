**How to install Asal.StringExtentions ?

-You can easily install it from Manage Nuget package and write Asal so it will display for you as "Asal.StringExtentions" click download.

**How can I use it ?

-Once you downloaded the package, you can use it on the string itself..
e.g (yourStr."Choose the method that you want to use from the extentions"):-

(1)-> yourStr.ClearSpecialCharacters(optinal param) -> This extention take an optional param if you want to replace a space after the char cleared, false by default.

(2)-> yourStr.ClearDigits(optinal param) -> This extention take an optional param if you want to replace a space after the digits cleared, false by default.

(3)-> yourStr.Humanize() -> Extention to humanize string (separate str by space).
************************************************************************************************************************
(4)-> yourStr.IsValidEmail() -> Extention to check the e-mail if it`s valid or not, return true or false.

(5)-> yourStr.ExtractEmails() -> Extention to extract all valid emails in the giving string.
************************************************************************************************************************
(6)-> yourJsonStrBody.ExtractJsonPropertyValue<T>(string jsonProperty)-> This extention extract a json property value that related to the giving jsonProperty parameter.

Examples:::

****lets say we have a json body like the following :
jsonBody = "{\"name\":\"John\",\"age\":30,\"cars\":[\"Ford\", \"BMW\", \"Fiat\"]}"

and I want to extract the name of the json property, all you need to do is call the ExtractJsonPropertyValue extention and specify the method return type.

(
var result = jsonBody.ExtractJsonPropertyValue<string>("name");
So in this point the result will be as "John".
)

Let`s say I want to get a property value inside object which is the age ?
let`s take another Josn body..

JsonBody = "{\"data\":[{\"baseObject\":{\"name\": \"test\", \"age\": 25 }},{\"name\":\"test2\"}]}"

answer: 

(
var result = jsonBody.ExtractJsonPropertyValue<int>("data[0].baseObject.age");
Now, the result will be 25

**what about the name ? 
var result = jsonBody.ExtractJsonPropertyValue<string>("data[0].baseObject.name");
Now, the result will be "test"
)

**How can i extract the object itself ?
JsonBody = "{\"data\":[{\"baseObject\":{\"name\": \"test\", \"age\": 25 }},{\"name\":\"test2\"}]}"

//data[0] represents the first index of the array

answer:
(
var result = jsonBody.ExtractJsonPropertyValue<object>("data[0].baseObject");
so the result will be an object that contains the name with it`s value and same for the age.
{\"name\": \"test\", \"age\": 25 }
)

**How can i get the second object ?
JsonBody = "{\"data\":[{\"baseObject\":[{\"name\": \"test\", \"age\": 25 }, {\"name\": \"test2\", \"age\": 27 }]},{\"name\":\"test2\"}]}"

//baseObject[0] -> represents the first object inside baseObject array
//baseObject[1] -> represents the second object inside baseObject array

answer:
(
var result = jsonBody.ExtractJsonPropertyValue<object>("data[0].baseObject[1]"); 
so the result will be an object that contains the name with it`s value and same for the age.
{\"name\": \"test2\", \"age\": 27 }

**Lets say i need now the first object ? 
var result = jsonBody.ExtractJsonPropertyValue<object>("data[0].baseObject[0]"); 
so the result will be {\"name\": \"test\", \"age\": 25 }

*****First object name ?
var result = jsonBody.ExtractJsonPropertyValue<object>("data[0].baseObject[0].name");
)
************************************************************************************************************************
(7)-> yourJsonStrBody.TryExtractJsonPropertyValue<T>(string jsonProperty, out T result)-> This extention extract a json property value that related to the giving jsonProperty parameter, a the second parameter represent out result.. so 
you should specify the T type, no exceptions giving in the extention if it was an error it will return the default of T type in the out result and false as boolean for the method return type.

so after the call happened with success you can use the method value which is bool value Or can take the out result which is the actual data value.

Note: the extraction will be same as ExtractJsonPropertyValue<T>(string jsonProperty) extention but without exceptions.

Example:
var input = "{\"data\":[{\"baseObject\":{\"name\": \"test\", \"age\": 25 }},{\"name\":\"test2\"}]}";

var res = input.TryExtractJsonPropertyValue<int>("data[0].baseObject.age", out var result); 

result will be 25

//res value as bool and result have the actual data value depending on the T type 

************************************************************************************************************************
(8)-> yourJsonStrBody.ExtractJsonArrayPropertyValue<T>(string jsonProperty)-> This extention will extract an array values, the return type of it is IEnumerable<T> .

Example:
 var input = "{\"name\":\"John\",\"age\":30,\"cars\":[\"Ford\", \"BMW\", \"Fiat\"]}";

in this example let`s say that i want to get "cars" values which is an array.

answer:
(
var res = input.ExtractJsonArrayPropertyValue<string>("cars");
the res value will be List<string> { "Ford", "BMW", "Fiat" }
)

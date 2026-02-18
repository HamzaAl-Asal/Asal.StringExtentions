# Asal.StringExtentions

A lightweight .NET utility library that provides powerful string extensions and serialization helpers to simplify common development tasks.

---

## 📦 Installation

### Using .NET CLI
```bash
dotnet add package Asal.StringExtentions
```

### Using Package Manager Console
```powershell
Install-Package Asal.StringExtentions
```

### Using Visual Studio
1. Open **Manage NuGet Packages**
2. Search for **Asal.StringExtentions**
3. Click **Install**

---

## 🚀 Usage

After installing the package, import the namespace and call extensions directly on strings:

```csharp
using Asal.StringExtentions;

var result = "Hello@World!".ClearSpecialCharacters();
```

---

# ✨ Available Extensions

## 🔤 String Utilities

### 1. ClearSpecialCharacters(bool replaceWithSpace = false)
Removes special characters from the string.

```csharp
"Hello@World!".ClearSpecialCharacters(); 
// Output: "HelloWorld"
```

---

### 2. ClearDigits(bool replaceWithSpace = false)
Removes all digits from the string.

```csharp
"abc123".ClearDigits(); 
// Output: "abc"
```

---

### 3. Humanize()
Separates PascalCase or camelCase words.

```csharp
"HelloWorldTest".Humanize(); 
// Output: "Hello World Test"
```

---

### 4. IsValidEmail()
Checks if the string is a valid email address.

```csharp
"test@mail.com".IsValidEmail(); // true
```

---

### 5. ExtractEmails()
Extracts all valid emails from a string.

```csharp
var text = "Contact admin@test.com or support@domain.com";
var emails = text.ExtractEmails();
```

---

# 📄 JSON Extensions

### 6. ExtractJsonPropertyValue(string jsonProperty)
Extracts a property value from a JSON string using path syntax.

```csharp
var json = "{\"name\":\"John\",\"age\":30}";
var result = json.ExtractJsonPropertyValue<string>("name");
// Output: "John"
```

Nested example:
```csharp
var json = "{\"data\":[{\"baseObject\":{\"name\":\"test\",\"age\":25}}]}";
var age = json.ExtractJsonPropertyValue<int>("data[0].baseObject.age");
// Output: 25
```

Extract object:
```csharp
var obj = json.ExtractJsonPropertyValue<object>("data[0].baseObject");
```

---

### 7. TryExtractJsonPropertyValue(string jsonProperty, out T result)
Safe extraction without throwing exceptions.

```csharp
var success = json.TryExtractJsonPropertyValue<int>("data[0].baseObject.age", out var age);
// success = true, age = 25
```

---

### 8. ExtractJsonArrayPropertyValue(string jsonProperty)
Extracts array values as `IEnumerable<T>`.

```csharp
var json = "{\"cars\":[\"Ford\",\"BMW\",\"Fiat\"]}";
var cars = json.ExtractJsonArrayPropertyValue<string>("cars");
// ["Ford", "BMW", "Fiat"]
```

Supports:
- Primitive arrays
- Nested arrays
- JSONPath style queries (`items[*].id`)

---

# 🔄 XML / JSON / YAML Converters

### 9. XmlToJson()
Converts XML string to JSON.

```csharp
var xml = "<root><name>Hamza</name></root>";
var json = xml.XmlToJson();
```

---

### 10. JsonToXml()

Converts JSON string to XML.

#### ⚠️ Behavior Change (v1.7.0)
`JsonToXml()` no longer wraps the output automatically with a default `<root>` element.

If JSON already contains a root:
```csharp
var json = "{\"root\":{\"name\":\"Hamza\"}}";
var xml = json.JsonToXml(); // Correct round-trip
```

If JSON has no root:
```csharp
var json = "{\"name\":\"Hamza\"}";
var xml = json.JsonToXml("root"); // Explicit wrapping
```

Parameters:
- `deserializeRootElementName` (optional)
- `writeArrayAttribute` (default: false)
- `encodeSpecialCharacters` (default: false)

---

### 11. YamlToJson()
Converts YAML string to JSON.

```csharp
var yaml = "Id: 1\nName: Test";
var json = yaml.YamlToJson();
```

---

### 12. JsonToYaml()
Converts JSON string to YAML.

```csharp
var yaml = json.JsonToYaml();
```

---

# 🧩 Case Conversion Extensions

### 13. Slugify()
Creates SEO-friendly slugs.

```csharp
"Café Déjà Vu Example".Slugify();
// "cafe-deja-vu-example"
```

### 14. ToCamelCase()
```csharp
"hello world".ToCamelCase(); // "helloWorld"
```

### 15. ToPascalCase()
```csharp
"hello world".ToPascalCase(); // "HelloWorld"
```

### 16. ToSnakeCase()
```csharp
"hello world".ToSnakeCase(); // "hello_world"
```

### 17. ToKebabCase()
```csharp
"hello world".ToKebabCase(); // "hello-world"
```

---

# 🔐 Security Utility

### 18. CalculateMD5Checksum()
Generates an MD5 hash for the input string.

```csharp
var checksum = "hello world".CalculateMD5Checksum();
// "5eb63bbbe01eeed093cb22bb8f5acdc3"
```

---

## ⚡ Improvements in v1.7.0
- Centralized compiled Regex patterns (better performance)
- Improved JSON array extraction (supports primitives & complex objects)
- Nullable safety and reliability improvements
- Cleaner and optimized internal implementation

---

## 📊 Milestone
🎉 Over 4,500+ downloads on NuGet!

Thank you for your support 🙏

using DMNSN.Helpers.Minifier;

namespace DMNSN.Helpers.Minifer.Test
{
    public class MinifyHelpersTest
    {
        [Fact]
        public void TestHTMLMinify()
        {
            // Arrange
            string html = "<html>\n<head>\n<title>Test HTML</title>\n</head>\n<body>\n<h1>Hello, World!</h1>\n</body>\n</html>";
            string expected = "<html><head><title>Test HTML</title></head><body><h1>Hello, World!</h1></body></html>";

            // Act
            string result = MinifyHelper.HtmlMinify(html);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestJsonMinify()
        {
            // Arrange
            string json = "{\n  \"name\": \"John\",\n  \"age\": 30,\n  \"city\": \"New York\"\n}";
            string expected = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";

            // Act
            string result = MinifyHelper.JsonMinify(json);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestTextMinify()
        {
            // Arrange
            string text = "   Hello, World!   ";
            string expected = "Hello, World!";

            // Act
            string result = MinifyHelper.TextMinify(text);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestXMLMinify()
        {
            // Arrange
            string xml = "<root>\n  <element1>Value 1</element1>\n  <element2>Value 2</element2>\n</root>";
            string expected = "<root><element1>Value 1</element1><element2>Value 2</element2></root>";

            // Act
            string result = MinifyHelper.XmlMinify(xml);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
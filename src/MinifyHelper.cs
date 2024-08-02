using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace DMNSN.Helpers.Minifier
{
    public static partial class MinifyHelper
    {
        [GeneratedRegex(@">\s+<")]
        private static partial Regex HtmlWhiteSpaceRegex();
        [GeneratedRegex(@"<!--[\s\S]*?-->")]
        private static partial Regex HtmlCommentRegex();
        [GeneratedRegex(@"^\s+|\s+$", RegexOptions.Multiline)]
        private static partial Regex HtmlMultiLineRegex();

        public static string HTMLMinify(string html)
        {
            // Remove whitespace between HTML tags
            html = HtmlWhiteSpaceRegex().Replace(html, "><");
            // Remove HTML comments
            html = HtmlCommentRegex().Replace(html, "");
            // Remove whitespace at the beginning and end of each line
            html = HtmlMultiLineRegex().Replace(html, "");
            // Remove line breaks and tabs
            html = html.Replace("\r", "").Replace("\n", "").Replace("\t", "");

            return html;
        }

        public static string JsonMinify(string json)
        {
            try
            {
                var options = new JsonWriterOptions
                {
                    Indented = false,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                using var document = JsonDocument.Parse(json);
                using var stream = new MemoryStream();
                using var writer = new Utf8JsonWriter(stream, options);
                document.WriteTo(writer);
                writer.Flush();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch { return json; }
        }

        public static string TextMinify(string text)
        { return text.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim(); }

        public static string XMLMinify(string xml)
        { return XMLMinify(xml, XMLMinifierSetting.Aggressive); }

        public static string XMLMinify(string xml, XMLMinifierSetting settings)
        {
            var originalXmlDocument = new XmlDocument
            {
                PreserveWhitespace = !(settings.RemoveWhitespaceBetweenElements || settings.RemoveEmptyLines)
            };
            originalXmlDocument.Load(new MemoryStream(Encoding.UTF8.GetBytes(xml)));

            //remove comments first so we have less to compress later
            if (settings.RemoveComments)
            {
                var comments = originalXmlDocument.SelectNodes("//comment()");
                if (comments != null)
                {
                    foreach (XmlNode comment in comments)
                    { comment.ParentNode?.RemoveChild(comment); }
                }
            }

            if (settings.CloseEmptyTags)
            {
                var emptyTags = originalXmlDocument.SelectNodes("descendant::*[not(*) and not(normalize-space())]");
                if (emptyTags != null)
                {
                    foreach (XmlElement el in emptyTags)
                    { el.IsEmpty = true; }
                }
            }

            if (settings.RemoveWhitespaceBetweenElements)
            { return originalXmlDocument.InnerXml; }
            else
            {
                var minified = new MemoryStream();
                originalXmlDocument.Save(minified);

                return Encoding.UTF8.GetString(minified.ToArray());
            }
        }
    }
}

using System.IO;
namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class MethodsHelpers
    {
        public static string ToHtmlString(this TagBuilder _tagBuilder)
        {
            StringWriter _writer = new StringWriter();
            _tagBuilder.WriteTo(_writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            return _writer.ToString();
        }
    }
}

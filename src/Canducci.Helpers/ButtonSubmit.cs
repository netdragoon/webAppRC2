using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace Canducci.Helpers
{
    [HtmlTargetElement("button-submit", Attributes = ButtonLabel)]
    [HtmlTargetElement("button-submit", Attributes = ButtonCss)]
    [HtmlTargetElement("button-submit", Attributes = ButtonStyle)]
    [HtmlTargetElement("button-submit", Attributes = ButtonGlyphicon)]
    public class ButtonSubmit : TagHelper
    {
        protected const string ButtonLabel = "button-label";
        protected const string ButtonCss = "button-css";
        protected const string ButtonStyle = "button-style";
        protected const string ButtonGlyphicon = "button-glyphicon";

        [HtmlAttributeName(ButtonLabel)]
        public string Label { get; set; } = "Default";

        [HtmlAttributeName(ButtonCss)]
        public string Css { get; set; } = "";

        [HtmlAttributeName(ButtonStyle)]
        public ButtonBootstrapStyle Style { get; set; } = ButtonBootstrapStyle.None;

        [HtmlAttributeName(ButtonGlyphicon)]
        public Glyphicon Glyphicon { get; set; } = Glyphicon.None;


        protected void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("type", "submit");

            if (!string.IsNullOrEmpty(Css))
            {
                output.Attributes.Add("class", Css);
            }

            if (Style != ButtonBootstrapStyle.None)
            {
                if (output.Attributes.ContainsName("class"))
                {
                    output.Attributes.SetAttribute("class",
                        output.Attributes["class"].Value + " " +
                        EnumDescriptionItem.GetValue(Style));
                }
                else
                {
                    output.Attributes.Add("class", EnumDescriptionItem.GetValue(Style));
                }
            }
            if (Glyphicon == Glyphicon.None)
            {
                output
                    .Content
                    .SetContent(Label);
            }
            else
            {
                output
                    .Content
                    .SetHtmlContent($"<span class=\"{EnumDescriptionItem.GetValue(Glyphicon)}\"></span> {Label}");
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Render(context, output);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            if (childContent.IsEmptyOrWhiteSpace)
            {
                Render(context, output);
            }
        }
    }
}

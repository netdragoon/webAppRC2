using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace Canducci.Helpers
{
    [HtmlTargetElement("button-submit", Attributes = cButtonLabel)]
    [HtmlTargetElement("button-submit", Attributes = cButtonCss)]
    [HtmlTargetElement("button-submit", Attributes = cButtonStyle)]
    [HtmlTargetElement("button-submit", Attributes = cButtonGlyphicon)]
    [HtmlTargetElement("button-submit", Attributes = cButtonSize)]
    [HtmlTargetElement("button-submit", Attributes = cButtonDisabled)]
    public class ButtonSubmit : TagHelper
    {
        protected const string cButtonLabel = "button-label";
        protected const string cButtonCss = "button-css";
        protected const string cButtonStyle = "button-style";
        protected const string cButtonGlyphicon = "button-glyphicon";
        protected const string cButtonSize = "button-size";
        protected const string cButtonDisabled = "button-disabled";

        [HtmlAttributeName(cButtonLabel)]
        public string Label { get; set; } = "Default";

        [HtmlAttributeName(cButtonCss)]
        public string Css { get; set; } = "";

        [HtmlAttributeName(cButtonStyle)]
        public ButtonBootstrapStyle Style { get; set; } = ButtonBootstrapStyle.None;

        [HtmlAttributeName(cButtonGlyphicon)]
        public Glyphicon Glyphicon { get; set; } = Glyphicon.None;

        [HtmlAttributeName(cButtonSize)]
        public ButtonSize Size { get; set; } = ButtonSize.Default;

        [HtmlAttributeName(cButtonDisabled)]
        public bool Disabled { get; set; } = false;

        protected void MergeClass(TagHelperOutput output, object value)
        {
            if (output.Attributes.ContainsName("class"))
            {
                output.Attributes.SetAttribute("class",
                    output.Attributes["class"].Value + " " + value);
            }
            else
            {
                output.Attributes.Add("class", value);
            }
            
        }

        protected void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("type", "submit");

            if (Disabled) output.Attributes.Add("disabled","disabled");
            if (string.IsNullOrEmpty(Css) == false) MergeClass(output, Css);
            if (Style != ButtonBootstrapStyle.None) MergeClass(output, EnumDescriptionItem.GetValue(Style));
            if (Size != ButtonSize.Default) MergeClass(output, EnumDescriptionItem.GetValue(Size));

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

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections;
using System.IO;
using System.Linq;

namespace Canducci.Helpers
{
    [HtmlTargetElement("radio-button-list", Attributes = cRadioViewDataName)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioButtonList)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioCss)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioName)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioPrefix)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioSufix)]
    public class RadioButtonListTagHelper: TagHelper
    {
        protected const string cRadioViewDataName = "radio-button-viewdata-name";
        protected const string cRadioButtonList = "radio-button-list";
        protected const string cRadioCss = "radio-button-css";
        protected const string cRadioName = "radio-button-name";
        protected const string cRadioPrefix = "radio-button-prefix";
        protected const string cRadioSufix = "radio-button-sufix";
        protected const string cAspFor = "radio-button-asp-for";

        [HtmlAttributeName(cRadioViewDataName)]
        public string RadioViewDataName { get; set; } = string.Empty;

        [HtmlAttributeName(cRadioButtonList)]
        public RadioButtonList RadioButtonList { get; set; } = null;

        [HtmlAttributeName(cRadioCss)]
        public string Css { get; set; } = string.Empty;

        [HtmlAttributeName(cRadioName)]
        public string Name { get; set; } = "default";

        [HtmlAttributeName(cRadioPrefix)]
        public string Prefix { get; set; } = "<div>";

        [HtmlAttributeName(cRadioSufix)]
        public string Sufix { get; set; } = "</div>";

        [HtmlAttributeName(cAspFor)]
        public ModelExpression AspFor { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        
        protected string RenderTagBuilderImputToString(TagBuilder tagBuilder)
        {
            var writer = new StringWriter();
            tagBuilder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            return writer.ToString();
        }

        protected TagBuilder CreateTagBuilderToInput(string _id, string _name, string _value)
        {
            TagBuilder _tagInput = new TagBuilder("input");
            _tagInput.TagRenderMode = TagRenderMode.SelfClosing;
            _tagInput.MergeAttribute("id", _id);
            _tagInput.MergeAttribute("name", _name);
            _tagInput.MergeAttribute("type", "radio");
            _tagInput.MergeAttribute("value", _value);

            if (RadioButtonList.SelectedValue != null && _value.Equals(RadioButtonList.SelectedValue.ToString()))
            {
                _tagInput.MergeAttribute("checked", "checked");
            }

            return _tagInput;
        }

        protected string CreateTagBuilderToString(string prefix, TagBuilder tagInput, string name, string sufix)
        {
            return $"{prefix}<label>{RenderTagBuilderImputToString(tagInput)} {name}</label>{sufix}";
        }

        protected void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.TagMode = TagMode.StartTagAndEndTag;

            if (RadioButtonList == null)
            {
                if (ViewContext.ViewData[RadioViewDataName] != null)
                {
                    RadioButtonList = (RadioButtonList)ViewContext.ViewData[RadioViewDataName];
                }           
            }

            if (RadioButtonList == null)
            {
                throw new Exception("Configure radio-button-viewdata-name or radio-button-list, data null");
            }

            if (AspFor != null)
            {
                var AspPropName = AspFor.ModelExplorer.Model.ToString();
                var AspModelExProp = AspFor.ModelExplorer.Container.Properties.Single(x => x.Metadata.PropertyName.Equals(AspPropName));
                var AspPropValue = AspModelExProp.Model;
                var AsppropEditFormatString = AspModelExProp.Metadata.EditFormatString;
            }

            if (RadioButtonList != null)
            {
                StringBuilder _str = new StringBuilder();                          
                TagBuilder _tagInput = null;
                IEnumerator _items = RadioButtonList.Items.GetEnumerator();

                while (_items.MoveNext())
                {                    
                    Type _type = _items.Current.GetType();

                    object _value = _type.GetProperty(RadioButtonList.DataValueField).GetValue(_items.Current);
                    object _name = _type.GetProperty(RadioButtonList.DataLabelField).GetValue(_items.Current);
                    string _id = string.Format("{0}{1}", Name, _value);

                    _tagInput = CreateTagBuilderToInput(_id, Name, _value.ToString());
                    _str.AppendLine(CreateTagBuilderToString(Prefix, _tagInput, _name.ToString(), Sufix));                    
                }

                output.Content.SetHtmlContent(_str.ToString());
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

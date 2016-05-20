using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Canducci.Helpers
{
    [HtmlTargetElement("radio-button-list", Attributes = cRadioViewDataName)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioButtonList)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioCss)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioName)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioPrefix)]
    [HtmlTargetElement("radio-button-list", Attributes = cRadioSufix)]
    [HtmlTargetElement("radio-button-list", Attributes = cAspFor)]
    public class RadioButtonListTagHelper: TagHelper
    {

        #region const
        protected const string cRadioViewDataName = "radio-button-viewdata-name";
        protected const string cRadioButtonList = "radio-button-list";
        protected const string cRadioCss = "radio-button-class-css";
        protected const string cRadioName = "radio-button-name";
        protected const string cRadioPrefix = "radio-button-prefix";
        protected const string cRadioSufix = "radio-button-sufix";
        protected const string cAspFor = "radio-button-asp-for";
        protected const string cRadioStyle = "radio-button-style-css";
        #endregion const

        #region HtmlAttributeName
        [HtmlAttributeName(cAspFor)]
        public ModelExpression AspFor { get; set; }

        [HtmlAttributeName(cRadioViewDataName)]
        public string RadioViewDataName { get; set; } = string.Empty;

        [HtmlAttributeName(cRadioButtonList)]
        public RadioButtonList RadioButtonList { get; set; } = null;

        [HtmlAttributeName(cRadioCss)]
        public string ClassCss { get; set; } = string.Empty;

        [HtmlAttributeName(cRadioStyle)]
        public string StyleCss { get; set; } = string.Empty;

        [HtmlAttributeName(cRadioName)]
        public string Name { get; set; } = string.Empty;

        [HtmlAttributeName(cRadioPrefix)]
        public string Prefix { get; set; } = "<div>";

        [HtmlAttributeName(cRadioSufix)]
        public string Sufix { get; set; } = "</div>";
        #endregion HtmlAttributeName

        #region ViewContext
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        #endregion ViewContext
        
        protected TagBuilder CreateTagBuilderToInput(string _id, string _name, string _value)
        {
            TagBuilder _tagInput = new TagBuilder("input");
            _tagInput.TagRenderMode = TagRenderMode.SelfClosing;
            _tagInput.MergeAttribute("id", _id);
            _tagInput.MergeAttribute("name", _name);
            _tagInput.MergeAttribute("type", "radio");
            _tagInput.MergeAttribute("value", _value);

            if (!string.IsNullOrEmpty(ClassCss))
            {
                _tagInput.MergeAttribute("class", ClassCss);
            }

            if (!string.IsNullOrEmpty(StyleCss))
            {
                _tagInput.MergeAttribute("style", StyleCss);
            }

            if (RadioButtonList.SelectedValue != null && _value.Equals(RadioButtonList.SelectedValue.ToString()))
            {
                _tagInput.MergeAttribute("checked", "checked");
            }

            return _tagInput;
        }

        protected string CreateTagBuilderToString(string prefix, TagBuilder tagInput, string name, string sufix)
        {
            return $"{prefix}<label>{tagInput.ToHtmlString()} {name}</label>{sufix}";
        }

        protected void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.TagMode = TagMode.StartTagAndEndTag;

            if (AspFor != null)
            {
                ModelMetadata _metadata = AspFor.Metadata;

                if (_metadata != null)
                {
                    Name = _metadata?.PropertyName?.ToString();

                    if (string.IsNullOrEmpty(RadioViewDataName))
                    {
                        RadioViewDataName = Name;
                    }
                }
            }

            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(RadioViewDataName))
            {
                throw new Exception("Configure radio-button-viewdata-name or radio-button-name configure error");
            }

            if (string.IsNullOrEmpty(Name))
            {
                Name = RadioViewDataName;
            }

            if (string.IsNullOrEmpty(RadioViewDataName))
            {
                RadioViewDataName = Name;
            }            

            if (RadioButtonList == null)
            {                
                if (ViewContext.ViewData[RadioViewDataName] != null)
                {
                    RadioButtonList = (RadioButtonList)ViewContext.ViewData[RadioViewDataName];

                    if (AspFor != null && AspFor?.Model != null)
                    {
                        RadioButtonList.SelectedValue = AspFor?.Model?.ToString();
                    }
                }           
            }

            if (RadioButtonList == null)
            {
                throw new Exception("Configure radio-button-viewdata-name or radio-button-list, data null");
            }            
            
            StringBuilder _str = new StringBuilder();                          
            TagBuilder _tagInput = null;
            IEnumerator _items = RadioButtonList?.Items?.GetEnumerator();

            while (_items.MoveNext())
            {                    
                Type _type = _items.Current.GetType();
                object _value = _type.GetProperty(RadioButtonList.DataValueField).GetValue(_items.Current);
                object _name = _type.GetProperty(RadioButtonList.DataLabelField).GetValue(_items.Current);
                string _id = $"{Name}{_value}";

                _tagInput = CreateTagBuilderToInput(_id, Name, _value.ToString());
                _str.AppendLine(CreateTagBuilderToString(Prefix, _tagInput, _name.ToString(), Sufix));                    
            }

            output.Content.SetHtmlContent(_str.ToString());
            
        }

        #region ProcessAndProcessAsync
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
        #endregion ProcessAndProcessAsync
    }
}

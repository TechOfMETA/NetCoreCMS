namespace NetCoreCMS.Framework.Helpers.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    //https://stackoverflow.com/questions/58815781/the-tag-helper-input-must-not-have-c-sharp-in-the-elements-attribute-declarat/59579635#59579635
    [HtmlTargetElement(Attributes = "custom-attributes")] 
    public class CustomAttributesTagHelper : TagHelper
    {
        public object CustomAttributes { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var customAttributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(CustomAttributes);
            foreach (var (key, value) in customAttributesDictionary)
            {
                output.Attributes.SetAttribute(key, value);
            }
        }
    }
}

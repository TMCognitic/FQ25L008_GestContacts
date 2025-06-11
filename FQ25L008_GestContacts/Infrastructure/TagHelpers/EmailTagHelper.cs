using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FQ25L008_GestContacts.Infrastructure.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        private readonly string domain = "unknow.com";
        public string MailTo { get; set; } = "none";
        public string User { get; set; } = "John Doe";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            string address = MailTo + "@" + domain;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent($"POC : {User}");
        }
    }
}

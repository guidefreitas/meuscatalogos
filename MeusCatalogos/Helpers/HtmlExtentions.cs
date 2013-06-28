using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MeusCatalogos.Helpers
{
    public static class HtmlExtensions
    {


        public static MvcHtmlString Label(this HtmlHelper htmlHelper, string value, IDictionary<string, object> htmlAttributes)
        {
            var label = new TagBuilder("label");
            label.AddCssClass("control-label");
            
            if(htmlAttributes.ContainsKey("id"))
                label.Attributes.Add("id", htmlAttributes["id"].ToString());

            if (htmlAttributes.ContainsKey("for"))
                label.Attributes.Add("for", htmlAttributes["for"].ToString());
            
            if(!String.IsNullOrEmpty(value))
                label.InnerHtml = value;

            return new MvcHtmlString(label.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString HelperLabel(this HtmlHelper htmlHelper, string value)
        {
            var helperLabel = new TagBuilder("span");
            helperLabel.AddCssClass("help-inline");
            if (!String.IsNullOrEmpty(value))
                helperLabel.InnerHtml = value;
            return new MvcHtmlString(helperLabel.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString HelperLabel(this HtmlHelper htmlHelper, string value, IDictionary<string, object> htmlAttributes)
        {
            var helperLabel = new TagBuilder("span");
            if (htmlAttributes.ContainsKey("class"))
            {
                helperLabel.AddCssClass(htmlAttributes["class"].ToString());
            }
            else
            {
                helperLabel.AddCssClass("help-inline");
            }
            if (!String.IsNullOrEmpty(value))
                helperLabel.InnerHtml = value;
            return new MvcHtmlString(helperLabel.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString TextField(this HtmlHelper htmlHelper, string value)
        {
            var control = new TagBuilder("input");
            control.Attributes.Add("type", "text");
            
            if (!String.IsNullOrEmpty(value))
            {
                control.InnerHtml = value;
            }
            return new MvcHtmlString(control.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString Field(this HtmlHelper htmlHelper, string value, IDictionary<string, object> htmlAttributes)
        {
            var control = new TagBuilder("input");

            if (htmlAttributes.ContainsKey("type"))
            {
                control.Attributes.Add("type", htmlAttributes["type"].ToString());
            }
            else
            {
                control.Attributes.Add("type", "text");
            }

            if (htmlAttributes.ContainsKey("id"))
                control.Attributes.Add("id", htmlAttributes["id"].ToString());

            if (htmlAttributes.ContainsKey("placeholder"))
                control.Attributes.Add("placeholder", htmlAttributes["placeholder"].ToString());

            if(!String.IsNullOrEmpty(value)){
                control.InnerHtml = value;
            }
            return new MvcHtmlString(control.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Form(this HtmlHelper htmlHelper)
        {
            var form = new TagBuilder("form");
            form.AddCssClass("form-horizontal");
            return new MvcHtmlString(form.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ControlGroup(this HtmlHelper htmlHelper,string klass = "control-group")
        {
            var group = new TagBuilder("div");
            group.AddCssClass(klass);
            return new MvcHtmlString(group.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string id, string value, string klass = "btn", string type = "submit")
        {
            var button = new TagBuilder("button");
            button.AddCssClass(klass);
            button.Attributes.Add("type", type);
            return new MvcHtmlString(button.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Control(this HtmlHelper htmlHelper, string displayName, string message)
        {
            var control = new TagBuilder("div");
            control.AddCssClass("controls");

            return new MvcHtmlString(control.ToString(TagRenderMode.Normal));
            
        }

        public static MvcHtmlString AuthButton(this HtmlHelper htmlHelper, string providerName, string displayName)
        {
            //<button type="submit" class="btn" name="provider" value="@p.AuthenticationClient.ProviderName" title="Log in using your @p.DisplayName account"><i class="icon-google"></i> @p.DisplayName</button>
            var button = new TagBuilder("button");
            button.AddCssClass("btn");
            button.Attributes.Add("type", "submit");
            button.Attributes.Add("name", "provider");
            button.Attributes.Add("value", providerName);
            button.Attributes.Add("title", string.Format("Log in using your {0} account", displayName));

            var text = "";
            const string textPlaceholder = "<i class=\"{0}\"></i> {1}";
            switch (providerName)
            {
                case "google":
                    text = string.Format(textPlaceholder, "icon-google", displayName);
                    break;
                case "facebook":
                    text = string.Format(textPlaceholder, "icon-facebook", displayName);
                    break;
                case "twitter":
                    text = string.Format(textPlaceholder, "icon-twitter", displayName);
                    break;
                case "microsoft":
                    text = string.Format(textPlaceholder, "icon-microsoft", displayName);
                    break;
                default:
                    text = "";
                    break;
            }

            button.InnerHtml = text;

            return new MvcHtmlString(button.ToString(TagRenderMode.Normal));
        }
    }
}
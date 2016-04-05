using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_HTML_Dispatcher
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string source, string alt, string title)
        {
            ElementBuilder img = new ElementBuilder("img");
            img.AddAttribute("src", source);
            img.AddAttribute("alt", alt);
            img.AddAttribute("title", title);

            return img.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder a = new ElementBuilder("a");
            a.AddAttribute("href", url);
            a.AddAttribute("title",title);
            a.AddContent(text);

            return a.ToString();
        }

        public static string CreateInput(string inputType, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAttribute("type", inputType);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);

            return input.ToString();
        }
    }
}

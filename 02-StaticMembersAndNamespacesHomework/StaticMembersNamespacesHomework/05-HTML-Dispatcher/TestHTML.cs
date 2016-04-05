using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_HTML_Dispatcher
{
    class TestHTML
    {
        static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");
            // Console.WriteLine(div);
            div.AddAttribute("class", "links");
            //Console.WriteLine(div);
            div.AddAttribute("id", "soft");
            div.AddAttribute("href", "www.soft.bg");
            //Console.WriteLine(div);
            div.AddContent("Soft");
            //Console.WriteLine(div);
            Console.WriteLine(div * 3);

           string img =  HTMLDispatcher.CreateImage("stef.jpeg", "alt", "bolqr");
           Console.WriteLine(img);

           string link = HTMLDispatcher.CreateURL("www.bolqr.bg", "bolqrbolqr!", "bolqra");
           Console.WriteLine(link);

           string inputTag = HTMLDispatcher.CreateInput("text", "username", "user");
           Console.WriteLine(inputTag);
        }
    }
}

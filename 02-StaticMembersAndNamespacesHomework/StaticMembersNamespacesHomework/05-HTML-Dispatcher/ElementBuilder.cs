using System;
using System.Collections.Generic;
using System.Linq;


namespace _05_HTML_Dispatcher
{
    class ElementBuilder
    {
        private string name;
        private string attribute;
        private string content = "";

        public ElementBuilder(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Element name can't be null or empty");
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public void AddAttribute(string attribute, string value)
        {
            this.attribute += " " + attribute + "=\"" + value + "\"";
        }

        public void AddContent(string contentToAdd)
        {
            this.content += contentToAdd;
        }

        public static string operator *(ElementBuilder element, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += element + "\n";
            }
            return result;
        }

        public override string ToString()
        {
            return String.Format("<{0}{1}>{2}</{0}>", this.name, this.attribute, this.content);
        }

    }
}

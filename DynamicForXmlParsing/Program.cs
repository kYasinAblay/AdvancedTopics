using System;
using System.Dynamic;
using System.Xml.Linq;

namespace DynamicForXmlParsing
{
    public class DynamicXmlNode : DynamicObject
    {
        private XElement node;

        public DynamicXmlNode(XElement node)
        {
            this.node = node;
        }

        public dynamic This => this;
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var element = node.Element(binder.Name);
            if (element != null)
            {
                result = new DynamicXmlNode(element);
                return true;

            }
            else
            {
                var attribute = node.Attribute(binder.Name);
                if (attribute != null)
                {
                    result = attribute.Value;
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }

        }
            }
    internal class Program
    {
        static void Main(string[] args)
        {
            var xml = @"<people>
                <person name='Dimitri' lastname='Nesteruk' />
                </people>";
            var node = XElement.Parse(xml);
            var name = node.Element("person").Attribute("name");
            Console.WriteLine(name?.Value);

            //x.persone.name//Really Short Man!
            dynamic dyn = new DynamicXmlNode(node);
            Console.WriteLine(dyn.person.name);
            Console.WriteLine(dyn.person.lastname);
        }
    }
}

using System;
using System.Xml;

namespace ANN
{
    public abstract class SaveableObject
    {
        protected SaveableObject () { }

        public SaveableObject (XmlNode data)
        {

        }

        abstract public void Save (XmlWriter writer);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Configuration;
using System.Xml;

//Hey, here's an example of how to use custom configuration elements in a console application.  Isn't that fucking great?
//See http://stackoverflow.com/questions/19095215/configurationmanager-getsection-gives-error-could-not-load-type-from-assembl
//See http://msdn.microsoft.com/en-us/library/2tw134k3%28v=vs.140%29.aspx

namespace Dojo_ConsoleApp.CustomConfigSections
{
    // Define a custom section containing an individual 
    // element and a collection of elements.
    public class MyCustomConfigHandler : ConfigurationSection
    {
        // Create a "remoteOnly" attribute.
        [ConfigurationProperty("remoteOnly", DefaultValue = "false", IsRequired = false)]
        public Boolean RemoteOnly
        {
            get
            {
                return (Boolean)this["remoteOnly"];
            }
            set
            {
                this["remoteOnly"] = value;
            }
        }

        // Create a "font" element.
        [ConfigurationProperty("font")]
        public FontElement Font
        {
            get
            {
                return (FontElement)this["font"];
            }
            set
            { this["font"] = value; }
        }

        // Create a "color element."
        [ConfigurationProperty("color")]
        public ColorElement Color
        {
            get
            {
                return (ColorElement)this["color"];
            }
            set
            { this["color"] = value; }
        }
        //Create a "stupid" element.
        [ConfigurationProperty("stupid")]
        public StupidElement Stupid {
            get
            {
                return (StupidElement)this["stupid"];
            }
            set
            { this["stupid"] = value; }
        
        } 
    }

    // Define the "font" element
    // with "name" and "size" attributes.
    public class FontElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "Arial", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("size", DefaultValue = "12", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 24, MinValue = 6)]
        public int Size
        {
            get
            { return (int)this["size"]; }
            set
            { this["size"] = value; }
        }
    }

    // Define the "color" element 
    // with "background" and "foreground" attributes.
    public class ColorElement : ConfigurationElement
    {
        [ConfigurationProperty("background", DefaultValue = "FFFFFF", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\GHIJKLMNOPQRSTUVWXYZ", MinLength = 6, MaxLength = 6)]
        public String Background
        {
            get
            {
                return (String)this["background"];
            }
            set
            {
                this["background"] = value;
            }
        }

        [ConfigurationProperty("foreground", DefaultValue = "000000", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\GHIJKLMNOPQRSTUVWXYZ", MinLength = 6, MaxLength = 6)]
        public String Foreground
        {
            get
            {
                return (String)this["foreground"];
            }
            set
            {
                this["foreground"] = value;
            }
        }
    }
    //Define the "stupid" element
    //with  "idot" and "crap" attributes
    public class StupidElement : ConfigurationElement 
    {
        [ConfigurationProperty("idiot", DefaultValue = "dumb", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\GHIJKLMNOPQRSTUVWXYZ", MinLength = 4, MaxLength = 12)]
        public String idiot
        {
            get
            {
                return (String)this["idiot"];
            }
            set
            {
                this["idiot"] = value;
            }
        }
    }
}

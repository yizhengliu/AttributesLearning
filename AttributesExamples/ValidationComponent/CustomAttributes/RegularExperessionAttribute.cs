using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationComponent.CustomAttributes
{
    //declare attribute usage
    //must match specified pattern
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter
        | AttributeTargets.Property, AllowMultiple = false)]
    public class RegularExperessionAttribute:Attribute
    {
        public string ErrorMessage {  get; set; }
        public string Pattern {  get; set; }

        public RegularExperessionAttribute(string pattern) 
        {
            Pattern = pattern;
            ErrorMessage = "Field, {0}, is invalid. The value provided does not match the declared regular expression pattern, {1}";
        }

        public RegularExperessionAttribute(string pattern, string errorMessage)
        {
            Pattern = pattern;
            ErrorMessage = errorMessage;
        }
    }
}

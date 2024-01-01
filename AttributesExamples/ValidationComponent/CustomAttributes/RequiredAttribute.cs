using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//when this is declared the associated input field must not be empty
namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field |  AttributeTargets.Parameter 
        | AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute:Attribute
    {
        public string ErrorMessage {  get; set; }

        public RequiredAttribute() 
        {
            ErrorMessage = "You cannot leave field, {0}, empty";
        }

        public RequiredAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationComponent.CustomAttributes
{
    //must in between string length specified
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter
        | AttributeTargets.Property, AllowMultiple = false)]
    public class StringLengthAttribute:Attribute
    {
        public int MaxLength { get; set; }

        public string ErrorMessage {  get; set; }

        public int MinLength { get; set; }

        public StringLengthAttribute(int maxLength) => SetProperties(maxLength);

        public StringLengthAttribute(int maxLength, string errorMessage) => SetProperties(maxLength, errorMessage);

        public StringLengthAttribute(int maxLength, int minLength) => SetProperties(maxLength, minLength: minLength);//we need to note the method that we are assigning the minLength variable

        public StringLengthAttribute(int maxLength, string errorMessage, int minLength) => SetProperties(maxLength, errorMessage, minLength);//we need to note the method that we are assigning the minLength variable

        private void SetProperties( int maxLength,
                                    string errorMessage = "", 
                                    int? minLength = null) //nullable
        {
            if (errorMessage == "")//set default value for ErrorMessage property
            {
                if (minLength == null)
                {
                    ErrorMessage = "The character length for field, {0}, must not exceed {1}";
                }
                else
                {
                    ErrorMessage = "Field, {0}, cannnot have a character length that is less than {2} or a character length greater than {1}";
                }
            }
            else 
            {
                ErrorMessage = errorMessage;
            }

            MaxLength = maxLength;
            MinLength = minLength == null ? 0 : minLength.Value;
        }
    }
}

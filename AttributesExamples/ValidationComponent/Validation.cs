using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ValidationComponent
{
    public class Validation
    {
        //calling relevant validation code, Type represents the type contains the properties
        public static bool PropertyValueIsValid(Type t, string enteredValue, string elementName, out string errorMessage) 
        {
            PropertyInfo prop = t.GetProperty(elementName);//reference to the property
            Attribute[] attributes = prop.GetCustomAttributes().ToArray();
            errorMessage = "";
            foreach (Attribute attr in attributes) 
            {
                //swtich pattern matching for reference of the object
                switch (attr) 
                {
                    case ValidationComponent.CustomAttributes.RequiredAttribute ra:
                        if (!FieldRequiredIsValid(enteredValue)) //if is null or empty
                        {
                            errorMessage = ra.ErrorMessage;
                            errorMessage = string.Format(errorMessage, prop.Name);
                            return false;
                        }
                        break;
                    case ValidationComponent.CustomAttributes.StringLengthAttribute sla:
                        if (!FieldStringLengthIsValid(sla, enteredValue)) //
                        {
                            errorMessage = sla.ErrorMessage;
                            errorMessage = string.Format(errorMessage, prop.Name, sla.MaxLength, sla.MinLength);
                            return false;
                        }
                        break;
                    case ValidationComponent.CustomAttributes.RegularExperessionAttribute rea:
                        if (!FieldPatternMatchIsValid(rea, enteredValue))
                        {
                            errorMessage = rea.ErrorMessage;
                            errorMessage = string.Format(errorMessage, prop.Name, rea.Pattern);
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        private static bool FieldRequiredIsValid(string enteredValue) 
        {
            if (!string.IsNullOrEmpty(enteredValue))
                return true;//valid
            return false;//invalid
        }

        private static bool FieldStringLengthIsValid(ValidationComponent.CustomAttributes.StringLengthAttribute stringLengthAttribute, string enteredValue)
        {
            if (enteredValue.Length >= stringLengthAttribute.MinLength &&
                enteredValue.Length <= stringLengthAttribute.MaxLength)
                return true;//valid
            return false;//invalid
        }

        private static bool FieldPatternMatchIsValid(ValidationComponent.CustomAttributes.RegularExperessionAttribute regularExpressionAttribute, string enteredValue)
        {
            if (Regex.IsMatch(enteredValue, regularExpressionAttribute.Pattern))
                return true;//valid
            return false;//invalid
        }
    }
}

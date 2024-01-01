using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationComponent.CustomAttributes;
using System.Text.Json.Serialization;
namespace AttributesExamples.Models
{
    public class Employee
    {
        [ValidationComponent.CustomAttributes.Required]
        public int Id { get; set; }

        [ValidationComponent.CustomAttributes.Required]
        [ValidationComponent.CustomAttributes.StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in the length", 2)]
        public string FirstName { get; set; }

        [ValidationComponent.CustomAttributes.Required]
        [ValidationComponent.CustomAttributes.StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in the length", 2)]
        public string LastName { get; set; }

        [ValidationComponent.CustomAttributes.Required]
        [ValidationComponent.CustomAttributes.StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in the length", 2)]
        [RegularExperession("\t\r\n^\\s*\\(?(020[7,8]{1}\\)?[ ]?[1-9]{1}[0-9{2}[ ]?[0-9]{4})|(0[1-8]{1}[0-9]{3}\\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{3})\\s*$")]
        //[JsonIgnore]
        public string PhoneNumber {  get; set; }

        [ValidationComponent.CustomAttributes.Required]
        [ValidationComponent.CustomAttributes.StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in the length", 2)]
        [RegularExperession("^((([!#$%&'*+\\-/=?^_`{|}~\\w])|([!#$%&'*+\\-/=?^_`{|}~\\w][!#$%&'*+\\-/=?^_`{|}~\\.\\w]{0,}[!#$%&'*+\\-/=?^_`{|}~\\w]))[@]\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)$")]
        public string EmailAddress { get; set; }

        [ValidationComponent.CustomAttributes.Required]
        [ValidationComponent.CustomAttributes.StringLength(15, "Field, {0}, cannot exceed {1} characters in length and cannot be less than {2} characters in the length", 2)]
        [RegularExperession("^[A-Za-z]{1,2}[0-9A-Za-z]{1,2}[ ]?[0-9]{0,1}[A-Za-z]{2}$")]
        //[JsonIgnore]//when print the info of the employee ignore this field
        public string Postcode {  get; set; }
    }
}

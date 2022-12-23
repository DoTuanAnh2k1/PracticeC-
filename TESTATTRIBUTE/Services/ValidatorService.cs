using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTATTRIBUTE
{
    public class ValidatorService
    {
        public static IDictionary<string, List<string>> Validate(Object obj)
        {
            IDictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
                foreach (var attribute in attributes)
                {
                    if (attribute is not ValidationAttribute validationAttribute)
                    {
                        continue;
                    }
                    var valid = validationAttribute.IsValid(property.GetValue(obj));

                    if (!valid)
                    {
                        validationAttribute.ErrorMessage = validationAttribute.FormatErrorMessage(property.Name);
                        var value = result.ContainsKey(property.Name) ? result[property.Name] : null;

                        if (value != null)
                        {
                            value.Add(validationAttribute.ErrorMessage);
                            result.Remove(property.Name);
                            result.Add(property.Name, value);
                        }
                        else
                        {
                            List<string> errors = new List<string>();
                            errors.Add(validationAttribute.ErrorMessage);
                            result.Add(property.Name, errors);
                        }
                    }
                }
            }

            return result;
        }
    }
}

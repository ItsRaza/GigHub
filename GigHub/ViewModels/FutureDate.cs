using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureDate:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;
            bool isValid=DateTime.TryParseExact(Convert.ToString(value), 
                "dd MMM yyyy", 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out dt);
            return (isValid && dt > DateTime.Now);
        }
    }
}
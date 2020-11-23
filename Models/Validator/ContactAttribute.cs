using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Validator
{
    public class BookingAttribute : ValidationAttribute
    {
        override
        protected ValidationResult IsValid(object value, ValidationContext context)
        {
            Booking b = (Booking)value;
            ValidationResult vs = ValidationResult.Success;
            if(!(b.ZipCode.Length == 5))
            {
                return new ValidationResult("The Zip Code entered is not valid");
            }

            return vs;

        }
    }
}

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
            if(b.ZipCode == null || !(b.ZipCode.Length == 5))
            {
                return new ValidationResult("The Zip Code entered is not valid");
            }
            //Add an address validation api
            if(b.TimeStart < DateTime.Now.AddDays(7))
            {
                return new ValidationResult("Please book over 7 days in advance. If you have any questions, please call");
            }

            if(b.TimeEnd < b.TimeStart)
            {
                return new ValidationResult("Please input a valid time frame");
            }

            if(b.TimeEnd.Date != b.TimeStart.Date)
            {
                return new ValidationResult("You cannot currently book items online for more than one day. For multiday bookings, please call");
            }

            return vs;

        }
    }
}

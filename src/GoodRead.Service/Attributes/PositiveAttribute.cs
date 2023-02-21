﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PositiveAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var price = (float)value!;

            if (price < 0)
                return new ValidationResult($"Price is a positive number!");

            return ValidationResult.Success;
        }
    }
}

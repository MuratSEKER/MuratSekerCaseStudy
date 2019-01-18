using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MuratSekerCaseStudy.Models;

namespace MuratSekerCaseStudy.Validations
{
    public class ValidateFileAttribute: RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null)
            {
                return false;
            }
            return true;
        }
    }
}

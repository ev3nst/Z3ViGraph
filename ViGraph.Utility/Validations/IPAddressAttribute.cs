using System;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace ViGraph.Utility.Validations
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class IPAddressAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			ValidationResult result = ValidationResult.Success;
			string[] memberNames = new string[] { validationContext.MemberName };

            string ipAddress = (string)validationContext.ObjectInstance;
            IPAddress parsedIP;
            bool isValidIP = IPAddress.TryParse(ipAddress, out parsedIP);
            if(isValidIP) {
				result = new ValidationResult(string.Format(this.ErrorMessage, 400), memberNames);
            }

			return result;
		}
	}
}
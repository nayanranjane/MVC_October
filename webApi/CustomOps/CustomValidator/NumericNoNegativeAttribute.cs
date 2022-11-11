
using System.ComponentModel.DataAnnotations;
namespace webApi.CustomOps.CustomValidator
{
    public class NumericNoNegtiveAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (Convert.ToInt32(value) < 0) return false;
            return true;
        }
    }
}

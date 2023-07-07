using System;
using System.Net.Mail;

namespace RetailCloud.Api.Utils.Validate
{
    public static class EmailValidatorPrimitive
    {
        public static bool IsValid(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public static class EmailValidate
    {
        public static ResultValidation execute(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new ResultValidation(false, "Почта не должна быть пустой");
            }

            if (!EmailValidatorPrimitive.IsValid(email))
            {
                return new ResultValidation(false, "Неверный формат почты");
            }


            return new ResultValidation(true);
        }
    }
}
using System.Text.RegularExpressions;

namespace RetailCloud.Api.Utils.Validate
{
    public static class KppValidate
    {
        /// <summary>
        /// проверка КПП по регулярному выражению
        /// </summary>
        /// <param name="kpp">КПП для проверки</param>
        /// <returns></returns>
        public static ResultValidation execute(string kpp)
        {
            return new Regex(@"\d{4}[\dA-Z][\dA-Z]\d{3}").IsMatch(kpp)
                ? new ResultValidation(true)
                : new ResultValidation(false, "Проверьте ваш КПП на валидность");
        }
    }
}
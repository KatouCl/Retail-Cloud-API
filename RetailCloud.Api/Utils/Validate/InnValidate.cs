using System;

namespace RetailCloud.Api.Utils.Validate
{
    public static class InnValidate
    {
        /// <summary>
        /// Проверка корректности ИНН, представленного в виде строки
        /// За основу взят алгоритм http://www.rsdn.ru/Forum/Message.aspx?mid=647880
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ResultValidation execute(string value)
        {
            if (value.Length == 11)
            {
                if (value[0] != 'F')
                    return new ResultValidation(false);
                else
                    value = value.Remove(0, 1);
            }

            // должно быть 10 или 12 цифр
            if (!(value.Length == 10 || value.Length == 12))
                return new ResultValidation(false);
            else
            {
                try
                {
                    return execute(long.Parse(value));
                }
                catch
                {
                    return new ResultValidation(false);
                }
            }
        }

        /// <summary>
        /// Проверка корректности ИНН, представленного в виде числа
        /// За основу взят алгоритм http://www.rsdn.ru/Forum/Message.aspx?mid=647880
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ResultValidation execute(long value)
        {
            // должно быть 10 или 12 цифр
            if (value < 1000000000 || value >= 1000000000000)
                return new ResultValidation(false);

            int digits = (int) Math.Log10(value) + 1;
            if (!(digits == 10 || digits == 12))
                return new ResultValidation(false);

            // вычисляем контрольную сумму
            string s = value.ToString("D" + digits.ToString());
            int[] factors = digits == 10 ? arrMul10 : arrMul122;

            startCheck:

            long sum = 0;
            for (int i = 0; i < factors.Length; i++)
                sum += byte.Parse(s[i].ToString()) * factors[i];
            sum %= 11;
            sum %= 10;
            if (sum != byte.Parse(s[factors.Length].ToString()))
                return new ResultValidation(false);
            else if (digits == 12)
            {
                // используется маленький трюк:
                // запускается повторная проверка, начиная с метки startCheck,
                // но с другими коэффициентами, а чтобы исключить повторный вход 
                // в эту ветку, сбрасываем digits
                factors = arrMul121;
                digits = 0;
                goto startCheck;
            }
            else
                return new ResultValidation(true);
        }

        #region Коффициенты для проверки ИНН (метод IsINN)

        static readonly int[] arrMul10 = {2, 4, 10, 3, 5, 9, 4, 6, 8};
        static readonly int[] arrMul121 = {7, 2, 4, 10, 3, 5, 9, 4, 6, 8};
        static readonly int[] arrMul122 = {3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8};

        #endregion Коффициенты для проверки ИНН (метод IsINN)
    }
}
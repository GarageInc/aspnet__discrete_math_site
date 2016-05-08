using System;
using System.Collections.Generic;

namespace WebApplication.Service.auto_generating_mathtasks
{
    public class UnambiguousDecodingService
    {

        // Функция, которая генерирует декодируюмую строку и код для неё
        public static string GetDecodingCodeAndCode()
        {
            Random r = new Random();
            List<string> res = new List<string>();

            // Количество последовательностей
            var count = r.Next(3, 14);

            // Генерируем последовательности
            int i = 0;
            for (i = 0; i < count; i++)
            {
                string s = "";
                var length = r.Next(1, 10);
                for (int j = 0; j < length; j++)
                {
                    s += r.Next(1, 100) % 2;
                }
                res.Add(s);
            }

            string result = "";

            // Теперь склеиваем их в результат - кодовая строка типа 00110 000 1110 11 0 00101 0....
            for (i = 0; i < count - 1; i++)
            {
                result += res[i] + " ";
            }

            result += res[i];
            result += " / ";

            // Теперь сгенерируем код
            count = r.Next(3, 10);
            for (i = 0; i < count; i++)
            {
                result += res[r.Next(0, res.Count)];
            }

            return result;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Service.auto_generating_mathtasks
{
    public class PrefixCodeService
    {

        // Расшифровать, декодируется ли однозначно данная последовательность заданным кодом
        public static string CheckIsDecodedByCode(int level)
        {
            Random r = new Random();
            List<string> res = new List<string>();

            // Количество последовательностей
            var count = r.Next(level + 2, (level + 2) * 4);

            // Генерируем последовательности
            int i = 0;
            for (i = 0; i < count; i++)
            {
                var length = r.Next(level + 2, (level + 2) * 4);

                res.Add(length.ToString());
            }

            string result = "L={";

            // Теперь склеиваем их в результат - кодовая строка типа 00110 000 1110 11 0 00101 0....
            for (i = 0; i < count - 1; i++)
            {
                result += res[i] + ", ";
            }

            result += res[i];

            return result + "}";
        }


        // Проверка правильности строки
        public static ReturnResult CheckString02(string reply, string generated)
        {
            try
            {
                bool yes = true;
                string error = "";
                // Если есть - вернём ошибку
                var res = reply.Split(' ').ToList();
                for (int i = 0; i < res.Count && yes; i++)
                {
                    for (int j = 0; j < res.Count && yes; j++)
                    {
                        if (j != i)
                        {
                            // Если какая-то строка является окончанием другой - это не хорошо
                            if (res[i].EndsWith(res[j]))
                            {
                                error = "[" + res[i] + "]" + " & " + "[" + res[j] + "]";
                                yes = false;
                            }
                        }
                    }
                }

                if (yes)
                    return new ReturnResult(true, "Абсолютно верное решение! Строка однозначно декодируется");

                return new ReturnResult(false, "Нет, строка неоднозначно декодируема. Не удовлетворяют свойству Фано часть: " + error);

            }
            catch (Exception e)
            {
                return new ReturnResult(false, "Ошибка ввода! " + e.Message);
            }
        }
    }
}
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
            int count = level == 1 ? r.Next(2, 6) : r.Next(6, 10);

            // Генерируем последовательности
            int i = 0;
            for (i = 0; i < count; i++)
            {
                int length;

                if (level == 1)
                    length = r.Next(2, 4);
                else
                    length = r.Next(5, 8);

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
        public static string CheckString02(string reply, string generated)
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
                    return "Абсолютно верное решение! Строка однозначно декодируется";

                return "Нет, строка неоднозначно декодируема. Не удовлетворяют свойству Фано: " + error;

            }
            catch (Exception e)
            {
                return "Ошибка ввода! " + e.Message;
            }
        }
    }
}
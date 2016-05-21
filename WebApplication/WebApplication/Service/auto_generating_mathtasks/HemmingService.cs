using System;
using System.Linq;

namespace WebApplication.Service.auto_generating_mathtasks
{
    public class HemmingDTO
    {
        public int numberError;
        public int[] code;

        public HemmingDTO(int[] code, int numberError)
        {
            this.numberError = numberError;
            this.code = code;
        }
    }
    public class HemmingService
    {
        public static Random Rand = new Random();

        public static HemmingDTO Generate(int level)
        {
            int length = (level + 10) *3;

            int controlBits = Convert.ToInt32(Math.Ceiling(Math.Log(length, 2))) + 1;// (log2n) + 1
            int totalBits = length + controlBits;

            int[] array = new int[totalBits + 1]; // массив всех бит
            int[] array_Error = new int[totalBits + 1];// массив для генерации ошибки
            
            //int k;
            //генерация сообщений
            gen_message(array, totalBits);

            // устанавливаем контрольные биты на нужные позиции
            double l = 0;// степень двойки
            int k = 0;
            // Отсчет от 1 и по всем битам
            for (int j = 1; j < totalBits + 1; j++)
            {
                k = Convert.ToInt32(Math.Pow(2, l));
                if (j == k)
                {
                    l++;
                    continue;
                }
            }

            zeroing(array, totalBits);// обнуляем контрольные биты

            //вычисление контрольных битов
            l = 0;
            for (int j = 1; j < totalBits + 1; j++)
            {
                k = Convert.ToInt32(Math.Pow(2, l));
                if (j == k)
                {
                    array[j] = getControlBits(array, k, totalBits);
                    l++;
                }
                array_Error[j] = array[j];
            }

            //	Нахождение значений контрольных бит

            //генерируем ошибку в случайном месте
            int error = 0;

            gen_error(array_Error, totalBits, ref error);

            if (array[error] == 0)
                array[error] = 1;
            else
                array[error] = 0;


            return new HemmingDTO(array, error);
        }


        public static ReturnResult CheckCode(string generated, int number)
        {
            var array_Error = generated.Select(ch => ch - '0').ToArray();
            int[] array = new int[array_Error.Length];

            for (int j = 0; j < array_Error.Length; j++)
            {
                array[j] = array_Error[j];
            }

            int totalBits = array.Length - 1;
            int k = 0;
            double l = 0;// степень двойки

            //исправление ошибки
            //заново обнуление контрольных битов
            zeroing(array_Error, totalBits);

            l = 0;
            //вычисление новых бит
            for (int j = 1; j < totalBits + 1; j++)
            {
                k = Convert.ToInt32(Math.Pow(2, l));
                if (j == k)
                {
                    array_Error[j] = getControlBits(array_Error, k, totalBits);
                    l++;
                }
            }

            for (int j = 0; j < array_Error.Length; j++)
            {
                if (array[j] != array_Error[0])
                {
                    if (number == j)
                    {
                        return new ReturnResult(true, "Абсолютно верно!");
                    }
                    else
                    {
                        return new ReturnResult(false, "Неверно! Контрольный бит находится на позиции: " + j);
                    }
                }
                
            }

            return new ReturnResult(false, "Случилась неведомая ошибка, попробуйте снова?");
        }

        // функция генерации сообщения
        public static void gen_message(int[] array, int TotalBits)
        {
            int n;

            for (int i = 1; i < TotalBits + 1; i++)
            {
                n = Rand.Next() % 2;
                array[i] = n;
            }
        }

        // функция обнуления контрольных бит
        public static void zeroing(int[] array, int TotalBits)
        {
            double l = 0;
            int k;
            for (int j = 1; j < TotalBits + 1; j++)
            {
                k = Convert.ToInt32(Math.Pow(2, l));
                if (j == k)
                {
                    array[j] = 0;
                    l++;
                }
            }
        }
        // функция вычисления контрольных бит
        public static int getControlBits(int[] array, int k, int TotalBits)
        {
            int value = 0;// кол-во единиц
            int kol = 0;// контролирует длину каждого блока
            int i = k;// позиция поиска, с какого места считаем
            while (i < TotalBits + 1)// для поиска от позиции и до конца
            {
                while (kol < k && i < TotalBits + 1)//контролирует, чтобы прошел блок от контрольного бита и не вышел за границу массива
                {
                    if (array[i] == 1)// подсчет кол-ва единиц в блоке
                        value++;
                    kol++;
                    i++;
                }
                i = i + k;// перескакивает ненужные биты
                kol = 0;// обнуляется длина блока, снова подсчет единиц в новом блоке
            }
            if (value % 2 == 0)// если четное число единиц
                return 0;
            return 1;
        }
        // функция генерации ошибки
        public static void gen_error(int[] array_error, int TotalBits, ref int error)
        {
            int i = Rand.Next(1, TotalBits + 1);
            while (i == 1 || i == 2 || i == 4 || i == 8 || i == 16 || i == 32 || i == 64 || i == 128)
            {
                i = Rand.Next(1, TotalBits + 1);
            }
            if (array_error[i] == 0)
                array_error[i] = 1;
            else array_error[i] = 0;
            error = i;
        }

    }
}
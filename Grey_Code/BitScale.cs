// импортируем вспомогательные пространства имён
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grey_Code
{
    class BitScale
    {
        // массив байтов - именно здесь хранится битовое представление подмножеств
        byte[] bitScale;
        // массив целых чисел - натуральное представление множества, подмножества которого мы будем генерировать
        int[] baseSet;

        // Инициализируем поля класса
        public void Init(int[] baseSet)
        {
            this.baseSet = baseSet;
            this.bitScale = new byte[baseSet.Length];
        }

        // Гернерируем подмножества с помощью алгоритма Грея
        public Subset[] BuildSubsets()
        {
            // Вычисляем число подмножеств
            int subsetsNumber = (int)Math.Pow(2, bitScale.Length) - 1;

            // создаем необходимое количество массивов для подмножеств
            Subset[] subsets = new Subset[subsetsNumber];

            for (int i = 1; i <= subsetsNumber; i++)
            {
                // вычисляем количество двоек в разложении числа на множители
                int numberOfTwos = BitScale.CalcNumberFrequencyInFactorOut(i, 2) + 1;

                // вычисляем значение соответствующего бита
                bitScale[bitScale.Length - numberOfTwos] = (byte)(1 - bitScale[bitScale.Length - numberOfTwos]);

                // превращаем массив битов в строку из нулей и единиц
                string bitScaleString = BitScaleToString();

                // создаём класс подмножества - он пригодится нам в дальнейшем для вывода информации о подмножестве
                Subset subset = new(i, bitScaleString, GetSubsetFromBitScale(bitScaleString));

                subsets[i-1] = subset;
            }

                
            return subsets;
        }

        // превращаем массив битов в строку из нулей единиц
        private string BitScaleToString()
        {
            string[] bits = BitConverter.ToString(bitScale)
                .Split('-')
                .Select(bit => int.Parse(bit).ToString())
                .ToArray();

            return String.Join("", bits);
        }

        // используя битовую шкалу в качестве маски, с ее помощью вычисляем сооттветствующее
        // ей подмножество на основе исходного множества
        private int[] GetSubsetFromBitScale(string bitScaleString)
        {
            List<int> subset = new();

            // если соответствующий бил равен единице, включаем цифру исходного множества в подмножество
            for (int i = 0; i < baseSet.Length; i++)
            {
                if (bitScaleString[i] == '1')
                {
                    subset.Add(baseSet[i]);
                }
            }

            return subset.ToArray();
        }

        // подсчитываем количество двоек в разложении числа на множители
        private static int CalcNumberFrequencyInFactorOut(int numberToFactorOut, int number = 2)
        {
            int baseNumber = numberToFactorOut;
            int frequency = 0;

            // делим число на двойку столько раз, сколько это получится сделать без остатка
            // это количество и является частотой двойки в разложении
            while (baseNumber % number == 0)
            {
                baseNumber /= number;
                frequency++;
            }

            return frequency;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grey_Code
{
    class BitScale
    {
        byte[] bitScale;
        int[] baseSet;

        public void Init(int[] baseSet)
        {
            this.baseSet = baseSet;
            this.bitScale = new byte[baseSet.Length];
        }

        public Subset[] BuildSubsets()
        {
            int subsetsNumber = (int)Math.Pow(2, bitScale.Length) - 1;

            Subset[] subsets = new Subset[subsetsNumber];

            for (int i = 1; i <= subsetsNumber; i++)
            {
                int numberOfTwos = BitScale.CalcNumberFrequencyInFactorOut(i, 2) + 1;

                bitScale[bitScale.Length - numberOfTwos] = (byte)(1 - bitScale[bitScale.Length - numberOfTwos]);

                string bitScaleString = BitScaleToString();

                Subset subset = new(i, bitScaleString, GetSubsetFromBitScale(bitScaleString));

                subsets[i-1] = subset;
            }

                
            return subsets;
        }

        private string BitScaleToString()
        {
            string[] bits = BitConverter.ToString(bitScale)
                .Split('-')
                .Select(bit => int.Parse(bit).ToString())
                .ToArray();

            return String.Join("", bits);
        }

        private int[] GetSubsetFromBitScale(string bitScaleString)
        {
            List<int> subset = new();

            for (int i = 0; i < baseSet.Length; i++)
            {
                if (bitScaleString[i] == '1')
                {
                    subset.Add(baseSet[i]);
                }
            }

            return subset.ToArray();

            // mock
            // return "1489";
        }

        /**
         * Calculate frequency of particular number in some number's factor out
         */
        private static int CalcNumberFrequencyInFactorOut(int numberToFactorOut, int number = 2)
        {
            int baseNumber = numberToFactorOut;
            int frequency = 0;

            while (baseNumber % number == 0)
            {
                baseNumber /= number;
                frequency++;
            }

            return frequency;
        }
    }
}

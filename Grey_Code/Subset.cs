using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grey_Code
{
    class Subset
    {
        public int index { get; set; }
        public string bitScale { get; set; }
        public int[] realSubset;
        public string RealSubset
        { 
            get
            {
                return String.Join("", realSubset.Select(item => item.ToString()).ToArray()); 
            }
        }

        public Subset(int index, string bitScale, int[] realSubset)
        {
            this.index = index;
            this.bitScale = bitScale;
            this.realSubset = realSubset;
        }
    }
}

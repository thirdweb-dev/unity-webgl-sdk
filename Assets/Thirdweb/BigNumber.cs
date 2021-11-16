using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using UnityEngine;

namespace Thirdweb
{
    [System.Serializable]
    public class BigNumber
    {
        public string type;
        public string hex;

        public BigInteger ToBigInteger()
        {
            return BigInteger.Parse(this.hex.Replace("0x", ""), NumberStyles.AllowHexSpecifier);
        }

        public string ToHexString()
        {
            return hex;
        }

        public int ToInt()
        {
            return int.Parse(hex.Replace("0x", ""), NumberStyles.AllowHexSpecifier);
        }
    }
}
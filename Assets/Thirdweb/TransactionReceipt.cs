using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thirdweb
{
    [System.Serializable]
    public class TransactionReceipt
    {
        public string from;
        public string to;
        public string transactionHash;
        public string blockHash;
    }
}
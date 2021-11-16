using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Thirdweb
{
    [System.Serializable]
    public struct CurrencyMetadata
    {
        public string name;
        public string symbol;
        public int decimals;
    }

    [System.Serializable]
    public struct CurrencyValueMetadata
    {
        public string name;
        public string symbol;
        public int decimals;
        public string displayValue;
        public string value;
    }

    public class Currency : Module
    {
        public Currency(SDK sdk, Bridge bridge, string address) : base(sdk, bridge, address, "currency")
        {
        }

        public async Task<CurrencyMetadata> Get()
        {
            return await bridge.InvokeRoute<CurrencyMetadata>(MakeRoute("get"), new string[0]);
        }

        public async Task<CurrencyValueMetadata> Balance()
        {
            return await bridge.InvokeRoute<CurrencyValueMetadata>(MakeRoute("balance"), new string[0]);
        }
        public async Task<CurrencyValueMetadata> BalanceOf(string account)
        {
            return await bridge.InvokeRoute<CurrencyValueMetadata>(MakeRoute("balanceOf"), new string[1] { account });
        }

        public async Task<TransactionReceipt> Transfer(string to, BigInteger amount)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("transfer"), new string[2] { to, amount.ToString() });
        }

        public async Task<TransactionReceipt> TransferFrom(string from, string to, BigInteger amount)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("transferFrom"), new string[3] { from, to, amount.ToString() });
        }

        public async Task<TransactionReceipt> Burn(BigInteger amount)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("burn"), new string[1] { amount.ToString() });
        }

        public async Task<TransactionReceipt> SetAllowance(string spender, BigInteger amount)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("setAllowance"), new string[2] { spender, amount.ToString() });
        }

        public async Task<BigInteger> TotalSupply()
        {
            return (await bridge.InvokeRoute<BigNumber>(MakeRoute("totalSupply"), new string[0])).ToBigInteger();
        }
    }
}
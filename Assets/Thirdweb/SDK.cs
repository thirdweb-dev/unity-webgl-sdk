using System.Collections.Generic;
using UnityEngine;

namespace Thirdweb
{
    public class SDK : MonoBehaviour
    {
        private Bridge bridge;
        private Dictionary<string, Currency> currencyModules = new Dictionary<string, Currency>();
        private Dictionary<string, NFT> nftModules = new Dictionary<string, NFT>();
        private Dictionary<string, Market> marketModules = new Dictionary<string, Market>();

        private void Start()
        {
            bridge = GetComponent<Bridge>();
        }

        public Currency GetCurrency(string address)
        {
            if (!currencyModules.ContainsKey(address))
            {
                currencyModules[address] = new Currency(this, this.bridge, address);
            }

            return currencyModules[address];
        }

        public NFT GetNFT(string address)
        {
            if (!nftModules.ContainsKey(address))
            {
                nftModules[address] = new NFT(this, this.bridge, address);
            }

            return nftModules[address];
        }

        public Market GetMarket(string address)
        {
            if (!marketModules.ContainsKey(address))
            {
                marketModules[address] = new Market(this, this.bridge, address);
            }

            return marketModules[address];
        }
    }
}
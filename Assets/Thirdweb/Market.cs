using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using UnityEngine;

namespace Thirdweb
{

    [System.Serializable]
    public struct ListingMetadata
    {
        public string id;
        public string currencyContract;
        public CurrencyMetadata currencyMetadata;
        public BigNumber price;
        public BigNumber quantity;
        public string seller;
        public string tokenContracat;
        public string tokenId;
        public NFTMetadata tokenMetadata;
        // TODO support startDate, endDate
    }

    public class Market : Module
    {
        public Market(SDK sdk, Bridge bridge, string address) : base(sdk, bridge, address, "market")
        {
        }

        public async Task<ListingMetadata> Get(string listingId)
        {
            return (await bridge.InvokeRoute<ListingMetadata>(MakeRoute("get"), new string[1] { listingId }));
        }

        public async Task<ListingMetadata[]> GetAll()
        {
            return (await bridge.InvokeRoute<ListingMetadata[]>(MakeRoute("getAll"), new string[0]));
        }

        public async Task<ListingMetadata> Buy(string listingId, BigInteger quantity)
        {
            return (await bridge.InvokeRoute<ListingMetadata>(MakeRoute("buy"), new string[2] { listingId, quantity.ToString() }));
        }

        public async Task<ListingMetadata> List(string assetContract, string tokenId, string currencyContract, BigInteger price, BigInteger quantity,
            BigInteger tokensPerBuy = new BigInteger(), BigInteger secondsUntilStart = new BigInteger(), BigInteger secondsUntilEnd = new BigInteger())
        {
            return (await bridge.InvokeRoute<ListingMetadata>(MakeRoute("list"), new string[8] {
                assetContract, tokenId, currencyContract, price.ToString(), quantity.ToString(),
                tokensPerBuy.ToString(), secondsUntilStart.ToString(), secondsUntilEnd.ToString()
            }));
        }

        public async void Unlist(string listingId, BigInteger quantity)
        {
            await bridge.InvokeRouteRaw(MakeRoute("unlist"), new string[2] { listingId, quantity.ToString() });
        }

        public async void UnlistAll(string listingId)
        {
            await bridge.InvokeRouteRaw(MakeRoute("unlistAll"), new string[1] { listingId });
        }
    }
}
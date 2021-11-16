using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using UnityEngine;

namespace Thirdweb
{
    [System.Serializable]
    public struct NFTMetadata
    {
        public string id;
        public string uri;
        public string description;
        public string image;
        public string name;
        // TODO: support properties;
    }

    [System.Serializable]
    public struct NFTMetadataOwner
    {
        public NFTMetadata metadata;
        public string owner;
    }


    public class NFT : Module
    {
        public NFT(SDK sdk, Bridge bridge, string address) : base(sdk, bridge, address, "nft")
        {
        }

        public async Task<NFTMetadata> Get(string tokenId)
        {
            return await bridge.InvokeRoute<NFTMetadata>(MakeRoute("get"), new string[1] { tokenId });
        }

        public async Task<NFTMetadataOwner> GetWithOwner(string tokenId)
        {
            return await bridge.InvokeRoute<NFTMetadataOwner>(MakeRoute("getWithOwner"), new string[1] { tokenId });
        }

        public async Task<NFTMetadata[]> GetAll()
        {
            return await bridge.InvokeRoute<NFTMetadata[]>(MakeRoute("getAll"), new string[0]);
        }

        public async Task<NFTMetadataOwner[]> GetAllWithOwner()
        {
            return await bridge.InvokeRoute<NFTMetadataOwner[]>(MakeRoute("getAllWithOwner"), new string[0]);
        }

        public async Task<NFTMetadata[]> GetOwned(string address = "")
        {
            return await bridge.InvokeRoute<NFTMetadata[]>(MakeRoute("getOwned"), new string[1] { address });
        }
        public async Task<string> OwnerOf(string tokenId)
        {
            return (await bridge.InvokeRoute<string>(MakeRoute("ownerOf"), new string[1] { tokenId }));
        }

        public async Task<BigInteger> Balance()
        {
            return (await bridge.InvokeRoute<BigNumber>(MakeRoute("balance"), new string[0])).ToBigInteger();
        }

        public async Task<BigInteger> BalanceOf(string address)
        {
            return (await bridge.InvokeRoute<BigNumber>(MakeRoute("balanceOf"), new string[1] { address })).ToBigInteger();
        }

        public async Task<BigInteger> TotalSupply()
        {
            return (await bridge.InvokeRoute<BigNumber>(MakeRoute("totalSupply"), new string[0])).ToBigInteger();
        }

        public async Task<TransactionReceipt> Burn(string tokenId)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("burn"), new string[1] { tokenId });
        }

        public async Task<TransactionReceipt> Transfer(string to, string tokenId)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("transfer"), new string[2] { to, tokenId });
        }

        public async Task<TransactionReceipt> TransferFrom(string from, string to, string tokenId)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("transferFrom"), new string[3] { from, to, tokenId });
        }

        public async Task<TransactionReceipt> SetApproval(string tokenId, bool approved = true)
        {
            return await bridge.InvokeRoute<TransactionReceipt>(MakeRoute("setApproval"), new string[2] { tokenId, approved.ToString() });
        }
    }
}
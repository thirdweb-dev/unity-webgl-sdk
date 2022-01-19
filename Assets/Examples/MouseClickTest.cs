using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace ThirdwebDemo
{
    public class MouseClickTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public async void CheckSomethingFun()
        {
            /*
            var metadata = await sdk.GetCurrency("0x56cf9a7992134B789856Ace00229444Cd7337A87").Get();
            Debug.LogFormat("Unity onClick1!! {0} {1} {2}", metadata.name, metadata.symbol, metadata.decimals);

            var jmetadata = await sdk.GetCurrency("0x56cf9a7992134B789856Ace00229444Cd7337A87").Balance();
            Debug.LogFormat("Unity onClick3!! {0} {1} {2} {3} {4}", jmetadata.name, jmetadata.symbol, jmetadata.decimals, jmetadata.displayValue, jmetadata.value);

            var vmetadata = await sdk.GetCurrency("0x56cf9a7992134B789856Ace00229444Cd7337A87").BalanceOf("0xbC0895f9d50dDcAD909f7089Fc642E59006a9460");
            Debug.LogFormat("Unity onClick2!! {0} {1} {2} {3} {4}", vmetadata.name, vmetadata.symbol, vmetadata.decimals, vmetadata.displayValue, vmetadata.value);

            var tsply = await sdk.GetCurrency("0x56cf9a7992134B789856Ace00229444Cd7337A87").TotalSupply();
            Debug.LogFormat("Unity total supply!! {0} {1}", tsply, tsply.ToString());
            */

            /*
            var transferTo = "0xbC0895f9d50dDcAD909f7089Fc642E59006a9460";
            var transferAmount = BigInteger.Multiply(1, BigInteger.Pow(10, 18));
            sdk.GetCurrency("0x56cf9a7992134B789856Ace00229444Cd7337A87").Transfer(transferTo, transferAmount);
            */
                        
            // access the thirdweb sdk component however your project is setup!
            Thirdweb.SDK sdk = GameObject.FindWithTag("thirdweb").GetComponent<Thirdweb.SDK>();

            var nfts = await sdk.GetNFT("0x025b435B5ba354c9d0C8772cc36aDEE3957f2A6D").GetAllWithOwner();
            foreach (var n in nfts)
            {
                Debug.LogFormat("NFT: {0} {1} {2} {3}", n.owner, n.metadata.name, n.metadata.description, n.metadata.image);
            }

            var listings = await sdk.GetMarket("0x8bf2A315fA33F92d9313477202CDcD65e4f6D67b").GetAll();
            foreach (var n in listings)
            {
                Debug.LogFormat("NFT: {0} {1} {2} {3} {4}", n.id, n.seller, n.tokenMetadata.name, n.tokenMetadata.description, n.tokenMetadata.image);
                if (n.id.Equals("0"))
                {
                    await sdk.GetMarket("0x8bf2A315fA33F92d9313477202CDcD65e4f6D67b").Buy("0", 1);
                }
            }

        }
    }
}


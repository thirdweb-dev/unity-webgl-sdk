using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Thirdweb
{
    public class SDK : MonoBehaviour
    {
        private Bridge bridge;
        public Currency currency { get; private set; }

        private void Start()
        {
            bridge = GetComponent<Bridge>();
            currency = new Currency(this, bridge);
        }

        [System.Serializable]
        private struct CheckLoggedInMsg
        {
            public bool result;
        }

        public async void CheckLoggedIn()
        {
            var msg = await bridge.InvokeRoute("thirdweb.logged_in", "{}");
            var loggedInMsg = JsonUtility.FromJson<CheckLoggedInMsg>(msg);
            Debug.LogFormat("logged in message: {0}", msg);
            Debug.LogFormat("logged in: {0}", loggedInMsg.result);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thirdweb
{
    public class Currency
    {
        private Bridge bridge;
        private SDK sdk;

        public Currency(SDK sdk, Bridge bridge)
        {
            this.sdk = sdk;
            this.bridge = bridge;
        }
    }
}

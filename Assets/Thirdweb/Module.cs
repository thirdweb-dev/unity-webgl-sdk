using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thirdweb
{
    public class Module
    {
        protected Bridge bridge;
        protected SDK sdk;
        protected string address;
        private string moduleName;

        protected internal Module(SDK sdk, Bridge bridge, string address, string moduleName)
        {
            this.sdk = sdk;
            this.bridge = bridge;
            this.address = address;
            this.moduleName = moduleName;
        }

        protected string MakeRoute(string functionName)
        {
            return "thirdweb." + moduleName + "." + address + "." + functionName;
        }
    }
}
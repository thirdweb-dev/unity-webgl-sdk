# Unity SDK (WebGL)

The SDK requires Message Bridge setup in the website.

## Installation
### In the Unity project:
1. Download the unitypackage from https://github.com/nftlabs/unity-webgl/releases
2. In your Project, Right click -> Import Package -> Custom Package. Select the unitypackage that you downloaded from (1).
3. Include the **`Thirdweb` prefab** in your scene. https://github.com/nftlabs/unity-webgl/tree/master/Assets/Thirdweb
4. Access the Thirdweb SDK however you want! An example use case of the SDK: https://github.com/nftlabs/unity-webgl/blob/master/Assets/Examples/MouseClickTest.cs


### In the web project:
```
npm install @3rdweb/sdk @3rdweb/unity-bridge
```
1. In your web app, initialize ThirdwebBridgeSDK: https://github.com/nftlabs/unity-webgl-template/blob/master/src/App.tsx#L11
```javascript
// replace RPC url to the correct network RPC url
const bridge = new ThirdwebBridgeSDK("https://rpc-mumbai.maticvigil.com")
```
2. Create UnityInstance in the window context for message bridging: https://github.com/nftlabs/unity-webgl-template/blob/master/src/App.tsx#L20-L30
```javascript
const interval = setInterval(() => {
  if (window.createUnityInstance) {
    clearInterval(interval);
    window.createUnityInstance(canvasRef.current, window.unityConfig)
      .then((unityInstance) => {
        window.unityInstance = unityInstance;
      });
   }
}, 500);
```
3. After connecting wallet, update the ThirdwebBridgeSDK signer whenever a signer is available: https://github.com/nftlabs/unity-webgl-template/blob/master/src/App.tsx#L45-L50
```javascript
const signer = provider.getSigner();
bridge.setProviderOrSigner(signer);
```
4. Your C# Unity SDK can now make authenticated SDK function calls like transferring asset or buying asset.

### See Also: Example Unity WebGL Website
https://github.com/nftlabs/unity-webgl-template

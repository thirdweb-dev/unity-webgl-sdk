# Unity SDK (WebGL)

The SDK requires Message Bridge setup in the website.

## Installation
### In the Unity project:
1. Clone this Unity SDK project. Copy `Assets/Thirdweb` into your project.
2. Include the **`Thirdweb` prefab** in your project / scene. https://github.com/nftlabs/unity-webgl/tree/master/Assets/Thirdweb
3. Access the Thirdweb SDK however you want! An example use case of the SDK: https://github.com/nftlabs/unity-webgl/blob/master/Assets/Examples/MouseClickTest.cs


### In the web project:
```
npm install @3rdweb/sdk @3rdweb/unity-bridge
```
1. In your web app, initialize ThirdwebBridgeSDK: https://github.com/nftlabs/unity-webgl-template/blob/master/src/App.tsx#L11
2. Create UnityInstance in the window context for message bridging: https://github.com/nftlabs/unity-webgl-template/blob/master/src/App.tsx#L20-L30
3. Update the ThirdwebBridgeSDK signer whenever a signer is available: https://github.com/nftlabs/unity-webgl-template/blob/master/src/App.tsx#L45-L50
4. Unity SDK is now authenticated with the signer!

### See Also: Example Unity WebGL Website
https://github.com/nftlabs/unity-webgl-template

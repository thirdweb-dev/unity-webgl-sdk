# DEPRECATED - Unity SDK now lives in [https://github.com/thirdweb-dev/unity-sdk](https://github.com/thirdweb-dev/unity-sdk)

## Installation

### In the Unity project:
1. Download the unitypackage from https://github.com/thirdweb-dev/unity-webgl/releases
2. In your Project, Right click -> Import Package -> Custom Package. Select the unitypackage that you downloaded from (1).
3. Include the **`Thirdweb` prefab** in your scene. https://github.com/thirdweb-dev/unity-webgl/tree/master/Assets/Thirdweb
4. Access the Thirdweb SDK however you want! An example use case of the SDK: https://github.com/thirdweb-dev/unity-webgl/blob/master/Assets/Examples/MouseClickTest.cs


### In the web project:
```
npm install @3rdweb/sdk @3rdweb/unity-bridge
```
1. In your web app, initialize ThirdwebBridgeSDK: https://github.com/thirdweb-dev/unity-webgl-template/blob/master/src/App.tsx#L11
```javascript
// replace RPC url to the correct network RPC url
const bridge = new ThirdwebBridgeSDK("https://rpc-mumbai.maticvigil.com")
```
2. Create UnityInstance in the window context for message bridging: https://github.com/thirdweb-dev/unity-webgl-template/blob/master/src/App.tsx#L20-L30
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
3. After connecting wallet, update the ThirdwebBridgeSDK signer whenever a signer is available: https://github.com/thirdweb-dev/unity-webgl-template/blob/master/src/App.tsx#L45-L50
```javascript
const signer = provider.getSigner();
bridge.setProviderOrSigner(signer);
```
4. Your C# Unity SDK can now make authenticated SDK function calls like transferring asset or buying asset.

### See Also: Example Unity WebGL Website
https://github.com/thirdweb-dev/unity-webgl-template

# Local Development

## Running the `unity-webgl` project

1. Open project
2. Expand the `Assets` folder
3. Open the `Scenes` dropdown
4. Open the `Sample Scene`
5. Click `File` -> `Build Settings
6. Choose `WebGl`
7. Click `Buid and run` at the bottom right of the popup dialog

## Updating the template project

> Assumes the `unity-webgl-template` and `unity-webgl` folders are in the
> same directory

```bash
$ cd unity-webgl-template
$ yarn run build
$ cd unity-webgl
$ rm -rf Assets/WebGLTemplates/Thirdweb/*
$ cp -r ../unity-webgl-template/* Assets/WebGLTemplates/Thirdweb
```

## Exporting the `unity-webgl` project

1. Collapse the `Assets` folder
2. Right click the `Thirdweb` asset
3. Click `Export Package...`
4. **Uncheck everything and only select the `Thirdweb` folders**
5. Name the file `ThirdwebSDK`

This outputs a `.unitypackage` file that can be distributed to WebGL developers
which they can use to import and use the bridge.

## Releasing new versions

Publish new releases [here](https://github.com/thirdweb-dev/unity-webgl/releases)

You can uypload the `.unitypackage` file directly to Github for distribution

### Project structure

- `unity-webgl`: Project that contains all the Thirdweb C# methods that can be called within games, builds and packages the plugin
- `unity-webgl-template`: A template WebGL project that is used in the `unity-webgl` project as a template scene
- `unity-webgl-bridge`: Used to setup a communication channel between the WebGL canvas and the C# unity game

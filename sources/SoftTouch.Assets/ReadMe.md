# Asset system design


## Main design ideas

Should be able to load :

1. image and mesh assets
2. unique assets
3. assets composed of many assets
4. embedded resources (image in a gltf)

## How to

The asset system works offline, during game compilation. The idea is to read all yaml files describing the assets and offer a way to import them.

Then the asset compiler will serialize them using MessagePack and put them into a zip file.

During runtime, the ContentManager will load elements based on the data serialized. Meaning that a texture will get serialized into bytes during compilation, read as a Texture object with its description and a Handle to the GPU asset.
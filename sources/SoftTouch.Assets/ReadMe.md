# Asset system design


## Main design ideas

Should be able to load :

1. image and mesh assets
2. unique assets
3. assets composed of many assets
4. embedded resources (image in a gltf)

## How to

The asset system works offline, during game compilation. The idea is to read all yaml files describing the assets and offer a way to import them.

Then the asset compiler will serialize them using MemoryPack and put them into a zip file.

During runtime, the ContentManager will load elements based on the data serialized. Meaning that a texture will get serialized into bytes during compilation, read as a Texture object with its description and a Handle to the GPU asset.

## Use case

Steps : 
1. User call resource manager to import given a path
2. Resource manager check path, gives it to the importer that is responsible for the file/extension
3. Importer generates an asset item, containing import information.
4. When the user calls the resource manager to load an asset given an asset path, 
	1. the resource manager will check that asset item 
	2. Load the data using the given importer

Importing an asset and loading a data are 2 different things.
Stride does it by having an AssetImporter for assets and a AssetImporterCommand for the data itself.

The resource manager should make sure the asset and the data is loaded only once.

### GLTF

0. Asset compilation phase
1. Compiler lists all asset files `*.st*` in the asset directories specified.
2. For each asset files marked as `should be loaded`, importers are called to create an asset database.
3. In this database, if a file is describing a model with a path for a gltf file
5. Resource manager :
	1. Query file
	2. Check if file is gltf
	3. Retrieves its GltfFileSystem
	4. Call importer

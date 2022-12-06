# Some notes about what i understood of rendering

* We have to instanciate data on the gpu (vertex buffers, textures, samplers)
* After instanciating those values we can bind them to shaders by creating bind groups
* Each shader has its own bind group layout but every shader can share every bound values
* A texture needs a texture view to be accessible by a shader
* I can create multiple command queues to draw many things in parallel
* Resources are stored in a sort of GPU heap and can be reused by other command queues
* I can make a render graph to "better manage rendering"? Needs to be searched

## Rendering techniques

Rendering is seen as a 3 part processus :

0. Geometry pre-pass (optional)
1. Light assignation/culling
2. Shading

### Forward rendering

First renderer technique used was Forward renderer, the idea is to :

0. Compute a depth buffer pre-pass
1. Vertex shading phase for transform and other vertices operations
2. Compute light per model per lights

Pros :

* Fast
* Can handle transparency
* A single pass (meaning there's only one shader pipeline launched per meshes per light)
* low bandwith issues


cons :

* Too many draw calls (nb light * nb meshes)
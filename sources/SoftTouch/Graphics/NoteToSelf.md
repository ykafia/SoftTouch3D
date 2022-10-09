# Some notes about what i understood of rendering

* We have to instanciate data on the gpu (vertex buffers, textures, samplers)
* After instanciating those values we can bind them to shaders by creating bind groups
* Each shader has its own bind group layout but every shader can share every bound values
* A texture needs a texture view to be accessible by a shader
* I can create multiple command queues to draw many things in parallel
* Resources are stored in a sort of GPU heap and can be reused by other command queues
* I can make a render graph to "better manage rendering"? Needs to be searched

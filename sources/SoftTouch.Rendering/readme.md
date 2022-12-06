# some notes

The mesh buffer + textures become global resources. They need a specific name (maybe constructed with handles ?).

A render pass should generate its shader module based on a collection of shaders. For a first try, the resources will have arbitrary names, the shader is only the WGSL one.

# Rendering

Render commands should be represented as a directed acyclic graph. Each node is a render pass with input/read resources and output/write resources.
A graph is generated every frames depending the state of the world (gather and extract?), resources are allocated per frame (prepare?) or can be reused (like the swapchain texture) and finally the command queues are generated and sent to draw.

The graph should be used to group render passes that are independent of each other.


## Render graph steps

For each graphics nodes :
1. Allocate transient textures needed for the current node
2. compile shader + generate module
3. Generate and execute command queue

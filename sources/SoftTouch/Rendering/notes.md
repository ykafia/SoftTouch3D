# Rendering

Render commands should be represented as a directed acyclic graph. Each node is a render pass with input/read resources and output/write resources.
A graph is generated every frames depending the state of the world (gather and extract?), resources are allocated per frame (prepare?) or can be reused (like the swapchain texture) and finally the command queues are generated and sent to draw.

The graph should be used to group render passes that are independent of each other.

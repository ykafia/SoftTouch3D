# SoftTouch3D

A C# game engine prototype heavily inspired from Stride.
Might serve as a prototype for new Stride features.

## Design principles

* Simple
* Modular
* Data-driven rendering

## Features

### Asset system

* Binary serialization :
  * MemoryPacker.
  * `coffret` asset tool for asset management and compilation.
* JSON serialization :
  * SpanJson.

### Graphics

Rendering done in WGPU with wgsl. In the future, it will use SDSL (Stride shader language).

### ECS

A simple Entity-Component-System implementation with performance in mind (Very not performant at the moment).

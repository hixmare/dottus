# Dottus: Object Oriented OpenGL Approach

## Overview
Dottus is a high-level, object oriented library that works over modern OpenGL (OpenTK) to bring an easier way to work with computer graphics.

This repository is divided in three projects (.csproj): 
- **Dottus.Core:** The heart of the project. Library that provides all the abstract classes for working with graphics and games - NET Standard 2.0
- **Dottus.Core.Tests:** Contains all the unit tests (NUnit) for the core library (**WIP**) - NET Core 2.1
- **Dottus.Runner:** Console application runner that is intended to contain app samples for the core library - NET Core 2.1

## Using
This repository provides both the solution (.sln) and the project (.csproj) files. The project files use the new csproj format.

To use the core library you need to add the reference to your project's csproj file:

1. Navigate to your project's folder and type in the console:
   
    `dotnet add reference <path-to-core-csproj>`
2. Open your project's csproj file and add the following into an `ItemGroup` element:

    `<ProjectReference Include="<path-to-core-csproj>"/>`
3. **(WIP)** Add the nuget package reference for the core library (may not be up-to-date)

You can add content and samples to the runner, but don't modify the Program.cs file if isn't needed

## Basic game setup

1. Add a reference to OpenTK
2. Add a reference to the core library
3. Create a Game class based on OpenTK's GameWindow (recommended to search a tutorial for this)
4. Add a `VertexAttributeArray` (VAO), a `GraphicsBuffer` (VBO) and a `ShaderProgram` in a way they are accessible from the Game's render method

The buffer holds a reference to the persistently mapped buffer. It's initial size is 1024 units (bytes), and is doubled every time it reaches its limit. It is a generic buffer, so you can add whatever data you want to it; you are responsible on managing the data you add to the buffer. The buffer works with a cursor; you can read, write and seek.

```cs
/* Target is obligatory, storage flags and access mask are not */
Buffer = new GraphicsBuffer(BufferTarget.ArrayBuffer);
/* You can write bytes or struct data, and get a handle index */
var h1 = Buffer.Write(Byte.MaxValue);
var h2 = Buffer.Write(Vector3.One);
var h3 = Buffer.Write(new [] { Vector3.Zero, Vector3.One });
/* Override data */
Buffer.Seek(h2);
Buffer.Write(Vector3.Zero);
/* Return to 0 */
Buffer.Seek(0);
/* And read the data, or just take a peek */
var b = Buffer.Read()
var v = Buffer.Read<Vector3>(out var advanced);
var vm = Buffer.Peek<Vector3>(2, out var _); // Take care, this is a Span<T>
```

The vertex array holds the description of the data you are passing to the shaders, so the core library provides the `VertexDescriptor` attribute so you can describe how your data is organized in a certain struct. Take this example:

```cs
/* 2D vertex, no transparency. Color3 doesn't actually exists in the core library */
/* First is the type you want to use as stride, usually the type itself. The other types are the offset */
[VertexDescriptor(
    typeof(Vector2Color3),
    typeof(Vector2), typeof(Color3))]
public struct Vector2Color3 
{
    public Vector2 Position { get; }
    public Color3 Color { get; }

    public Vector2Color3(Vector2 pos, Color3 color)
    {
        Position = pos;
        Color = color;
    }
}
```
And then you can create a vertex array like this:
```cs
Array = new VertexAttributeArray(Buffer, typeof(Vector2Color3).DescribeVertexAttributes());
```

The shaders are pretty straight-forward:
```cs
Program = new ShaderProgram(new []{
    new Shader(ShaderType.VertexShader, vertSource),
    new Shader(ShaderType.FragmentShader, fragSource),
});
```

    Note 1: You need to Array.EnableAttributes() every time your Buffer is resized or reallocated, so the new location is visible for the vertex array.

    Note 2: The OpenGL object id is actually protected internal, and there are no methods for drawing or exposing any of they attributes yet (they will be implemented soon). The recommended way to get it working is to inherit the corelib classes and provide methods.
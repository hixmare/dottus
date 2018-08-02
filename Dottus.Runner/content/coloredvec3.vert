#version 430 core

in vec3 inPos;
in vec4 inColor;

out vec4 outColor;

void main() 
{
    gl_Position = vec4(inPos, 1.0); 
    outColor = inColor; 
}

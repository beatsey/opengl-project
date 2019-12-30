#version 330 core

layout(location = 0) in vec3 pos;
layout(location = 1) in vec2 texcoords;

uniform mat4 PVM;
uniform vec3 cameraRight;
uniform vec3 cameraUp;
uniform vec3 billboardPos;
uniform float size;

out vec2 _texcoords;

void main() {
    _texcoords = texcoords;
    gl_Position = PVM * vec4(billboardPos + size * (cameraRight * pos.x + cameraUp * pos.y),1);
}
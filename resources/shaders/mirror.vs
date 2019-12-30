#version 330 core

layout(location = 0) in vec3 pos;

out vec4 _pos;

uniform mat4 PVM;

void main() {
    _pos = gl_Position = PVM * vec4(pos, 1);
}
#version 330 core
layout(location = 0) in vec3 pos;

out vec3 TexCoords;

uniform mat4 PVM;

void main() {
    TexCoords = pos;
    gl_Position = PVM * vec4(pos, 1);
}
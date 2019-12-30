#version 330 core

layout(location = 0) in vec3 pos;
layout(location = 1) in vec2 TexCoords;
layout(location = 2) in vec3 normal;

out vec2 _TexCoords;
out vec3 _normal;
out vec3 _position;

uniform mat4 model;
uniform mat4 PVM;

void main() {
    _normal = mat3(transpose(inverse(model))) * normal;
    _position = vec3(model * vec4(pos, 1.0));
    _TexCoords = TexCoords;
    gl_Position = PVM * vec4(pos, 1);
}
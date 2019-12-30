#version 330 core

layout(location = 0) in vec3 pos;
layout(location = 1) in vec2 texCoords;
layout(location = 2) in vec3 normal;
layout(location = 3) in vec3 tangent;
layout(location = 4) in vec3 bitangent;

out vec2 _texCoords;
out vec3 _pos;
out mat3 TBN;
out vec4 light_Position;

uniform mat4 PV;
uniform mat4 lightPV;
uniform mat4 model;

void main() {
   vec4 FragPos4 = model * vec4(pos, 1);

   vec3 T = normalize(vec3(model * vec4(tangent,   0.0)));
   vec3 B = normalize(vec3(model * vec4(bitangent, 0.0)));
   vec3 N = normalize(vec3(model * vec4(normal,    0.0)));
   TBN = mat3(T, B, N);

    gl_Position = PV * FragPos4;
    light_Position = lightPV * FragPos4;

    _pos = FragPos4.xyz;
    _texCoords = texCoords;
}
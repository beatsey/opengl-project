#version 330 core
layout(location = 0) in vec3 pos;
layout(location = 1) in vec3 normal;

out vec3 _normal;
out vec3 _pos;
out vec4 light_Position;

// Values that stay constant for the whole mesh.
uniform mat4 PV;
uniform mat4 lightPV;
uniform mat4 model;

void main() {
    vec4 FragPos4 = model * vec4(pos, 1);

    gl_Position = PV * FragPos4;
    light_Position = lightPV * FragPos4;

    _normal = normal;
    _pos = pos;
}
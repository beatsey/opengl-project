#version 330 core

in vec2 _TexCoords;
in vec3 _normal;
in vec3 _position;

out vec4 FragColor;

uniform samplerCube skybox;
uniform vec3 cameraPos;

void main()
{
    vec3 I = normalize(_position - cameraPos);
    vec3 R = reflect(I, normalize(_normal));

    vec4 skycolor = vec4(0.9*texture(skybox, R).rgb,1);

    FragColor = skycolor;
}
#version 330 core

in vec2 _TexCoords;
in vec3 _normal;
in vec3 _position;

out vec4 FragColor;

uniform samplerCube skybox;

uniform vec3 cameraPos;
uniform float refractRatio;

void main()
{
    float ratio = 1.00 / refractRatio;
    vec3 I = normalize(_position - cameraPos);
    vec3 R = refract(I, normalize(_normal), ratio);
    
    vec4 skycolor = vec4(0.9*texture(skybox, R).rgb,1);

    FragColor = skycolor;
}
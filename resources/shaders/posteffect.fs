#version 330 core
in vec2 _texcoord;

out vec4 FragColor;

uniform sampler2D colorTexture;
uniform float border;

const vec3 factor = vec3(0.27, 0.59, 0.12);

vec3 filter(in vec2 _texcoord) {
  return vec3(dot(factor, texture(colorTexture, _texcoord).rgb));
}

void main(void)
{
  vec3 color = _texcoord.x < border ? filter(_texcoord) : texture(colorTexture, _texcoord).rgb;

  FragColor = vec4(color, 1.0);
}
#version 330 core

in vec2 _texcoords;

out vec4 FragColor;

uniform sampler2D texture1;

void main(){
	FragColor = texture(texture1,_texcoords);
	if(FragColor.a<1)discard;
}
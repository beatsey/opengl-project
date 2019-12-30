#version 330 core

in vec4 _pos;

out vec4 FragColor;

uniform sampler2D texture1;

#define PCF 5 // radius of texels to average from
void main(){

    vec2 unproj2D = vec2 (_pos.x / _pos.w, _pos.y / _pos.w);

    unproj2D.x=0.5-unproj2D.x*0.5;
    unproj2D.y=0.5+unproj2D.y*0.5;
    
    vec2 texelSize = 1.0 / textureSize(texture1, 0);

    vec3 result = vec3(0,0,0);

    for (int y = -PCF ; y <= PCF ; y++) {
        for (int x = -PCF ; x <= PCF ; x++) {
            result += texture(texture1, unproj2D + vec2(x, y) * texelSize).rgb;
        }
    }

    result /= (2*PCF+1)*(2*PCF+1);

    FragColor = vec4(result, 1.0);
}
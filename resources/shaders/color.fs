#version 330 core

in vec3 _normal;
in vec3 _pos;
in vec4 light_Position;

out vec4 FragColor;

uniform sampler2D shadowMap;

uniform vec3 lightDir;
uniform vec3 camPos;

#define BIAS 0.00001
#define PCF 4 // radius of texels to average

float ShadowCalculation(vec4 fragPosLightSpace)
{
    if(fragPosLightSpace.z > 1.0)
        return 0;

    // perspective divide needed with projection camera
    //vec3 projCoords = fragPosLightSpace.xyz / fragPosLightSpace.w;
    vec3 projCoords = fragPosLightSpace.xyz;
    projCoords = projCoords * 0.5 + 0.5;

    vec2 texelSize = 1.0 / textureSize(shadowMap, 0);

    float shadow = 0.0;

    float closestDepth = texture(shadowMap, projCoords.xy).r;
    float currentDepth = projCoords.z;

    for (int y = -PCF ; y <= PCF ; y++) {
        for (int x = -PCF ; x <= PCF ; x++) {
            float pcfDepth = texture(shadowMap, projCoords.xy + vec2(x, y) * texelSize).r; 
            shadow += currentDepth - BIAS > pcfDepth ? 1.0 : 0.0;
        }
    }

    shadow /= (2*PCF+1)*(2*PCF+1);

    return shadow;
}

void main(){
    float ambient = 0.2;
    vec3 lightDir = normalize(lightDir);
    vec3 norm = normalize(_normal);

    float diff = max(dot(lightDir, norm), 0.0);
    float diffuse = diff;

    vec3 viewDir = normalize(camPos - _pos);
    vec3 reflectDir = reflect(-lightDir, norm);

    float specular = pow(max(dot(viewDir, reflectDir), 0.0), 32)*0.7;
    vec3 color = _pos;

    float shadow = ShadowCalculation(light_Position);       
    vec3 lighting = (ambient + (1.0 - shadow) * (diffuse + specular)) * color;    
    
    FragColor = vec4(lighting, 1.0);
}
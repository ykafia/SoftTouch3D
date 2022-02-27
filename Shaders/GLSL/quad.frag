#version 430

out vec4 FragColor;
uniform float time;

void main()
{
    FragColor = vec4(abs(sin(time)), 0.0f, 0.0f, 1.0f);
}
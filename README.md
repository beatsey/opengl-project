OpenGL project
====
Glad to see you in my student project for computer graphics course at Lomonosov Moscow State University.
This course is score based. That means student has to implement certain graphical effects using shaders written in GLSL language and one specific effect has several credits depending on the difficulty of the implementation. In order to pass the course certain sum of credits has to be achieved.

This project written in VS 2019 using GLFW, GLEW, GLM libraries. All code is basically in main.cpp file.
All the libraries are precompiled. You can find them in the project folders.
To start the project just run the Graphics.sln in Visual Studio 2019.

In this projects there are implemented certain effects:
* Phong's lightning model
* normal mapping
* billboard implementation
* framebuffer grayscale post-effect
* recursive mirrors
* shadows (out of directional light source based on shadow map)

Controls:
* W - A - S - D - camera movements
* space - lifting the camera
* mouse - camera rotations
* arrows left and right - move post-effect border left and right
* ESC - close the program
* R - enable/disable mirrors on the scene

![Alt text](/resources/screen.jpg?raw=true)

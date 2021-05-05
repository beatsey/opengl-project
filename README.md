OpenGL project
====
This OpenGL project was developed as a part of the curriculum at Lomonosov Moscow State University on Computer Graphics course during 5th semester of studies.
The goal of the project was to implement certain graphical effects using GLSL shader language.

This project is written in VS 2019 using GLFW, GLEW, GLM libraries.
All code is basically in main.cpp file.
All the necessary libraries are precompiled and located in the project folders.
To start the project just run the Graphics.sln in Visual Studio 2019.

Following effects are implemented:
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

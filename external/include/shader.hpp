#pragma once

#include <GL/glew.h>

#include <string>
#include <fstream>
#include <sstream>
#include <iostream>

#include <windows.h>

std::string getCurrentDirectoryOnWindows()
{
	const unsigned long maxDir = 260;
	char currentDir[maxDir];
	GetCurrentDirectory(maxDir, currentDir);
	return std::string(currentDir);
}

class Shader {
	GLuint ID;

	GLuint LoadShader(const char* path,const int VERTEX_FRAGMENT) {
		std::string shaderCode;

		{
			std::ifstream shaderFile(path, std::ios::in);
			if (!shaderFile.is_open()) {
				std::cout << "Failed to open shader file:" << std::endl << path << std::endl;
				throw - 2;
			}
			
			std::stringstream strStream;
			strStream << shaderFile.rdbuf();
			shaderFile.close();
			shaderCode = strStream.str();
		}

		GLuint shaderID = glCreateShader(VERTEX_FRAGMENT);

		// Compile
		char const* sourcePointer = shaderCode.c_str();
		glShaderSource(shaderID, 1, &sourcePointer, NULL);
		glCompileShader(shaderID);

		// Check for compilation errors
		GLchar shaderErrorMessage[1024];
		GLint Result;
		glGetShaderiv(shaderID, GL_COMPILE_STATUS, &Result);
		if (!Result) {
			glGetShaderInfoLog(shaderID, 1024, NULL, shaderErrorMessage);
			std::cout << "Failed to compile shader: " << path << std::endl << shaderErrorMessage << std::endl;
			throw - 2;
		}
		return shaderID;
	}

public:
	Shader(const char* vertex_path, const char* fragment_path) {

		GLuint vertex = LoadShader(vertex_path, GL_VERTEX_SHADER);
		GLuint fragment = LoadShader(fragment_path, GL_FRAGMENT_SHADER);

		// shader program
		GLuint programID = glCreateProgram();
		glAttachShader(programID, vertex);
		glAttachShader(programID, fragment);
		glLinkProgram(programID);

		// Check for compilation errors
		GLchar programErrorMessage[1024];
		GLint Result;
		glGetProgramiv(programID, GL_LINK_STATUS, &Result);
		if (!Result) {
			glGetProgramInfoLog(programID, 1024, NULL, programErrorMessage);
			std::cout << "Failed to compile program:" << std::endl << programErrorMessage << std::endl;
			throw - 1;
		}

		glDeleteShader(vertex);
		glDeleteShader(fragment);

		ID=programID;
	}

	void use(){	glUseProgram(ID); }

	// bool + int
	void set(const std::string& name, int value) const {
		glUniform1i(glGetUniformLocation(ID, name.c_str()), value);
	}

	// float
	void set(const std::string& name, float value) const {
		glUniform1f(glGetUniformLocation(ID, name.c_str()), value);
	}

	// vec2
	void set(const std::string& name, const glm::vec2& value) const	{
		glUniform2fv(glGetUniformLocation(ID, name.c_str()), 1, &value[0]);
	}
	void set(const std::string& name, float x, float y) const {
		glUniform2f(glGetUniformLocation(ID, name.c_str()), x, y);
	}

	//vec3
	void set(const std::string& name, const glm::vec3& value) const {
		glUniform3fv(glGetUniformLocation(ID, name.c_str()), 1, &value[0]);
	}
	void set(const std::string& name, float x, float y, float z) const {
		glUniform3f(glGetUniformLocation(ID, name.c_str()), x, y, z);
	}

	//vec4
	void set(const std::string& name, const glm::vec4& value) const	{
		glUniform4fv(glGetUniformLocation(ID, name.c_str()), 1, &value[0]);
	}
	void set(const std::string& name, float x, float y, float z, float w) const	{
		glUniform4f(glGetUniformLocation(ID, name.c_str()), x, y, z, w);
	}

	//mat2
	void set(const std::string& name, const glm::mat2& mat) const {
		glUniformMatrix2fv(glGetUniformLocation(ID, name.c_str()), 1, GL_FALSE, &mat[0][0]);
	}

	//mat3
	void set(const std::string& name, const glm::mat3& mat) const {
		glUniformMatrix3fv(glGetUniformLocation(ID, name.c_str()), 1, GL_FALSE, &mat[0][0]);
	}

	//mat4
	void set(const std::string& name, const glm::mat4& mat) const {
		glUniformMatrix4fv(glGetUniformLocation(ID, name.c_str()), 1, GL_FALSE, &mat[0][0]);
	}
};
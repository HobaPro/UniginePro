using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "18597d3b5ba2d15e354d0925879a2840798c7e9f")]
public class CharacterMovement : Component
{

	float mouseX;
	float speed = 3;

	private void Init()
	{
		// write here code to be called on component initialization
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		mouseX = (Input.MouseDelta.x * 180.0f * Game.IFps) * -1;

		if(Input.IsKeyDown(Input.KEY.SHIFT)) speed = 5;
		if(Input.IsKeyUp(Input.KEY.SHIFT)) speed = 3;

		if(Input.IsKeyPressed(Input.KEY.W)) MoveVertical(speed);
		if(Input.IsKeyPressed(Input.KEY.S)) MoveVertical(speed * -1);
		if(Input.IsKeyPressed(Input.KEY.D)) MoveHorizontal(speed);
		if(Input.IsKeyPressed(Input.KEY.A)) MoveHorizontal(speed * -1);
		node.Rotate(0.0f, 0.0f, mouseX);
	}

	private void MoveVertical(float speed){

		node.WorldPosition += (node.GetWorldDirection(MathLib.AXIS.Y) * speed) * Game.IFps;
	}

	private void MoveHorizontal(float speed){

		node.WorldPosition += (node.GetWorldDirection(MathLib.AXIS.X) * speed) * Game.IFps;
	}
}
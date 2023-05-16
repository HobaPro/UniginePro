using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "e78609d85c418357d99648ca45cb21a1ffdece8c")]
public class MoveTokTok : Component
{

	float driveSpeed = 1.0f;
	float RotateSpeed = 90.0f;

	float DelayTime = 0.02f;
	float startTime;

	private void Init()
	{
		// write here code to be called on component initialization
		startTime = DelayTime;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		if(Input.IsKeyPressed(Input.KEY.W)){
			startTime -= Game.IFps;
			if(startTime < 0){
				if(driveSpeed > 100.0f) driveSpeed = 100.0f;
				VerticalDriving(driveSpeed * -1);
				driveSpeed *= 1.2f;
				startTime = DelayTime;
			}
		}

		if(Input.IsKeyUp(Input.KEY.W)){
			startTime -= Game.IFps;
			if(startTime < 0){
				if(driveSpeed < 0) driveSpeed = 0;
				driveSpeed -= 0.05f;
				startTime = DelayTime;
			}
		}

		if(Input.IsKeyPressed(Input.KEY.S)){
			startTime -= Game.IFps;
			if(startTime < 0.0f){
				if(driveSpeed > 50.0f) driveSpeed = 50.0f;
				VerticalDriving(driveSpeed);
				driveSpeed *= 1.1f;
				startTime = DelayTime;
			}
		}

		if(Input.IsKeyUp(Input.KEY.S)){
			startTime -= Game.IFps;
			if(startTime < 0.0f){
				if(driveSpeed < 0) driveSpeed = 0;
				driveSpeed -= 0.5f;
				startTime = DelayTime;
			}
		}

		if(Input.IsKeyPressed(Input.KEY.A)) RotateTokTok(RotateSpeed);
		if(Input.IsKeyPressed(Input.KEY.D)) RotateTokTok(RotateSpeed * -1);
	}

	private void VerticalDriving(float drivingSpeed){

		node.WorldPosition += (node.GetWorldDirection(MathLib.AXIS.Y) * drivingSpeed) * Game.IFps;
	}

	private void RotateTokTok(float drivingRotation){
		node.Rotate(0.0f, 0.0f, drivingRotation * Game.IFps);
	}
}
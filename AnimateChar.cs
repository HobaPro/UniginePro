using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "3eaf49bd762bfff8c3dfc2f7609943ead720a241")]
public class AnimateChar : Component
{
	private float speed; 
	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		if(Input.IsKeyPressed(Input.KEY.W)) MoveVertical(speed);
		if(Input.IsKeyPressed(Input.KEY.S)) MoveVertical(speed * -1);
		//if(Input.IsKeyPressed(Input.KEY.D)) MoveHorizontal(speed);
		//if(Input.IsKeyPressed(Input.KEY.D)) MoveHorizontal(speed * -1);
	}

	private void MoveVertical(float speed){
		node.WorldPosition += node.GetWorldDirection(MathLib.AXIS.Y) * speed * Game.IFps;
	}
}
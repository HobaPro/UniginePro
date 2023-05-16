using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "dfd9585cd4a9180bc1ac8deeaefcfc75934b6350")]
public class moveCameraTrget : Component
{
	public Node Player;
	float mouseY;
	float mouseX;
	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		mouseY = (Input.MouseDelta.y * 180.0f * Game.IFps) * -1;
		float rotation = MathLib.Clamp(mouseY, -90.0f, 90.0f);
		node.Rotate(rotation, 0.0f, 0.0f);
	}
}
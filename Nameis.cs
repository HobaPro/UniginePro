using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "ca48e436d6560e1dc94238d86489e657c7b54fca")]
public class Nameis : Component
{
	
	public Node Player;
	Body body;
	private void Init()
	{
		// write here code to be called on component initialization
		BodyRigid rb = node.ObjectBodyRigid;
		Log.Message(rb + "\n");
		body = node.ObjectBody;
		//body.Type = Body.TYPE(1);
		Log.Message(body.Type);
		//body.SetVelocityTransform(mat4.IDENTITY);
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}
}
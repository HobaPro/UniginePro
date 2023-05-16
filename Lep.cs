using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "3b5d2f1dfac4e5d8de1aaf57452584caa9f92da1")]
public class Lep : Component
{
	quat rotation;
	private void Init()
	{
		// write here code to be called on component initialization
		rotation = node.GetRotation();
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}
}
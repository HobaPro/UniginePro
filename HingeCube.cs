using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "e4377e5b467b9ffeb24347450dfc0fe0ed6f01bf")]
public class HingeCube : Component
{
	public Node wall;
	BodyRigid rb;
	private void Init()
	{
		// write here code to be called on component initialization
		rb = node.ObjectBodyRigid;
		JointHinge hj = new JointHinge(node.ObjectBodyRigid, wall.ObjectBodyRigid);
		hj.WorldAnchor = new vec3(0.0f, 0.0f, 0.0);
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		//rb.AddWorldImpulse(node.GetWorldDirection(MathLib.AXIS.X), node.GetWorldDirection(MathLib.AXIS.X) * 0.1f * Game.IFps);
	}
}
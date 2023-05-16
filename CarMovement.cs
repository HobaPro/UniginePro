using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "062d011f97315bf28f350aa9aee0d3f46520eec3")]
public class CarMovement : Component
{
	public Node Wheel_fr = null;
	public Node Wheel_fl = null;
	public Node Wheel_br = null;
	public Node Wheel_bl = null;

	private JointSuspension joint_Wheel_fr = null;
	private JointSuspension joint_Wheel_fl = null;
	private JointSuspension joint_Wheel_br = null;
	private JointSuspension joint_Wheel_bl = null;

	private Controls controls = null;

	private float angularTorque;
	private float angularVelocity;

	private void Init()
	{
		// write here code to be called on component initialization
		angularTorque = 0.0f;
		angularVelocity = 0.0f;

		if(Wheel_fr)
			joint_Wheel_fr = Wheel_fr.ObjectBody.GetJoint(0) as JointSuspension;
		if(Wheel_fl)
			joint_Wheel_fl = Wheel_fl.ObjectBody.GetJoint(0) as JointSuspension;
		if(Wheel_br)
			joint_Wheel_br = Wheel_br.ObjectBody.GetJoint(0) as JointSuspension;
		if(Wheel_bl)
			joint_Wheel_bl = Wheel_bl.ObjectBody.GetJoint(0) as JointSuspension;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		/*if(controls.GetState(Controls.STATE_FORWARD) > 0){
			angularTorque = 5.0f;
			angularVelocity = 50.0f;
		}
		if(controls.GetState(Controls.STATE_FORWARD) == 0 && controls.GetState(Controls.STATE_BACKWARD) == 0){
			angularTorque = 0.0f;
			angularVelocity = 0.0f;
		}

		if(controls.GetState(Controls.STATE_BACKWARD) > 0){
			angularTorque = 5.0f;
			angularVelocity = 50.0f * -1;
		}*/
		if(Input.IsKeyPressed(Input.KEY.W)){
			angularTorque = 5.0f;
			angularVelocity = 50.0f;
		}

		if(Input.IsKeyPressed(Input.KEY.S)){
			angularTorque = 5.0f;
			angularVelocity = 50.0f * -1;
		}

		joint_Wheel_fr.AngularVelocity = angularVelocity;
		joint_Wheel_fl.AngularVelocity = angularVelocity;
		joint_Wheel_br.AngularVelocity = angularVelocity;
		joint_Wheel_bl.AngularVelocity = angularVelocity;

		joint_Wheel_fr.AngularTorque = angularTorque;
		joint_Wheel_fl.AngularTorque = angularTorque;
		joint_Wheel_br.AngularTorque = angularTorque;
		joint_Wheel_bl.AngularTorque = angularTorque;

	}
}
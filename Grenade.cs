using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "65fa545163a6817c4896eeab5de4340e03212c15")]
public class Grenade : Component
{
	public AssetLinkNode grenade;
	bool readyToThrow;

	float lifeTime = 1.4f;
	float startTime;

	private void Init()
	{
		// write here code to be called on component initialization
		readyToThrow = true;
		startTime = lifeTime;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		startTime -= Game.IFps;
		if(startTime < 0){
			readyToThrow = true;
			startTime = lifeTime;
		}
		if(Input.IsKeyDown(Input.KEY.G)){
			if(readyToThrow){
				ThrowGrenade();
			}
		}
	}

	private void ThrowGrenade(){
		Node Grenade = grenade.Load(node.WorldPosition, quat.IDENTITY);
		BodyRigid rb = Grenade.ObjectBodyRigid;
		rb.AddWorldImpulse(Grenade.WorldPosition, node.GetWorldDirection(MathLib.AXIS.Y) * 15);
		readyToThrow = false;
		startTime = lifeTime;
	}
}
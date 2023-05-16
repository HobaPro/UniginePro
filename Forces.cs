using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "f973588781bf3c3ae6ce1e510ae3c37ca0ff48ab")]
public class Forces : Component
{
	BodyRigid rb;
	public bool ReadyToExplode = false;
	bool explode;
	Unigine.Random rand;

	public AssetLinkNode ExpolsionVFX;
	public AssetLinkNode FireVFX;

	SoundSource explosionEffect;

	float lifeTime = 0.03f;
	float startTime;
	private void Init()
	{
		// write here code to be called on component initialization
		rb = node.ObjectBodyRigid;
		rand = new Unigine.Random();
		explosionEffect = new SoundSource("Assets/Sound Effects/SmallExplosion.wav");
		startTime = lifeTime;
	}

	private void UpdatePhysics(){

		if(Input.IsKeyDown(Input.KEY.E)) ReadyToExplode = true;
		if(ReadyToExplode){
			Explode();
		}
	}

	void Explode(){

		// Delay
		startTime -= Game.IFps;
		if(startTime <= 0) explode = true;

		if(explode){

			ReadyToExplode = false;
			ExpolsionVFX.Load(node.WorldPosition, quat.IDENTITY);
			FireVFX.Load(node.WorldPosition - new vec3(0.0f, 0.0f, 1.0f), quat.IDENTITY);
			BoundSphere sphere = new BoundSphere(node.WorldPosition, 10.0f);

			List<Unigine.Object> objects = new List<Unigine.Object>();
			World.GetIntersection(sphere, objects);

			foreach(Unigine.Object obj in objects){

				Forces forceBarrel = obj.GetComponent<Forces>();
				if(forceBarrel != null){
					forceBarrel.ReadyToExplode = true;
					explosionEffect.WorldPosition = obj.WorldPosition;
					explosionEffect.Occlusion = 0;
					explosionEffect.MinDistance = 10.0f;
					explosionEffect.MaxDistance = 100.0f;
					explosionEffect.Gain = 1f;
					explosionEffect.Loop = 0;
					explosionEffect.Play();
					Log.Message(explosionEffect.SampleName);
				}

				BodyRigid objRB = obj.BodyRigid;
				vec3 objDir = (obj.WorldPosition - node.WorldPosition).Normalized;
				if(objRB != null){
					objRB.AddWorldImpulse(obj.WorldPosition, objDir * 10f);
				}
				node.DeleteLater();
			}
		}
	}
}
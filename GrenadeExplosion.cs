using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "3d23f721cdf2a60c971629fbd6cc171eb7f013e5")]
public class GrenadeExplosion : Component
{
	bool explode;
	vec3 directionImpulse;

	float lifeTime = 2.0f;
	float startTime = 0.0f;

	public AssetLinkNode explosionVFX;

	SoundSource explosionEffect;
	private void Init()
	{
		// write here code to be called on component initialization
		explode = true;
		startTime = lifeTime;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		startTime -= Game.IFps;

		if(explode){
			if(startTime < 0){
				Explode();
			}
		}
	}

	private void Explode(){

		explode = false;
		explosionVFX.Load(node.WorldPosition, quat.IDENTITY);

		// Explosion Effect
		explosionEffect = new SoundSource("Assets/Sound Effects/SmallExplosion.wav");

		explosionEffect.WorldPosition = node.WorldPosition;

		explosionEffect.Occlusion = 0;
		explosionEffect.MinDistance = 10.0f;
		explosionEffect.MaxDistance = 80.0f;
		explosionEffect.Gain = 0.5f;
		explosionEffect.Loop = 0;
		explosionEffect.Play();

		BoundSphere sphere = new BoundSphere(node.WorldPosition, 5.0f);
		List<Unigine.Object> objects = new List<Unigine.Object>();
		World.GetIntersection(sphere, objects);

		foreach(Unigine.Object obj in objects){

			if(obj != null){

				directionImpulse = (obj.WorldPosition - node.WorldPosition).Normalized;

				Forces forceBarrel = obj.GetComponent<Forces>();
				if(forceBarrel != null){
					forceBarrel.ReadyToExplode = true;
				}

				BodyRigid rb = obj.BodyRigid;
				if(rb != null)
					rb.AddWorldImpulse(obj.WorldPosition, directionImpulse * 10);
			}
		}
		node.DeleteLater();
	}
}
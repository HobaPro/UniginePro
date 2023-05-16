using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "84c1439694d325fda1ffaf3872b329377852f52a")]
public class GunShoot : Component
{

	// Referances
	public AssetLinkNode fireVFX;
	public AssetLinkNode hitVFX;
	public Node impact;

	float readyTime = 0.2f;
	float startTime;

	private void Init()
	{
		// write here code to be called on component initialization
		startTime = 0.0f;
	}
	
	private void Update()
	{
		Visualizer.Enabled = true;
		// write here code to be called before updating each render frame
		if(Input.IsMouseButtonPressed(Input.MOUSE_BUTTON.LEFT)){
			startTime -= Game.IFps;
			if(startTime <= 0){
				Shoot();
			}
		}
		if(Input.IsMouseButtonUp(Input.MOUSE_BUTTON.LEFT)){
			startTime = 0.0f;
		}
	}

	private void Shoot(){

		quat rotation = new quat();
		vec3 rr = rotation.Euler = new vec3(0.0f, 0.0f, 0.0f);

		Node fireEffect = fireVFX.Load(impact.WorldPosition, impact.GetWorldRotation());
		fireEffect.DeleteLater();

		ivec2 mouse = Input.MouseCoord;
		float leangth = 100.0f;
		vec3 startPoint = Game.Player.WorldPosition;
		vec3 endPoint = startPoint + new vec3(Game.Player.GetDirectionFromScreen(mouse.x, mouse.y)) * leangth;

		int mask = ~(1 << 2 | 1 << 4);
		
		WorldIntersection intersection = new WorldIntersection();

		Unigine.Object obj = World.GetIntersection(startPoint, endPoint, mask, intersection);

		if(obj != null){
			vec3 hitPoint = intersection.Point;
			BodyRigid rb = obj.BodyRigid;

			hitVFX.Load(hitPoint, quat.IDENTITY);
			if(rb != null){

				rb.AddWorldImpulse(hitPoint, hitPoint.Normalized * 100.0f);
			}

			Forces forceBarrel = obj.GetComponent<Forces>();
			if(forceBarrel != null){
				forceBarrel.ReadyToExplode = true;
			}
		}

		startTime = readyTime;
	}
}
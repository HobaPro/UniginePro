/*using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "8991259eba38d065ae36c6804ace07dfe4cf33b2")]
public class InstantiateUU : Component
{
	public AssetLinkNode node_to_spawn;
	public Node Player;
	Node spawned;
	WorldTrigger trigger;
	private void Init()
	{
		// write here code to be called on component initialization
		spawned = node_to_spawn.Load(node.WorldPosition, quat.IDENTITY);
		Visualizer.Enabled = true;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		spawned.WorldPosition += spawned.GetWorldDirection(MathLib.AXIS.Y) * 5 * Game.IFps;
		Visualizer.Enabled = true;
		Visualizer.RenderVector(node.WorldPosition, node.GetWorldDirection(MathLib.AXIS.Y) * 5.0f, new vec4(1.0f, 0.0f, 0.0f, 1.0f));
		//node.WorldPosition += node.GetWorldDirection(MathLib.AXIS.Y) * 10 * Game.IFps;
		//node.Rotate(0.0f, 0.0f, 50.0f * 2 * Game.IFps);
		//node.WorldLookAt(Player.WorldPosition);
		trigger = node as WorldTrigger;
		void gae(){
			Log.Message("Triggers");
		}
	}
}*/
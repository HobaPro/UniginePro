using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "9985073dbe079f787f13dc7721e78f6a39af77c1")]
public class CMesh : Component
{
	// Referances
	public Node Player;
	Node node_2;
	ObjectMeshStatic staticBox;
	private void Init()
	{
		// write here code to be called on component initialization
		String node_2Path = NodesAPI.CreateNode("Box", "Assets/Meshs/010m.mesh", "Assets/Nodes/110n.node", vec3.ONE);

		node_2 = World.LoadNode(node_2Path);
		//node_2.WorldPosition = Player.WorldPosition;
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		node_2.Rotate(0.0f, 0.0f, MathLib.Lerp(0.0f, 90.0f, 5 * Game.IFps));
	}
}
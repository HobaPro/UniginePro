using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "ebc9cdf1ba456e9c2943b94b69063e2e21046fb5")]
public class NodesAPI
{
	public static String CreateNode(String surfaceName, String meshPath, String nodePath,  vec3 surfaceSize, float sphereRaduis = 1.0f, bool isDynamic = false){

		// Referance
		Node node;
		ObjectMeshStatic staticMesh;
		ObjectMeshDynamic dynamicMesh;

		// Create New Mesh
		Mesh mesh = new Mesh();
		
		// Add Surface To Mesh
		if(surfaceName == "Box")
			mesh.AddBoxSurface(surfaceName, surfaceSize);
		if(surfaceName == "Sphere")
			mesh.AddSphereSurface(surfaceName, sphereRaduis, 0, 0);
		else
			Log.Error("This is Not Surface");
		
		// Save Mesh to Dir
		mesh.Save(meshPath);

		// Create a Object Mesh Dynamic or Static
		if(!isDynamic){
			staticMesh = new ObjectMeshStatic(meshPath);
			node = staticMesh;
		}
		else{
			dynamicMesh = new ObjectMeshDynamic(meshPath);
			node = dynamicMesh;
		}

		// Create Node
		//node = isDynamic ? staticMesh : dynamicMesh;

		World.SaveNode(nodePath, node);

		return nodePath;
	}
}
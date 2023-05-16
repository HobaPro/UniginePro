using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "47c027724b0a602992472b7443b06043594988c6")]
public class Tut_1 : Component
{

	Material mat;

	private void Init()
	{
		vec3 noodSize = new vec3(1.0f, 1.0f, 1.0f);
		ObjectMeshDynamic nood = Primitives.CreateBox(noodSize);
		//Primitives.AddBoxSurface(nood, new vec3(5.0f, 5.0f, 5.0f), mat4.IDENTITY);
		//Node ndd = nood;
		nood.WorldPosition = new vec3(1.0f, 1.0f, 1.0f);

		Material mesh_base = Materials.FindManualMaterial("Unigine::mesh_base");
		mat = mesh_base.Inherit();
		int num = mat.FindTexture("albedo");
		Image img = new Image("Assets/Materials/Textures/Wall/TexturesCom_Wall_Stone3_2x2_4K_albedo.tif");
		mat.SetTextureImage(num, img);
		
		String materialPath = "Assets/Materials/HobaMaterial.mat";
		mat.CreateMaterialFile(materialPath);

		nood.SetMaterialPath(materialPath, "*");

		BodyRigid rb = new BodyRigid((nood as Unigine.Object));
		ShapeBox box = new ShapeBox(new vec3(1.0f, 1.0f, 1.0f));
		rb.AddShape(box);
		
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		
	}
}
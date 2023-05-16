using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "4e3ab5e65d59d40d79c0e608bda9d1c70412e47a")]
public class CubePhysics : Component
{
	HealthSystem nodeHealth;
	Body body;
	bool ReadyTOExplode = false;
	BodyRigid rr;
	bool hit = false;
	NodeDummy ff;
	private void Init()
	{
		body = node.ObjectBody;
		rr = new BodyRigid();
		ff = new NodeDummy();
		ff.WorldPosition = new vec3(1.0f, 1.0f, 2.0f);
		//Log.Message(ff.Name + "\n" + ff.WorldPosition);
	}

	private void Update()
	{
		Visualizer.Enabled = true;
		// write here code to be called before updating each render frame
		//body.AddContactsCallback((b) => b.RenderInternalContacts()); 
		body.AddContactEnterCallback(OnContactEnter);
		Visualizer.RenderVector(ff.WorldPosition, ff.GetWorldDirection(MathLib.AXIS.Z) * 5.0f, new vec4(1.0f, 0.0f, 0.0f, 1.0f));
		//Log.Message(ff.Name + " " + ff.WorldPosition);
	}

	void OnContactEnter(Body body, int num){
		ReadyTOExplode = true;
		if(ReadyTOExplode){
			PhysicalForce boom = new PhysicalForce(6.0f);
			boom.Attractor = 100.0f * 1;
			boom.WorldPosition = node.WorldPosition;
			//node.DeleteLater();

			//ReadyTOExplode = false;
		}
	}
}
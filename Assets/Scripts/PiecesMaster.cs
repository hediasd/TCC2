using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PiecesMaster : MonoBehaviour {

	Transform ModelsFather;
	Dictionary<string, GameObject> TargetedModels = new Dictionary<string, GameObject>();

	int index = 0;

	void Start() {

		ModelsFather = GameObject.Find("ModelsFather").transform;
		Object TagBase = Resources.Load("Models/TagBase2");
		Object ButtonsBase = Resources.Load("Models/ButtonsBase");

		for (int i = 0; i < ModelsFather.transform.childCount; i++)
		{
			//TargetedModels.Add(ModelsFather.GetChild(i).gameObject.name, ModelsFather.GetChild(i).gameObject);
		}



	}

	void Update(){
		
	}

	/* foreach (TrackedTag Tag in ResourcesMaster.TrackedTagsDictionary.Values)
		{
			GameObject InstanceT = Instantiate(TagBase, new Vector3(AxisControl, 0, 0), Quaternion.identity) as GameObject;
			//GameObject InstanceB = Instantiate(ButtonsBase, InstanceT.transform.position + new Vector3(-0.2f, 0, -0.2f), Quaternion.identity) as GameObject;
			InstanceT.name = Tag.Name;
			DynamicDataSetLoader DataSetLoader = InstanceT.GetComponent<DynamicDataSetLoader>();
	//		GameObject augmodel = GameObject.Find("ponto-V3");
	//	augmodel.transform.parent = InstanceT.transform;
			DataSetLoader.augmentationObject = Instantiate(GameObject.Find("ponto-V3"));//InstanceT.transform.GetChild(1).gameObject;
			InstanceT.transform.parent = ModelsFather;
			//InstanceB.transform.parent = InstanceT.transform;

			PieceEventManager Pve = InstanceT.transform.GetChild(0).gameObject.AddComponent<PieceEventManager>();
			
			AxisControl += 3;
			break;
		} */
		//PieceEventManager Pve = Piece.AddComponent<PieceEventManager>();



	

	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	//ButtonObject
	public string type;
	AssemblyMaster AssemblyMaster;
	PieceEventManager PVE;

	void Start () {
		//this.GetComponent<MeshRenderer>().materials[1] = 
		AssemblyMaster = GameObject.Find("Logic").GetComponent<AssemblyMaster>();
	}

    // GameObject TriggeredTag = this.transform.parent.parent.gameObject;
	public void Activate(){

		PVE = this.transform.parent.parent.GetComponent<PieceEventManager>();
		
		switch (type) {
			case "B":
				AssemblyMaster.PreviousEvent(PVE);

			break;
			case "P":
				AssemblyMaster.PlayEvent(PVE);

			break;
			case "F":
				AssemblyMaster.NextEvent(PVE);

			break;
		}

		
	}
	
	void Update () {
		
	}
}

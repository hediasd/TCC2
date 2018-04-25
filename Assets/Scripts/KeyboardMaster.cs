#if (UNITY_EDITOR) 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMaster : MonoBehaviour {

	AssemblyMaster AssemblyMaster;

	void Start () {
		AssemblyMaster = GetComponent<AssemblyMaster>();
	}

	void Update () {

		if(Input.GetKeyDown ("q")){
			AssemblyMaster.PreviousEvent(AssemblyMaster.PieceEventManagers[AssemblyMaster.PVEIndex]);
		}
		if(Input.GetKeyDown ("w")){
			AssemblyMaster.PlayEvent(AssemblyMaster.PieceEventManagers[AssemblyMaster.PVEIndex]);
		}
		if(Input.GetKeyDown ("e")){
			AssemblyMaster.NextEvent(AssemblyMaster.PieceEventManagers[AssemblyMaster.PVEIndex]);
		}
		if(Input.GetKeyDown ("r")){

		}
		if(Input.GetKeyDown ("t")){

		}
		if(Input.GetKeyDown ("y")){

		}
		
	}
}

#endif

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

		}
		if(Input.GetKeyDown ("w")){

		}
		if(Input.GetKeyDown ("e")){

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

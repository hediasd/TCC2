using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AssemblyMaster : MonoBehaviour {

	PiecesMaster PiecesMaster;
	Transform ModelsFather;

	List<PieceEventManager> EventManagers;

	void Start(){

		EventManagers = new List<PieceEventManager>();
	
		PiecesMaster = GetComponent<PiecesMaster>();
		ModelsFather = GameObject.Find("ModelsFather").transform;

		foreach (Transform Model in ModelsFather)
		{
			EventManagers.Add(Model.GetComponent<PieceEventManager>());				
		}

		EventManagers[0].EnabledButtons(true);


	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(TrackerManager.)
		
	}

	public void PreviousEvent(PieceEventManager PVE){
		if(PVE.Index > 0) {
			PVE.Index--;
			PVE.PlayEvent();
		}else if(EventManagers.IndexOf(PVE) > 0){
			PVE.EnabledButtons(false);
			EventManagers[EventManagers.IndexOf(PVE) - 1].EnabledButtons(true);
		}
	}

	public void PlayEvent(PieceEventManager PVE){

		PVE.PlayEvent();


	}

	public void NextEvent(PieceEventManager PVE){
		if(PVE.Index < PVE.MaxIndex) {
			PVE.Index++;
			PVE.PlayEvent();
		}else if(EventManagers.IndexOf(PVE) < EventManagers.Count-1){
			PVE.EnabledButtons(false);
			EventManagers[EventManagers.IndexOf(PVE) + 1].EnabledButtons(true);
		}


	}

}

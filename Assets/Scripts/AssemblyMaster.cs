using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AssemblyMaster : MonoBehaviour {

	PiecesMaster PiecesMaster;
	Transform ModelsFather;

	List<PieceEventManager> PieceEventManagers;
	PieceEvent OngoingGlobalEvent;

	void Start(){

		PieceEventManagers = new List<PieceEventManager>();
	
		PiecesMaster = GetComponent<PiecesMaster>();
		ModelsFather = GameObject.Find("ModelsFather").transform;

		foreach (Transform Model in ModelsFather)
		{
			PieceEventManager PEM = Model.GetComponent<PieceEventManager>();
			PEM.Enableds(false, false, true);
			PieceEventManagers.Add(PEM);	

		}

		PieceEventManagers[0].Enableds(true, true, false);
		OngoingGlobalEvent = PieceEventManagers[0].OngoingManagerEvent;



	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void PreviousEvent(PieceEventManager PVE){
		if(PVE.Index > 0) {
			PVE.Index--;
			PVE.PlayEvent();
		}else if(PieceEventManagers.IndexOf(PVE) > 0){
			PVE.Enableds(false, false, true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) - 1].Enableds(true, true, false);
		}
	}

	public void PlayEvent(PieceEventManager PVE){
		PVE.PlayEvent();
	}

	public void NextEvent(PieceEventManager PVE){
		if(PVE.Index < PVE.MaxIndex) {
			PVE.Index++;
			PVE.PlayEvent();
		}else if(PieceEventManagers.IndexOf(PVE) < PieceEventManagers.Count-1){
			PVE.Enableds(false, false, true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) + 1].Enableds(true, true, false);
		}


	}

}

using System;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AssemblyMaster : MonoBehaviour {

	PiecesMaster PiecesMaster;
	Transform ModelsFather;

	public List<PieceEventManager> PieceEventManagers;
	public static int PVEIndex = 0;
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
			try{
				PVE.Index--;
				PVE.PlayEvent();
			}catch(Exception e){
				PVE.Index++;
				Debug.Log(e.Message);
			}	
		}else if(PieceEventManagers.IndexOf(PVE) > 0){
			PVEIndex--;
			PVE.Enableds(false, false, true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) - 1].Enableds(true, true, false);
		}
	}

	public void PlayEvent(PieceEventManager PVE){
		try{
			PVE.PlayEvent();
		}catch(Exception e){
			Debug.Log(e.Message);
		}
	}

	public void NextEvent(PieceEventManager PVE){
		if(PVE.Index < PVE.MaxIndex) {
			try{
				PVE.Index++;
				PVE.PlayEvent();
			}catch(Exception e){
				PVE.Index--;
				Debug.Log(e.Message);
			}			
		}else if(PieceEventManagers.IndexOf(PVE) < PieceEventManagers.Count-1){
			PVEIndex++;
			PVE.Enableds(false, false, true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) + 1].Enableds(true, true, false);
		}


	}

}

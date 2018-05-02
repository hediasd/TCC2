using System;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AssemblyMaster : MonoBehaviour {

	PiecesMaster PiecesMaster;
	Transform ModelsFather;

	public List<PieceEventManager> PieceEventManagers;
	public static int ManagersIndex = 0;
	PieceEvent OngoingGlobalEvent;

	SceneSetup LoadedSceneSetup;
	List<TrackedTag> TrackedTags;

	void Start(){

		LoadedSceneSetup = ResourcesMaster.SceneSetup;
		GetComponent<SetupHolder>().SceneSetup = LoadedSceneSetup;

		TrackedTags = new List<TrackedTag>(LoadedSceneSetup.TrackedTags);
		ModelsFather = GameObject.Find("ModelsFather").transform;

		PieceEventManagers = new List<PieceEventManager>();
		PiecesMaster = GetComponent<PiecesMaster>();

		for (int i = 0; i < ModelsFather.childCount; i++)
		{

			GameObject ChildModel = ModelsFather.GetChild(i).gameObject;
			PieceEventManager PEM = ChildModel.GetComponent<PieceEventManager>();
			PEM.Enableds(false, false, true);

			TrackedTag TkTag = TrackedTags.Find(Tag => Tag.Name.Equals(ChildModel.name));
			if(TkTag == null) Debug.Log("Couldnt find such Tag "+i);

			PEM.PieceEvents = new List<PieceEvent>(TkTag.PieceEvents);
			PEM.FullyLoad();

			PieceEventManagers.Add(PEM);
			
		}



		PieceEventManagers[0].Enableds(true, true, false);
		OngoingGlobalEvent = PieceEventManagers[0].OngoingManagerEvent;


		PlayEvent(PieceEventManagers[0]);

	}
	
	void Update () {

		
	}

	public void PreviousEvent(PieceEventManager PVE){

		int safetyIndex = PVE.Index;

		if(PVE.Index > 0) {
			try{
				PVE.Index--;
				PVE.ManagerPlayEvent();
			}catch(Exception e){
				PVE.Index = safetyIndex;
				Debug.Log(e.Message);
			}	
		}else if(PieceEventManagers.IndexOf(PVE) > 0){
			ManagersIndex--;
			PVE.Enableds(false, false, true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) - 1].Enableds(true, true, false);
		}
	}

	public void PlayEvent(PieceEventManager PVE){
		try{
			PVE.ManagerPlayEvent();
		}catch(Exception e){
			Debug.Log(e.Message);
		}
	}

	public void NextEvent(PieceEventManager PVE){

		int safetyIndex = PVE.Index;

		if(PVE.Index < PVE.MaxIndex) {
			try{
				PVE.Index++;
				PVE.ManagerPlayEvent();
			}catch(Exception e){
				PVE.Index = safetyIndex;
				Debug.Log(e.Message);
			}			
		}else if(PieceEventManagers.IndexOf(PVE) < PieceEventManagers.Count-1){
			ManagersIndex++;
			PVE.Enableds(false, false, true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) + 1].Enableds(true, true, false);
		}


	}

}

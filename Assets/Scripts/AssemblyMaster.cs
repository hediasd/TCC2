using System;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AssemblyMaster : MonoBehaviour {

	Transform ModelsFather;

	public List<PieceEventManager> PieceEventManagers;
	public List<ToolboxManager> ToolboxManagers;
	public static int ManagersIndex = 0;
	PieceEvent OngoingGlobalEvent;

	SceneSetup LoadedSceneSetup;
	List<TrackedAnimationTag> TrackedAnimationTags;
	List<TrackedToolboxTag> TrackedToolboxTags;

	public GameObject PanelBase, ModelBase;

	void Start(){

		LoadedSceneSetup = ResourcesMaster.SceneSetup;
		GetComponent<SetupHolder>().SceneSetup = LoadedSceneSetup;

		TrackedAnimationTags = new List<TrackedAnimationTag>(LoadedSceneSetup.TrackedAnimationTags);
		TrackedToolboxTags = new List<TrackedToolboxTag>(LoadedSceneSetup.TrackedToolboxTags);

		ModelsFather = GameObject.Find("ModelsFather").transform;

		PieceEventManagers = new List<PieceEventManager>();

		for (int i = 0; i < ModelsFather.childCount; i++)
		{
			//ToolboxManager TM = new ToolboxManager();

			GameObject ChildModel = ModelsFather.GetChild(i).gameObject;

			TrackedAnimationTag TkAnimationTag = TrackedAnimationTags.Find(Tag => Tag.Name.Equals(ChildModel.name));
			TrackedToolboxTag TkToolboxTag = TrackedToolboxTags.Find(Tag => Tag.Name.Equals(ChildModel.name));

			if(TkAnimationTag == null && TkToolboxTag == null){
				Debug.Log("Couldnt find such Tag "+ ChildModel.name + " " + i);
				continue;
			}
			if(TkAnimationTag != null){
				
				PieceEventManager PEM = ChildModel.AddComponent<PieceEventManager>();
				PEM.Enableds(Models: false, Buttons: false, Warnings: true);		

				Transform PanelsFather = ChildModel.transform.Find("Panels");
				foreach (PieceModel Panel in TkAnimationTag.Panels)
				{
					GameObject NewPanel = Instantiate(PanelBase, PanelsFather);
					NewPanel.name = Panel.Name;
					NewPanel.transform.localPosition = Panel.ModelPositionVector;
					NewPanel.transform.localRotation = Panel.ModelRotationVector;
					NewPanel.transform.localScale = Panel.ModelScaleVector;
				}

				//Transform Models = ChildModel.transform.Find("Models");
				//foreach (PieceModel Model in TkAnimationTag.Models){
				//	GameObject NewModel = Instantiate(PanelBase, Models);
				//	NewModel.name = Model.Name;
				//	NewModel.transform.localPosition = Model.ModelPositionVector;
				//	NewModel.transform.localRotation = Model.ModelRotationVector;
				//	NewModel.transform.localScale = Model.ModelScaleVector;
				//}
				
				PEM.FullyLoad(TkAnimationTag.PieceEvents);
				Debug.Log(PEM.PieceEvents.Count);
				PieceEventManagers.Add(PEM);

			}
			if(TkToolboxTag != null){
				
				ToolboxManager TM = ChildModel.AddComponent<ToolboxManager>();	
				TM.Enableds(Models: false);
				ToolboxManagers.Add(TM);

				Transform PanelsFather = ChildModel.transform.Find("Panels");
				foreach (PieceTool Tool in TkToolboxTag.Tools)
				{
					foreach (PieceModel Panel in Tool.Panels)
					{
						GameObject NewPanel = Instantiate(PanelBase, PanelsFather);
						NewPanel.name = Panel.Name;
						NewPanel.transform.localPosition = Panel.ModelPositionVector;
						NewPanel.transform.localRotation = Panel.ModelRotationVector;
						NewPanel.transform.localScale = Panel.ModelScaleVector;
					}					
				}

			}

			
		}

		PieceEventManagers[0].Enableds(Models: true, Buttons: true, Warnings: false);
		OngoingGlobalEvent = PieceEventManagers[0].OngoingManagerEvent;

		PlayEvent(PieceEventManagers[0]);

	}

	public void SetSize(float n){
		for (int i = 0; i < 3; i++)//ModelsFather.transform.childCount
		{
			Transform Model = ModelsFather.GetChild(i);
			Model.localScale = new Vector3(n, n, n);			
		}
	}

	public void PreviousEvent(PieceEventManager PVE){

		int safetyIndex = PVE.Index;

		if(PVE.Index > 0) {
			try{
				PVE.Index--;
				PlayEvent(PVE);
			}catch(Exception e){
				PVE.Index = safetyIndex;
				Debug.Log(e.Message);
			}	
		}else if(PieceEventManagers.IndexOf(PVE) > 0){
			ManagersIndex--;
			PVE.Enableds(Models: false, Buttons: false, Warnings: true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) - 1].Enableds(Models: true, Buttons: true, Warnings: false);
		}
	}

	public void PlayEvent(PieceEventManager PVE){
		PVE.ManagerPlayEvent();
		foreach (ToolboxManager Toolbox in ToolboxManagers)
		{
			Toolbox.Enableds(Models: false);
			Toolbox.EnableTool(PVE.OngoingManagerEvent.ToolboxElements, true);
		}

	}

	public void NextEvent(PieceEventManager PVE){

		int safetyIndex = PVE.Index;

		if(PVE.Index < PVE.MaxIndex) {
			try{
				PVE.Index++;
				PlayEvent(PVE);
			}catch(Exception e){
				PVE.Index = safetyIndex;
				Debug.Log(e.Message);
			}			
		}else if(PieceEventManagers.IndexOf(PVE) < PieceEventManagers.Count-1){
			ManagersIndex++;
			PVE.Enableds(Models: false, Buttons: false, Warnings: true);
			PieceEventManagers[PieceEventManagers.IndexOf(PVE) + 1].Enableds(Models: true, Buttons: true, Warnings: false);
		}


	}

}

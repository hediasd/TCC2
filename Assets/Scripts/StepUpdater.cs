using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepUpdater : MonoBehaviour {

	TextMesh TextMesh;
	AssemblyMaster AssemblyMaster;
	string GoalStep = "X";
	string CurrentStep = "Y";

	void Start(){
		AssemblyMaster = GameObject.Find("Logic").GetComponent<AssemblyMaster>();
		TextMesh = GetComponent<TextMesh>();
		string TagName = this.transform.parent.parent.gameObject.name;
		GoalStep = ResourcesMaster.SceneSetup.TrackedAnimationTags.Find(t => t.Name.Equals(TagName)).PieceEvents[0].Name;
	}

	void Update () {
		CurrentStep = AssemblyMaster.PieceEventManagers[AssemblyMaster.ManagersIndex].OngoingManagerEvent.Name;
		TextMesh.text = "Etapa : " + CurrentStep + "\nEtapa Atual : " + GoalStep;
	}
}

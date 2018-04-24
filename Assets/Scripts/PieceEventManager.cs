using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceEventManager : MonoBehaviour {

	bool ShowingModel = false;
	bool ShowingButtons = false;
	bool ShowingWarnings = false;

	public PieceEvent OngoingManagerEvent;
	List<PieceEvent> PieceEvents;


	public int Index, MaxIndex;

	void Start () {
		PieceEvents = new List<PieceEvent>();

		PieceEvents.Add(ResourcesMaster.PieceEvents[0]);
		PieceEvents.Add(ResourcesMaster.PieceEvents[1]);
		PieceEvents.Add(ResourcesMaster.PieceEvents[2]);

		OngoingManagerEvent = PieceEvents[0];

		Index = 0;
		MaxIndex = PieceEvents.Count - 1;

		foreach (PieceEvent PE in PieceEvents)
		{
			PE.FullyLoad();
		}
		//GameObject.Find("Text").GetComponent<Text>().text = "aaaa" + PieceEvents[0];
		
	}

	public void PlayEvent(){

		OngoingManagerEvent = PieceEvents[Index];
		GameObject Piece = transform.Find("Model").Find(OngoingManagerEvent.ComponentName).Find(OngoingManagerEvent.SubComponentName).GetChild(0).gameObject;


		foreach (PieceAction PA in OngoingManagerEvent.PieceActions)
		{
			Debug.Log("Playing event "+OngoingManagerEvent.Name + " " + PA.Name + " " + PA.TranslationAmountVector + " " +float.Parse(PA.TranslationTime)) ;

			if(PA.TranslationAmountVector != Vector3.zero && float.Parse(PA.TranslationTime) > 0){
				Move MoveScript = Piece.AddComponent<Move>();
				MoveScript.LoadEvent(PA.TranslationAmountVector, float.Parse(PA.TranslationTime));
			}
			if(PA.RotationAmountVector != Vector3.zero && float.Parse(PA.RotationTime) > 0){
				Spin SpinScript = Piece.AddComponent<Spin>();
				SpinScript.LoadEvent(PA.RotationAmountVector, float.Parse(PA.RotationTime));
			}
		}

	}
	public void NextEvent(){
		
	}

	public void Enableds(bool s1, bool s2, bool s3){
		EnabledModel(s1);
		EnabledButtons(s2);
		EnabledWarnings(s3);
	}
	public void EnabledModel(bool state){
		ShowingModel = state;
		transform.Find("Model").gameObject.SetActive(state);
	}
	public void EnabledButtons(bool state){
		ShowingButtons = state;
		transform.Find("Buttons").gameObject.SetActive(state);
	}
	public void EnabledWarnings(bool state){
		ShowingWarnings = state;
		transform.Find("Warnings").gameObject.SetActive(state);
	}

	

}

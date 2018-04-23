using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceEventManager : MonoBehaviour {

	public PieceEvent OngoingEvent;
	public bool ok = false;
	List<PieceEvent> PieceEvents;

	public int Index, MaxIndex;


	void Start () {
		PieceEvents = new List<PieceEvent>();

		PieceEvents.Add(ResourcesMaster.PieceEvents[0]);
		PieceEvents.Add(ResourcesMaster.PieceEvents[1]);
		PieceEvents.Add(ResourcesMaster.PieceEvents[2]);

		OngoingEvent = PieceEvents[0];

		Index = 0;
		MaxIndex = PieceEvents.Count - 1;

		foreach (PieceEvent PE in PieceEvents)
		{
			PE.FullyLoad();
		}

		//GameObject.Find("Text").GetComponent<Text>().text = "aaaa" + PieceEvents[0];
		ok = true;
	}

	public void PlayEvent(){

		OngoingEvent = PieceEvents[Index];
		GameObject Piece = transform.Find("Model").Find(OngoingEvent.ComponentName).Find(OngoingEvent.SubComponentName).GetChild(0).gameObject;


		foreach (PieceAction PA in OngoingEvent.PieceActions)
		{
			Debug.Log("Playing event "+OngoingEvent.Name + " " + PA.Name + " " + PA.TranslationAmountVector + " " +float.Parse(PA.TranslationTime)) ;

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

	public void EnabledButtons(bool state){
		transform.Find("Buttons").gameObject.SetActive(state);
	}

}

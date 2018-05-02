using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackedTag : LoadableResource {

	public PieceModel Model, Panel;
	public List<PieceEvent> PieceEvents;

	public TrackedTag(){
		Model = new PieceModel();
		PieceEvents = new List<PieceEvent>();
		//PieceEvents.Add(new PieceEvent());
		//PieceEvents.Add(new PieceEvent());
	}

}

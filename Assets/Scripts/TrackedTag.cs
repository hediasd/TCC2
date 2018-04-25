using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackedTag : LoadableResource {

	public string ModelNames = "A, B, C";
	public PieceModel Model;
	public List<PieceEvent> PieceEvents;

	public TrackedTag(){
		Model = new PieceModel();
		PieceEvents = new List<PieceEvent>();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TrackedTag : LoadableResource {

}
[System.Serializable]
public class TrackedAnimationTag : TrackedTag {
	
	/*
		SaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSalada	

		//https://barcode.tec-it.com/en/PDF417?data=SaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSalada	
	
	 */
	
	public List<PieceModel> Models, Panels;
	public List<PieceEvent> PieceEvents;

	public TrackedAnimationTag(){
		Models = new List<PieceModel>();
		Panels = new List<PieceModel>();
		PieceEvents = new List<PieceEvent>();
	}

}

[System.Serializable]
public class TrackedToolboxTag : TrackedTag {

	public List<PieceModel> Models, Panels;

	public TrackedToolboxTag(){
		Models = new List<PieceModel>();
		Panels = new List<PieceModel>();
	}

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackedTag : LoadableResource {

	public string ModelNames = "A, B, C";

	[System.NonSerialized]
	public List<PieceModel> Models;

	public TrackedTag(){
		Models = new List<PieceModel>();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PieceTool : LoadableResource {
	
	public List<PieceModel> Models, Panels;

	public PieceTool(){
		Models = new List<PieceModel>();
		Panels = new List<PieceModel>();
	}
}

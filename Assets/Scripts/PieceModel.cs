using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PieceModel : LoadableResource {

	public string Type, Color;
	public string ModelPosition = "0, 0, 0", ModelRotation = "0, 0, 0", ModelScale = "0, 0, 0";
	
	[System.NonSerialized]
	public Vector3 ModelPositionVector, ModelScaleVector;
	[System.NonSerialized]
	public Quaternion ModelRotationVector;
	
	public void FullyLoad(){
		ModelPositionVector = SplitIntoVector3(ModelPosition);
		ModelRotationVector = Quaternion.Euler(SplitIntoVector3(ModelRotation));
		ModelScaleVector	= SplitIntoVector3(ModelScale);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneSetup : LoadableResource {

	//public string TrackedTags = "Tomate, Salada";
	public List<TrackedTag> TrackedTags;

	public SceneSetup(){
		TrackedTags = new List<TrackedTag>();
		//TrackedTags.Add(new TrackedTag());
		//TrackedTags.Add(new TrackedTag());
		//TrackedTags.Add(new TrackedTag());
	}

}

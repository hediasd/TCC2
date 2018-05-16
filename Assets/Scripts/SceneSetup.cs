using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneSetup : LoadableResource {

	//public string TrackedTags = "Tomate, Salada";
	public List<TrackedAnimationTag> TrackedAnimationTags;
	public List<TrackedToolboxTag> TrackedToolboxTags;

	public SceneSetup(){
		TrackedAnimationTags = new List<TrackedAnimationTag>();
		TrackedToolboxTags	 = new List<TrackedToolboxTag>();
		//TrackedTags.Add(new TrackedTag());
		//TrackedTags.Add(new TrackedTag());
		//TrackedTags.Add(new TrackedTag());
	}

}

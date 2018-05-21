using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolboxManager : MonoBehaviour {

	// Use this for initialization
	public void Enableds(bool Models){
		EnabledModel(Models);
	}
	public void EnabledModel(bool state){
		Transform tools = transform.Find("Tools");
		for (int i = 0; i < tools.childCount; i++)
		{
			tools.GetChild(i).Find("Models").gameObject.SetActive(state);
			tools.GetChild(i).Find("Panels").gameObject.SetActive(state);
		}
	}

	public void EnableTool(string name, bool state){
		Transform child = transform.Find("Tools").Find(name);
		if(child != null){
			child.Find("Models").gameObject.SetActive(state);
			child.Find("Panels").gameObject.SetActive(state);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {

	public float Size = 1;
	public void Change(float n){
		Size += n;
		transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = ""+Size;
		GameObject.Find("Logic").GetComponent<AssemblyMaster>().SetSize(Size);
	}
	public void End(){
		this.transform.parent.gameObject.SetActive(false);
	}

}

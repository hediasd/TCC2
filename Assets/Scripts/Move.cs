using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	public Vector3 rot;
	public bool loaded = false;
	float t = 0.0f;
	float maxtime;


	public void LoadEvent(Vector3 vector, float maxtime){
		this.maxtime = maxtime;
		rot = vector;
		loaded = true;
	}
	
	void Update () {

		/* if(!loaded){
			t += TimeMaster.GeneralTiming * Time.deltaTime;
			if(t > delay){
				loaded = true;
				t = 0;
			} 
		} */
        if(loaded){

			transform.Translate((rot/maxtime)/1000);
			t += TimeMaster.GeneralTiming * Time.deltaTime;

			if(t >= maxtime) Destroy(this);

		}

	}

}

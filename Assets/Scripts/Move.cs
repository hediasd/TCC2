using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	public Vector3 TranslateAmount;
	public Vector3 OriginalPosition;
	public bool loaded = false;
	float t = 0.0f;
	float MaxTime;


	public void LoadEvent(Vector3 vector, float maxtime){
		this.MaxTime = maxtime;
		TranslateAmount = vector;
		loaded = true;
		OriginalPosition = this.transform.position;
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

			transform.Translate((TranslateAmount/MaxTime) / 1000);
			t += TimeMaster.GeneralTiming * Time.deltaTime;

			if(t >= MaxTime){
				this.transform.position = OriginalPosition;
				Destroy(this);
			}

		}

	}

}

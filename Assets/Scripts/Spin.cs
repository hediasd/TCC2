using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	// Use this for initialization
	public Vector3 RotationAmount;
	public Quaternion OriginalRotation;
	public bool loaded = false;
	float t = 0.0f;
	float MaxTime;


	public void LoadEvent(Vector3 vector, float maxtime){
		this.MaxTime = maxtime;
		RotationAmount = vector;
		loaded = true;
		OriginalRotation = this.transform.rotation;
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

			transform.Rotate(RotationAmount/MaxTime);
			t += TimeMaster.GeneralTiming * Time.deltaTime;

			if(t >= MaxTime){
				this.transform.rotation = OriginalRotation;
				Destroy(this);
			}

		}

	}

}

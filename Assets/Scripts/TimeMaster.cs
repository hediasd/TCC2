﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMaster : MonoBehaviour {

	public static float GeneralTiming = 1f;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public static IEnumerator WaitSeconds(float Seconds){
		float AccountedSeconds = GeneralTiming * Seconds;
		yield return new WaitForSeconds(AccountedSeconds);
	} 
}

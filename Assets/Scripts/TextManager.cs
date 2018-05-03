using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

	public string text;
	TextMesh TextMesh;

	void Start() {
		TextMesh = GetComponent<TextMesh>();
	}

	public void ChangeText(string s){
		text = s;
		string formatted_s = "";
		int charsAtLine = 0;

		TextMesh.text = "error";

		for (int i = 0; i < s.Length; i++)
		{
			if(charsAtLine >= 22)
			{
				for (int j = i-1; j > 0; j--)
				{
					if(formatted_s[j] == ' ')
					{
						formatted_s = formatted_s.Remove(j, 1);
						formatted_s = formatted_s.Insert(j, "\n");
						Debug.Log(formatted_s);
						charsAtLine = 0;
						break;
					}

				}
				
			}

			formatted_s += s[i];
			charsAtLine += 1;
		}

		TextMesh.text = formatted_s;
	}

	void Update () {
		
	}

}

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
			if(charsAtLine >= 16)
			{
				for (int j = i; j > 0; j--)
				{
					break;
					if(formatted_s[j] == ' ')
					{
					//	formatted_s.Insert(j, "Q");
						//charsAtLine = 0;
						//break;
					}

				}
				
			}

			formatted_s += s[i];
			charsAtLine += 1;
		}

		TextMesh.text = formatted_s;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

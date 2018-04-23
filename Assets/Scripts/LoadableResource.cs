using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class LoadableResource {

    public string Name;

	protected Vector3 SplitIntoVector3(string s){
        Vector3 v = new Vector3();
        string[] sv = Regex.Split(s, ", ");
        v.x = float.Parse(sv[0]);
        v.y = float.Parse(sv[1]);
        v.z = float.Parse(sv[2]);
        return v;
    }

    protected List<string> SplitIntoList(string s){
        List<string> v = new List<string>();
        string[] sv = Regex.Split(s, ", ");
        foreach (string ss in sv)
        {
            v.Add(ss);
        }
        return v;
    }


}

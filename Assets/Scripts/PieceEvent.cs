
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;

[System.Serializable]
public class PieceEvent : LoadableResource {

    public string ComponentName, SubComponentName;
    public string Actions;
    public string Requisites;

    [System.NonSerialized]
    public List<PieceAction> PieceActions;
    
    public PieceEvent(){
        PieceActions = new List<PieceAction>();
        //LoadActions();
    }

    public void PlayActions(){

    }

    public void FullyLoad(){

        PieceActions = new List<PieceAction>();
        //Debug.Log("actions "+Actions);
        string[] sv = Regex.Split(Actions, ", ");

        for (int i = 0; i < ResourcesMaster.PieceActions.Count; i++)
        {
            PieceAction pa = ResourcesMaster.PieceActions[i];
            pa.FullyLoad();
            if(pa != null && pa.Name.Equals(sv[0])){
                PieceActions.Add(pa);
            }else{
                Debug.Log("Null Action");
            }
        }
    
    }
    

}

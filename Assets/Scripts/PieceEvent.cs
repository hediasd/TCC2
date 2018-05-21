
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;

[System.Serializable]
public class PieceEvent : LoadableResource {

    public string ComponentNames, SubComponentNames;
    public string Actions, ToolboxElements;

    public List<PanelText> Description;

    [System.NonSerialized]
    public List<PieceAction> PieceActions;
    
    public PieceEvent(){
        Description = new List<PanelText>();
        PieceActions = new List<PieceAction>();
        //LoadActions();
    }

    public void FullyLoad(){

        PieceActions = new List<PieceAction>();
        //Debug.Log("actions "+Actions);
        string[] s = Regex.Split(Actions, ", ");

        for (int j = 0; j < s.Length; j++)
        { 
            for (int i = 0; i < ResourcesMaster.PieceActions.Count; i++)
            {   
                PieceAction pa = ResourcesMaster.PieceActions[i];
                if(pa != null && pa.Name.Equals(s[j])){
                    PieceActions.Add(pa);
                }else{
                    //Debug.Log("Null Action");
                }
            }    
        }
    }
    

}

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public class PieceAction : LoadableResource {

    public string RotationAmount, RotationTime;
    public string TranslationAmount, TranslationTime;

    [System.NonSerialized]
    public Vector3 RotationAmountVector;
    [System.NonSerialized]
    public Vector3 TranslationAmountVector;
    
    public PieceAction(){

        

    }

    public void FullyLoad(){

        RotationAmountVector     = SplitIntoVector3(RotationAmount);
        //RotationTimeVector       = SplitIntoVector3(RotationTime);
        TranslationAmountVector  = SplitIntoVector3(TranslationAmount);
        //TranslationTimeVector    = SplitIntoVector3(TranslationTime);

    }

}

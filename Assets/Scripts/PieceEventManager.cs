using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceEventManager : MonoBehaviour
{

    bool ShowingModel = false;
    bool ShowingButtons = false;
    bool ShowingWarnings = false;

    public PieceEvent OngoingManagerEvent;
    public List<PieceEvent> PieceEvents;


    public int Index, MaxIndex;

    public void FullyLoad(List<PieceEvent> PieceEventsList)
    {

        //PieceEvents = new List<PieceEvent>();
        //PieceEvents.Add(ResourcesMaster.PieceEvents[0]);
        PieceEvents = new List<PieceEvent>();
        PieceEvents.AddRange(PieceEventsList);

        OngoingManagerEvent = PieceEvents[0];

        Index = 0;
        MaxIndex = PieceEvents.Count - 1;

        foreach (PieceEvent PE in PieceEvents)
        {
            PE.FullyLoad();
        }

        Transform PanelsFather = transform.Find("Panels");
        foreach (PanelText Tuple in PieceEvents[0].Description)
        {
            TextManager TextManager = PanelsFather.Find(Tuple.PanelName).Find("Text").GetComponent<TextManager>();
            TextManager.ChangeText(Tuple.Text);
        }
        //GameObject.Find("Text").GetComponent<Text>().text = "aaaa" + PieceEvents[0];

    }

    public void ManagerPlayEvent()
    {

        OngoingManagerEvent = PieceEvents[Index];
        Transform PanelsFather = transform.Find("Panels");

        foreach (PanelText Tuple in OngoingManagerEvent.Description)
        {
            Transform Panel = PanelsFather.Find(Tuple.PanelName);

            if (Panel == null)
            {
                Debug.LogError("Invalid Panel " + Tuple);
            }
            else
            {
                TextManager TextManager = Panel.Find("Text").GetComponent<TextManager>();
                if (TextManager == null)
                {
                    Debug.LogError("Invalid Panel Name " + Tuple);
                }
                else
                {
                    TextManager.ChangeText(Tuple.Text);
                }
            }

        }

        List<GameObject> Pieces = new List<GameObject>();
        string[] Subcomponents = OngoingManagerEvent.SubComponentNames.Split('/');
        foreach (string sub in Subcomponents)
        {
            GameObject Piece = transform.Find("Models").Find(OngoingManagerEvent.ComponentNames).Find(sub).GetChild(0).gameObject;
            if (Piece == null)
            {
                Debug.LogError("Invalid Components Name");
            }
            else
            {
                Pieces.Add(Piece);
            }

        }

        foreach (GameObject Piece in Pieces)
        {

            //TextManager.ChangeText(OngoingManagerEvent.Description);

            foreach (PieceAction PA in OngoingManagerEvent.PieceActions)
            {
                Debug.Log("Playing event " + OngoingManagerEvent.Name + " " + PA.Name + " " + PA.TranslationAmountVector + " " + PA.RotationAmountVector);

                if (Piece.GetComponent<Move>() == null && PA.TranslationAmountVector != Vector3.zero && float.Parse(PA.TranslationTime) > 0)
                {
                    Move MoveScript = Piece.AddComponent<Move>();
                    MoveScript.LoadEvent(PA.TranslationAmountVector, float.Parse(PA.TranslationTime));
                }
                if (Piece.GetComponent<Spin>() == null && PA.RotationAmountVector != Vector3.zero && float.Parse(PA.RotationTime) > 0)
                {
                    Spin SpinScript = Piece.AddComponent<Spin>();
                    SpinScript.LoadEvent(PA.RotationAmountVector, float.Parse(PA.RotationTime));
                }
            }

        }

    }

    public void Enableds(bool Models, bool Buttons, bool Warnings)
    {
        EnabledModel(Models);
        EnabledButtons(Buttons);
        EnabledWarnings(Warnings);
    }
    public void EnabledModel(bool state)
    {
        ShowingModel = state;
        transform.Find("Models").gameObject.SetActive(state);
        transform.Find("Panels").gameObject.SetActive(state);
    }
    public void EnabledButtons(bool state)
    {
        ShowingButtons = state;
        transform.Find("Buttons").gameObject.SetActive(state);
    }
    public void EnabledWarnings(bool state)
    {
        ShowingWarnings = state;
        transform.Find("Warnings").gameObject.SetActive(state);
    }



}

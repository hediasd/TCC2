﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ResourcesMaster : MonoBehaviour
{

    // Loads, stores and writes brute data loaded from resources folder
    /* 
    List<PieceEvent> PieceEventsList;
    List<PieceAction> PieceActionsList;
    List<PieceModelObject> PieceModelObjectsList;
    List<PieceModelTextPanel> PieceModelTextPanelsList;
    List<TrackedTag> TrackedTagsList; */

    public static Dictionary<string, PieceEvent> PieceEventsDictionary;
    public static Dictionary<string, PieceAction> PieceActionsDictionary;

    public static List<PieceAction> PieceActions;
    public static int EventsIndex;
    public static SceneSetup SceneSetup;



    public static Dictionary<string, Material> Materials;

    public static GameObject PanelBase;

    void Start()
    {

        // PieceActionsDictionary = new Dictionary<string, PieceAction>();//LoadTextResource<PieceAction>();
        //  PieceEventsDictionary = new Dictionary<string, PieceEvent>();//LoadTextResource<PieceEvent>();
        //PieceModelObjectsDictionary = LoadTextResource<PieceModelObject>();
        //PieceModelTextPanelsDictionary = LoadTextResource<PieceModelTextPanel>();
        //TrackedTagsDictionary = LoadTextResource<TrackedTag>();

        //PieceModelTextPanelsDictionary.Values.ForEach(pm => pm.ModelType = "PieceModelTextPanel");

        PieceActions = ResourcesMaster.JsonToList<PieceAction>("PieceActions");
        string lcsp = ResourcesMaster.ListToJson<PieceAction>(PieceActions);
        foreach (PieceAction pa in PieceActions)
        {
            pa.FullyLoad();
            //PieceActionsDictionary.Add(pa.Name, pa);
        }
		//ResourcesMaster.WriteUp("PieceActions", lcsp);

        SceneSetup = ResourcesMaster.JsonToObject<SceneSetup>("SceneSetup_Torno");
        string sss = ResourcesMaster.ObjectToJson<SceneSetup>(SceneSetup);
        ResourcesMaster.WriteUp("SceneSetupBackup", sss);

        foreach (TrackedAnimationTag Tk in SceneSetup.TrackedAnimationTags)
        {
            foreach (PieceModel Panel in Tk.Panels)
            {
                Panel.FullyLoad();
            }
            foreach (PieceModel Model in Tk.Models)
            {
                Model.FullyLoad();
            }
        }

        


        //

        
    }

    Dictionary<string, T> LoadTextResource<T>() where T : LoadableResource
    {
        Dictionary<string, T> Dictionary = new Dictionary<string, T>();
        string TypeName = typeof(T).Name + "s";
        //Debug.Log(TypeName);

        List<T> LoadedList = ResourcesMaster.JsonToList<T>(TypeName);
		string liststring = ResourcesMaster.ListToJson<T>(LoadedList);
		ResourcesMaster.WriteUp(TypeName, liststring);

        string s = TypeName + " ";
        foreach (T item in LoadedList)
        {
            LoadableResource Resource = (LoadableResource) item;
            Dictionary.Add(Resource.Name, item);
            s += Resource.Name + " ";
        }
        Debug.Log(s); 
        
        //facda5//fcd47e
        //f47200
        //ffffb4
        //e36c13
        //ffb313
        
        return Dictionary;
    }

    void LoadMaterials()
    {

        Materials.Add("PlayButton", Resources.Load("Materials/PlayButton", typeof(Material)) as Material);

    }

    public static List<T> JsonToList<T>(string file)
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Texts/"+file, typeof(TextAsset)); 
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(textAsset.text);
        List<T> things = new List<T>(wrapper.Items);
        return things;
    }

	public static string ListToJson<T>(List<T> list)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = list.ToArray();
        return JsonUtility.ToJson(wrapper, true);
    }

    public static T JsonToObject<T>(string file)
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Texts/"+file, typeof(TextAsset));
        return JsonUtility.FromJson<T>(textAsset.text);
    }    
    public static string ObjectToJson<T>(T stuff)
    {
        return JsonUtility.ToJson(stuff, true);
    }
    

/*   public static string JsonToList<T>(string line)
    {

        Wrapper<T> wrapper = new Wrapper<T>();
        JsonUtility.FromJson<T>(line);
        wrapper.Items = array.ToArray();
        Debug.Log(wrapper.Items.Length);
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }*/

    public static void WriteUp(string file, string text)
    {
        TextAsset asset = Resources.Load(file + ".txt") as TextAsset;
        StreamWriter writer = new StreamWriter("Assets/Resources/Texts/" + file + ".txt");
        writer.WriteLine(text);
        writer.Close();
    }
       
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

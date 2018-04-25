using UnityEngine;
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
    public static List<PieceEvent> PieceEvents;
    public static int EventsIndex;
    public static SceneSetup SceneSetup;


    public static Dictionary<string, PieceModelObject> PieceModelObjectsDictionary;
    public static Dictionary<string, PieceModelTextPanel> PieceModelTextPanelsDictionary;

    public static Dictionary<string, TrackedTag> TrackedTagsDictionary;

    public static Dictionary<string, Material> Materials;

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
            //PieceActionsDictionary.Add(pa.Name, pa);
        }
		//ResourcesMaster.WriteUp("PieceActions", lcsp);

        PieceEvents = ResourcesMaster.JsonToList<PieceEvent>("PieceEvents");
        string lsp = ResourcesMaster.ListToJson<PieceEvent>(PieceEvents);
        foreach (PieceEvent pa in PieceEvents)
        {
            //PieceEventsDictionary.Add(pa.Name, pa);
        }
		//ResourcesMaster.WriteUp("PieceEvents", lsp);

        SceneSetup = ResourcesMaster.JsonToObject<SceneSetup>("SceneSetup");     

        Debug.Log("Count " + PieceEvents.Count);
        
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
        StreamWriter writer = new StreamWriter("Assets/Resources/Texts/" + file + ".txt"); // Does this work?
        writer.WriteLine(text);
        writer.Close();
    }

    public static void WriteUp(string file, int[,] map)
    {
        string text = "";
		
        for (int j = 0; j < map.GetLength(1); j++)
        {
            for (int i = map.GetLength(0)-1; i >= 0 ; i--)
            {
				string s;
				//if(map[j, i] < 0){
				//	s = "XXX";
				//}else{
				s = map[i,j].ToString("0.0");
					if(s.Equals("0.0")) s = "ZZZ";
				//}
				text += s;
				text += " ";
			}
			text += "\n";
		}

        TextAsset asset = Resources.Load(file + ".txt") as TextAsset;
        StreamWriter writer = new StreamWriter("Assets/Resources/Texts/" + file + ".txt"); // Does this work?
        writer.WriteLine(text);
        writer.Close();
    }
       
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

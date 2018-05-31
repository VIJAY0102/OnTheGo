using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathJSONParser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TextAsset textAsset = Resources.Load("pathModel") as TextAsset;
		if (textAsset != null){
			Debug.Log(JsonUtility.FromJson<PathModel>(textAsset.text).productPath[0].z);
		} else
		{
			Debug.Log("Bingo");
		}
	}

}

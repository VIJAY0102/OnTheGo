using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerButtonBehavior : MonoBehaviour {

	Unit unit;
	PathModel pathModel;
	ShortestPathModel shortestPathModel;
	int i=0;
	// Use this for initialization

	void Start() {
		unit = GetComponent<Unit>();
		string seeker = transform.position.x +", " + transform.position.y + ", " + transform.position.z;
		TextAsset textAsset = Resources.Load("shortestPath") as TextAsset;
		if (textAsset != null) {
			shortestPathModel = JsonUtility.FromJson<ShortestPathModel>(textAsset.text);
			foreach (ShortestPathBaseModel shortestPathBaseModel in shortestPathModel.__Mappings__) {
				if (seeker == shortestPathBaseModel.seeker.ToString()) {
					unit.target.position = new Vector3(
						shortestPathModel.__Mappings__[0].target.x,
						shortestPathModel.__Mappings__[0].target.y,
						shortestPathModel.__Mappings__[0].target.z
					);
					unit.PathFinder();
					break;
				}
			}
		} else
		{
			Debug.Log("Error: TargetButtonBehavior Json Read");
		}
	}

}

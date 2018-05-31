using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetButtonBehavior : MonoBehaviour {

	Unit unit;
	ShortestPathModel shortestPathModel;

	int i=0;
	// Use this for initialization

	void Start() {
		unit = GetComponent<Unit>();	
	}
	void OnMouseOver() {
		if (Input.GetMouseButtonUp(0)) {
			Debug.Log("clicked");
		}
	}
}

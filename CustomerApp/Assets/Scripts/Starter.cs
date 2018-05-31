using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour {
	
	public GameObject Player;
	public GameObject Product;
	PathModel pathModel;
	ShortestPathModel shortestPathModel;

	void Start() {
		TextAsset textAsset = Resources.Load("pathModel") as TextAsset;
		if (textAsset != null) {
			pathModel = JsonUtility.FromJson<PathModel>(textAsset.text);
			Player.transform.position = new Vector3(
				pathModel.seeker.x,
				pathModel.seeker.y,
				pathModel.seeker.z
				);
			Instantiate(Player,Player.transform.position, Player.transform.rotation);
			foreach (PathPosition pathPosition in pathModel.productPath) {
				Product.transform.position = new Vector3(
					pathPosition.x,
					pathPosition.y,
					pathPosition.z
				);
				Instantiate(Product, Product.transform.position, Product.transform.rotation);
			}
		} else
		{
			Debug.Log("Error: Starter Json Read");
		}		
	}
}

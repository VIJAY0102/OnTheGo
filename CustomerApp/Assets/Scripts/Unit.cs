using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


	public Transform seeker, target;
	float speed = 20;
	Vector3[] path;
	int targetIndex;

	public void PathFinder() {
		PathRequestManager.RequestPath(seeker.position,target.position, OnPathFound);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowVector3Path");
			StartCoroutine("FollowPath");	
			StartCoroutine(DrawPath());
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];
		while (true) {
			if (seeker.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			seeker.position = Vector3.MoveTowards(seeker.position,currentWaypoint,speed * Time.deltaTime);
			yield return null;

		}
	}

	IEnumerator DrawPath() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("pathcube");
		foreach(GameObject go in gos)
			Destroy(go);

		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
//				Gizmos.DrawCube(path[i], Vector3.one);
				//lineRenderer.SetPosition(2, path[i]);
				if (i == targetIndex) {
					LineRenderer lineRenderer = dynamicObjects();
					lineRenderer.SetPosition(0, seeker.position);
					lineRenderer.SetPosition(1, path[i]);
				}
				else {
					LineRenderer lineRenderer = dynamicObjects();
					lineRenderer.SetPosition(0, path[i-1]);
					lineRenderer.SetPosition(1, path[i]);
				}
			}
		}
		yield return null;
	}

	LineRenderer dynamicObjects() {
		GameObject cd = new GameObject();
		cd.transform.position = new Vector3(0f, 1f, 0f);
		cd.tag = "pathcube";
		LineRenderer lineRenderer = cd.AddComponent<LineRenderer>();
		lineRenderer.useWorldSpace = false;
		return lineRenderer;
	}

}

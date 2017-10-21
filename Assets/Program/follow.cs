using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

	//public GameObject player;

	public float minX;

	public float maxX;

	public float minY;

	public float maxY;

	public Transform target;

	// Use this for initialization
	void Start () {
		//target = player.transform;
		target=GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = new Vector3 (Mathf.Clamp (target.position.x, minX, maxX), Mathf.Clamp (target.position.y, minY, maxY),transform.position.z);
	}
}

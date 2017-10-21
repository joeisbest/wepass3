using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class talkable : MonoBehaviour {

	public Flowchart talkTip01;
	public string onCollosionEnter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("Player")) {
			Block targetBlock = talkTip01.FindBlock (onCollosionEnter);
			talkTip01.ExecuteBlock (targetBlock);
		}
	
	}
}

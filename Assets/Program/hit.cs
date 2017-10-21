using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class hit : MonoBehaviour {
	public Flowchart talkTip01;
	public string onCollosionEnter;
	public float x;
	//public Flowchart talkTip01;
	//public string onCollosionEnter;
	//public Text 
	// Use this for initialization
	void OnTriggerStay2D(Collider2D other){

		Block targetBlock = talkTip01.FindBlock (onCollosionEnter);
		if (other.gameObject.CompareTag("Player") ) {
			x = 1;
			if (Input.GetKey (KeyCode.Z)) {
				talkTip01.ExecuteBlock (targetBlock);
				Destroy (this.gameObject);
			}


		//Block targetBlock = talkTip01.FindBlock (onCollosionEnter);
		//talkTip01.ExecuteBlock (targetBlock);
			
	}
	}
	// Update is called once per frame
	void Update () {
		
	}
}

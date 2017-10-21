using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionOBJ : MonoBehaviour {

	public bool inventory;//can be stored
	public bool openable;
	public bool locked;

	public bool talk;
	public string message;


	public GameObject itemneeded;

	public Animator anim;
	public void DoInteracton(){
		gameObject.SetActive (false);
		
	}
	public void open(){
		anim.SetBool("open", true);

	}

}

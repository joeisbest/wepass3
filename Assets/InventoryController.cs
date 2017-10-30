using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	// Use this for initialization
	public Transform selectedItem, selectedSlot, originalSlot;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)&& selectedItem!=null){
			selectedItem.GetComponent<Collider> ().enabled = false;

		}
		if(Input.GetMouseButton(0)&& selectedItem!=null){
			selectedItem.position = Input.mousePosition;
			
		}
		else if(Input.GetMouseButtonUp(0)&& selectedItem!=null){
			selectedItem.parent = selectedSlot;
			selectedItem.localPosition = Vector3.zero;
			selectedItem.GetComponent<Collider> ().enabled = true;

		}
		
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class meleeDropDown : MonoBehaviour {

	public Dropdown meleeDrop;
	public RoombaController roomba;
	public GameObject prefZero;
	public GameObject prefOne;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (meleeDrop.value == 0) {
			roomba.MeleePrefab = prefZero;
		} else if (meleeDrop.value == 1) {
			roomba.MeleePrefab = prefOne;
		}
	}
}

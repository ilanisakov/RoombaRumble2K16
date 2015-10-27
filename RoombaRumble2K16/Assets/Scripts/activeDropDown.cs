using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class activeDropDown : MonoBehaviour {

	public Dropdown activeDrop;
	public RoombaController roomba;
	public GameObject prefZero;
	public GameObject prefOne;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (activeDrop.value == 0) {
			roomba.ActivePrefab = prefZero;
		} else if (activeDrop.value == 1) {
			roomba.ActivePrefab = prefOne;
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rangedDropDown : MonoBehaviour {

	public Dropdown rangedDrop;
	public RoombaController roomba;
	public GameObject prefZero;
	public GameObject prefOne;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (rangedDrop.value == 0) {
			roomba.RangedPrefab = prefZero;
		} else if (rangedDrop.value == 1) {
			roomba.RangedPrefab = prefOne;
		}
	}
}

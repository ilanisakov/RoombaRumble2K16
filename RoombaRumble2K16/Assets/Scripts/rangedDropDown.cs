using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rangedDropDown : MonoBehaviour {

	public Dropdown rangedDrop;
	public RoombaController roomba;
	public GameObject prefZero;
	public GameObject prefOne;

    public GameObject wep0;
    public GameObject wep1;

	// Use this for initialization
	void Start () {
        wep0.SetActive(false);
        wep1.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (rangedDrop.value == 0) {
			roomba.RangedPrefab = prefZero;

            wep0.SetActive(true);
            wep1.SetActive(false);

		} else if (rangedDrop.value == 1) {
			roomba.RangedPrefab = prefOne;

            wep1.SetActive(true);
            wep0.SetActive(false);
		}
	}
}

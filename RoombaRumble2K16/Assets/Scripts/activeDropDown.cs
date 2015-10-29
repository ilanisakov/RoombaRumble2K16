using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class activeDropDown : MonoBehaviour {

	public Dropdown activeDrop;
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
		if (activeDrop.value == 0) {
			roomba.ActivePrefab = prefZero;

            wep0.SetActive(true);
            wep1.SetActive(false);

		} else if (activeDrop.value == 1) {
			roomba.ActivePrefab = prefOne;


            wep1.SetActive(true);
            wep0.SetActive(false);
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class meleeDropDown : MonoBehaviour {

	public Dropdown meleeDrop;
	public RoombaController roomba;
	public GameObject prefZero;
	public GameObject prefOne;
    public GameObject prefTwo;

    public GameObject wep0;
    public GameObject wep1;
    public GameObject wep2;

	// Use this for initialization
	void Start () {
        wep0.SetActive(false);
        wep1.SetActive(false);
        wep2.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		if (meleeDrop.value == 0) {

            wep0.SetActive(true);
            wep1.SetActive(false);
            wep2.SetActive(false);

			roomba.MeleePrefab = prefZero;
		} else if (meleeDrop.value == 1) {

            wep1.SetActive(true);
            wep0.SetActive(false);
            wep2.SetActive(false);

			roomba.MeleePrefab = prefOne;
		}

        else if (meleeDrop.value == 2)
        {
            wep2.SetActive(true);
            wep1.SetActive(false);
            wep0.SetActive(false);

            roomba.MeleePrefab = prefTwo;
        }
	}
}

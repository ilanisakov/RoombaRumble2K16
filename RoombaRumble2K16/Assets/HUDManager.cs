using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
		timer = 99.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		Canvas canv = GameObject.Find ("Canvas").GetComponent<Canvas>();
		int tempTimer = (int)timer;
		canv.GetComponentInChildren<Text> ().text = tempTimer.ToString();
	}
}

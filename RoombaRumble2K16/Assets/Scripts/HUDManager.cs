using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	private float timer;
	GameObject player1, player2;
	Canvas canv;
	Text[] textFields;

	// Use this for initialization
	void Start () {
		timer = 99.0f;
		canv = GameObject.Find ("Canvas").GetComponent<Canvas>();
		textFields = canv.GetComponentsInChildren<Text> ();
		player1 = GameObject.Find ("Player 1");
		player2 = GameObject.Find ("Player 2");
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		int tempTimer = (int)timer;
		textFields[0].text = tempTimer.ToString();
		textFields [1].text = player1.GetComponent<Roomba>().Health.ToString();
		textFields [2].text = player2.GetComponent<Roomba>().Health.ToString();
	}
}

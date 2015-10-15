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

		if (player1.GetComponent<Roomba>().Health <= 0){
			textFields[3].enabled = true;
			textFields[3].text = "Player 2 Wins!";
			player1.GetComponent<RoombaController>().enabled = false;
			player2.GetComponent<RoombaController>().enabled = false;
			textFields[0].enabled = false;
		}
		else if (player2.GetComponent<Roomba>().Health <= 0){
			textFields[3].enabled = true;
			textFields[3].text = "Player 1 Wins!";
			player1.GetComponent<RoombaController>().enabled = false;
			player2.GetComponent<RoombaController>().enabled = false;
			textFields[0].enabled = false;
		}
		else if (timer <= 0){
			textFields[3].enabled = true;
			textFields[3].text = "DRAW!";
			player1.GetComponent<RoombaController>().enabled = false;
			player2.GetComponent<RoombaController>().enabled = false;
			textFields[0].enabled = false;
		}
	}
}

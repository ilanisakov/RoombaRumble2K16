using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject roombaPrefab;
    GameObject player1, player2;
    

    // Use this for initialization
    void Start () {
        GameObject player1 = (GameObject)Instantiate(roombaPrefab, new Vector2(-3,0), transform.rotation);
        GameObject player2 = (GameObject)Instantiate(roombaPrefab, new Vector2(3, 0), transform.rotation);

		player1.name = "Player 1";
		player2.name = "Player 2";

        player1.GetComponent<Roomba>().PlayerID = 1;
        player2.GetComponent<Roomba>().PlayerID = 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

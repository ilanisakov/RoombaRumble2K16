using UnityEngine;
using System.Collections;

public class DroppedBassCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Debug.Log("Droppedd");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log(col.gameObject);
        if (col.gameObject.name == "Player 2")
        {
            col.gameObject.GetComponent<Roomba>().Stun();
        }
    }
}

using UnityEngine;
using System.Collections;

public class DroppedBassCollider : MonoBehaviour {

	GameObject dropper;
	public GameObject Dropper {
		get {
			return dropper;
		}
		set {
			dropper = value;
		}
	}

	// Use this for initialization
	void Start () {
        //Debug.Log("Droppedd");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
       //Debug.Log(this.gameObject);
        if (col.gameObject.name == "Player 2" && dropper.name == "Player 1")
        {
            col.gameObject.GetComponent<Roomba>().Stun();
        }
		else if (col.gameObject.name == "Player 1" && dropper.name == "Player 2")
		{
			col.gameObject.GetComponent<Roomba>().Stun();
		}
    }
}

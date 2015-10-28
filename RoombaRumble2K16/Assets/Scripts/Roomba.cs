using UnityEngine;
using System.Collections;

public class Roomba : MonoBehaviour {

    private int weaponID;
	private int health;
	public int Health {
		get {
			return health;
		}
		set {
			health = value;
		}
	}

    private float radius;

    public int playerID;
	public int PlayerID {
		get {
			return playerID;
		}
		set {
			playerID = value;
		}
	}

	// Use this for initialization
	void Start () {
        health = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			GetComponent<RoombaController>().enabled = false;
		}
	}
    public void Stun()
    {
        StartCoroutine(Stunned());
    }
    private IEnumerator Stunned()
    {
        this.GetComponent<RoombaController>().enabled = false;
        Debug.Log("Stunned");

        yield return new WaitForSeconds(1.50f);

        Debug.Log("unStunned");
        this.GetComponent<RoombaController>().enabled = true;
    }
	public void Slow()
	{
		StartCoroutine(Slowed());
	}
	private IEnumerator Slowed()
	{
		this.GetComponent<RoombaController>().Slow = true;
		Debug.Log("Slowed");
		
		yield return new WaitForSeconds(1.5f);
		
		Debug.Log("unSlowed");
		this.GetComponent<RoombaController>().Slow = false;
	}
}

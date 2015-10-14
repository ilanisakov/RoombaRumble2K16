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

    private int playerID;
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
        health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			GetComponent<CharacterController>().enabled = false;
		}
	}

    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //    effectsHelper.Instance.Explosion(transform.position);

    //}
}

using UnityEngine;
using System.Collections;

public class WeaponCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
		string n = collision.gameObject.name;
		//Vector2 collVec = collision.gameObject.transform.position - this.gameObject.transform.position;
		Vector2 collVec = -collision.contacts[0].normal;
		if (n.Contains ("Player")) {
			collision.gameObject.GetComponent<Roomba>().Health--;
			//collision.gameObject.GetComponent<RoombaController>().KnockBack(collVec);
		}
    }
}

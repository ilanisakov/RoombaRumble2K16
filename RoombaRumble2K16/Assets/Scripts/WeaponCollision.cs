using UnityEngine;
using System.Collections;

public class WeaponCollision : MonoBehaviour {

    public float radiusX = 0;
    public float radiusY = 0;

   
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
			collision.gameObject.GetComponent<RoombaController>().KnockBack(collVec);
		}

        if (transform.position.x < 0)
        {
            radiusX *= -1;
        }
        if (transform.position.y < 0)
        {
            radiusY *= -1;
        }
        //make the sparks happen on the outside of the weapon
        effectsHelper.Instance.Explosion(transform.position);
    }
}

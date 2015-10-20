using UnityEngine;
using System.Collections;

public class WeaponCollision : MonoBehaviour {

    public float radiusX = 0;
    public float radiusY = 0;

	public int weaponID;		//Used for collision, buzzsaw is 1, rocket 2, mine 3

	private int counter;
   
	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (weaponID == 2 && counter >= 5){
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
		if (weaponID == 3 && counter >= 30){
			this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
		}
		counter++;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
		string n = collision.gameObject.name;
		//Vector2 collVec = collision.gameObject.transform.position - this.gameObject.transform.position;
		if (weaponID == 1){
			Vector2 collVec = -collision.contacts[0].normal;
			if (n.Contains ("Player")) {
				collision.gameObject.GetComponent<Roomba>().Health--;
				collision.gameObject.GetComponent<RoombaController>().KnockBack(collVec);
			}
		}
		if (weaponID == 2){
			if (n.Contains("Player")){
				collision.gameObject.GetComponent<Roomba>().Health -= 5;
			}
			Debug.Log(n);
			Destroy(this.gameObject);
		}
		if (weaponID == 3){
			if (n.Contains("Player")){
				collision.gameObject.GetComponent<Roomba>().Health -= 10;
			}
			Destroy(this.gameObject);
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
        effectsHelper.Instance.Explosion(transform.position, Quaternion.identity);
    }
}

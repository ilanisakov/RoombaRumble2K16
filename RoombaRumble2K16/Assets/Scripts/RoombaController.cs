using UnityEngine;
using System.Collections;

public class RoombaController : MonoBehaviour {

    private float speed;
    private float maxSpeed;
    private float acceleration;
    private float friction;
    private int playerID;
	private Vector2 knockVec;
	private bool knockingBack;
	private int knockCounter = 0;

    GameObject meleeWeapon;
    public GameObject meleePrefab;

	// Use this for initialization
	void Start () {
        speed = 0f;
        maxSpeed = 5f;
        acceleration = .5f;
        friction = .9f;
        playerID = this.GetComponent<Roomba>().PlayerID;

        meleeWeapon = (GameObject)Instantiate(meleePrefab, transform.position, transform.rotation);
        meleeWeapon.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if((playerID == 1 && Input.GetKey(KeyCode.W)) || (playerID == 2 && Input.GetKey(KeyCode.UpArrow)))
        {
            speed += acceleration;
        }
        if ((playerID == 1 && Input.GetKey(KeyCode.A)) || (playerID == 2 && Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Rotate(Vector3.forward * 180 * Time.deltaTime);
        }
        if ((playerID == 1 && Input.GetKey(KeyCode.S)) || (playerID == 2 && Input.GetKey(KeyCode.DownArrow)))
        {
            speed -= acceleration;
        }
        if ((playerID == 1 && Input.GetKey(KeyCode.D)) || (playerID == 2 && Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Rotate(Vector3.forward * -180 * Time.deltaTime);
        }
        if((playerID == 1 && Input.GetKey(KeyCode.B)) || (playerID == 2 && Input.GetKey(KeyCode.Keypad1)))
        {
            meleeWeapon.GetComponent<Weapon>().Fire();
        }

        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        speed = speed * friction;
		if (knockingBack){
			transform.Translate(knockVec * maxSpeed * Time.deltaTime);
			knockCounter++;
			if (knockCounter >= 15){
				knockingBack = false;
				knockCounter = 0;
			}
		}
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

	public void KnockBack(Vector2 otherVec){
		knockVec = otherVec;
		knockingBack = true;
		//transform.Translate(otherVec * (maxSpeed * 0.25f));
	}
}

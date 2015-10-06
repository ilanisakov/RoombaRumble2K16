using UnityEngine;
using System.Collections;

public class RoombaController : MonoBehaviour {

    private float speed;
    private float maxSpeed;
    private float acceleration;
    private float friction;
    private int playerID;

	// Use this for initialization
	void Start () {
        speed = 0f;
        maxSpeed = 5f;
        acceleration = .5f;
        friction = .9f;
        playerID = this.GetComponent<Roomba>().PlayerID;
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

        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        speed = speed * friction;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}

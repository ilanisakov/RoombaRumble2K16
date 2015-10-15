using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
        speed = 20;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}

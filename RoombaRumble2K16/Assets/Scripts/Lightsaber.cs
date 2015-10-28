using UnityEngine;
using System.Collections;

public class Lightsaber : Weapon {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Fire()
    {
        transform.transform.Rotate(Vector3.forward * 360 * Time.deltaTime);
    }
}

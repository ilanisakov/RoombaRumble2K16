using UnityEngine;
using System.Collections;

public class Buzzsaw : Weapon {

    public GameObject buzzsaw1;
    public GameObject buzzsaw2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public override void Fire ()
    {
        buzzsaw1.transform.Rotate(Vector3.forward * 720 * Time.deltaTime);
        buzzsaw2.transform.Rotate(Vector3.forward * -720 * Time.deltaTime);
    }

    public override void StopFire()
    {

    }
}

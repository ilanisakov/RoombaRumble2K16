using UnityEngine;
using System.Collections;

public class Flamethrower : Weapon {

    public GameObject flamethrower;
    private ParticleSystem flame;

    private bool firing;
	// Use this for initialization
	void Start () {
        flame = flamethrower.GetComponent<ParticleSystem>();
        flame.enableEmission = false;
        this.GetComponent<PolygonCollider2D>().enabled = false;
        firing = false;
        Debug.Log(flame);
	}
	
	// Update is called once per frame
	void Update () {
        if (firing)
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<PolygonCollider2D>().enabled = false;
        }
	}
    public override void Fire()
    {
        flame.enableEmission = true;
        firing = true;
    }
    public override void StopFire()
    {
        Debug.Log("STOP");
        flame.enableEmission = false;
        firing = false;
    }
}

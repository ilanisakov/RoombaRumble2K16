using UnityEngine;
using System.Collections;

public class Missile_Pod : Weapon {

    public GameObject missile_pod1;
    public GameObject missile_pod2;

    public GameObject projectile;

    private bool canFire;
    private bool alternateFire;

	// Use this for initialization
	void Start () {

        canFire = true;
        alternateFire = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Fire()
    {
        if(canFire)
        {
            StartCoroutine(Launch());
        }
    }
    public override void StopFire()
    {

    }
    // method to fire rockets
    IEnumerator Launch()
    {
        canFire = false;
        if (alternateFire)
        {
            Instantiate(projectile, missile_pod2.transform.position, missile_pod2.transform.rotation);
        }
        else
        {
            Instantiate(projectile, missile_pod1.transform.position, missile_pod1.transform.rotation);
        }
        alternateFire = !alternateFire;
        yield return new WaitForSeconds(.3f);
        canFire = true;
    }
}

using UnityEngine;
using System.Collections;

public class Monkey_Gun : Weapon {
    public GameObject monkeyGun;
    public GameObject projectile;

    private bool canFire;
    // Use this for initialization
    void Start () {
        canFire = true;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    public override void Fire()
    {
        if (canFire)
        {
            StartCoroutine(Launch());
        }
    }

    public override void StopFire()
    {

    }
    // method to fire poop
    IEnumerator Launch()
    {
        canFire = false;
        Instantiate(projectile, monkeyGun.transform.position, monkeyGun.transform.rotation);
        yield return new WaitForSeconds(.3f);
        canFire = true;
    }
}

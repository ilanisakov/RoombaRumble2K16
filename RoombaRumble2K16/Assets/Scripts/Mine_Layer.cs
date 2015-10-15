using UnityEngine;
using System.Collections;

public class Mine_Layer : Weapon {

    public GameObject mine_layer1;
    public GameObject mine_layer2;

    public GameObject mine;

    private bool canFire;
    private bool alternateFire;

    // Use this for initialization
    void Start()
    {

        canFire = true;
        alternateFire = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Fire()
    {
        if (canFire)
        {
            StartCoroutine(Launch());
        }
    }

    // method to fire rockets
    IEnumerator Launch()
    {
        canFire = false;
        if (alternateFire)
        {
            Instantiate(mine, mine_layer2.transform.position, mine_layer2.transform.rotation);
        }
        else
        {
            Instantiate(mine, mine_layer1.transform.position, mine_layer1.transform.rotation);
        }
        alternateFire = !alternateFire;
        yield return new WaitForSeconds(.3f);
        canFire = true;
    }
}

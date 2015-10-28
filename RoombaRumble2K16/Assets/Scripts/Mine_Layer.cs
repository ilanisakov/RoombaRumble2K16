using UnityEngine;
using System.Collections;

public class Mine_Layer : Weapon {

    public GameObject mine_layer1;
    public GameObject mine_layer2;

    public GameObject mine;

    private bool canFire;
    private bool alternateFire;

	private float timer;

    // Use this for initialization
    void Start()
    {
        canFire = true;
        alternateFire = false;
		timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (timer >= 3){
			canFire = true;
		}
		timer += Time.deltaTime;
    }

    public override void Fire(GameObject activator)
    {
		if (canFire){
			if (alternateFire){
				Instantiate(mine, mine_layer2.transform.position, mine_layer2.transform.rotation);
			}
			else{
				Instantiate(mine, mine_layer1.transform.position, mine_layer1.transform.rotation);
			}
			alternateFire = !alternateFire;
			canFire = false;
			timer = 0;
		}
    }

    public override void StopFire()
    {
    }
}

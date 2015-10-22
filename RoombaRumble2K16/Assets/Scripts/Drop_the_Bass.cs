using UnityEngine;
using System.Collections;

public class Drop_the_Bass : Weapon {

    public GameObject theBass;
    public GameObject bassPrefab;
    public GameObject water;

	private GameObject dropper;

    private GameObject droppedBass;
    private GameObject stunArea;
    private bool droppingTheBass;
    private bool dropping;
    private float scale;
    private float waterScale;
    private Vector3 bassPos;
    private Quaternion bassRot;

	private float timer;
	private bool canFire;

	// Use this for initialization
	void Start () {
        Hide();
        
        droppingTheBass = false;
        dropping = false;
        bassRot = Quaternion.identity;
        waterScale = 0.9f;
		canFire = true;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (droppingTheBass)
        {
            if (dropping) //If the bass has just been droppedd
            {
                theBass.transform.localScale = new Vector3(scale, scale, scale);
                theBass.transform.rotation = Quaternion.identity;
                scale -= 0.5f;
                if (scale <= 10.0f)
                {
                    dropping = false;
                    bassPos = this.transform.position;
                    droppedBass = (GameObject)Instantiate(bassPrefab, bassPos, bassRot);
					droppedBass.GetComponent<DroppedBassCollider>().Dropper = dropper;
                    stunArea = (GameObject)Instantiate(water, bassPos, bassRot);
                    stunArea.transform.localScale = new Vector3(waterScale, waterScale, waterScale);
                    Hide();
                    Invoke("Destroy", 2.0f); // calling hide 2 seconds after the bass drops

                }
            }
            else
            {
               // Stun();
            }
        }
		if (timer >= 3){
			canFire = true;
		}
		timer += Time.deltaTime;
	}

    public override void Fire(GameObject activator)
    {
		if (canFire){
  	      	droppingTheBass = true;
  	      	dropping = true;
  	      	theBass.transform.localScale = new Vector3(scale, scale, scale);
  	      	theBass.GetComponent<SpriteRenderer>().enabled = true;
			dropper = activator;
			canFire = false;
			timer = 0;
		}
    }

    private void Hide()
    {
        theBass.GetComponent<SpriteRenderer>().enabled = false;
        dropping = false;
        scale = 30.0f;
    }

    private void Destroy()
    {
        stunArea.SetActive(false);
        droppedBass.SetActive(false);
        droppingTheBass = false;
    }
}

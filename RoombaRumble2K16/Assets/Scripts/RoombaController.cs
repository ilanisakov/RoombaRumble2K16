﻿using UnityEngine;
using System.Collections;

public class RoombaController : MonoBehaviour
{

    private float speed;
    private float acceleration;
    private float friction;

    private float maxSpeed;
    private float boostSpeed;
    private int playerID;
	private Vector2 knockVec;
	private bool knockingBack;
	private bool slowed;
	private int knockCounter = 0;

    GameObject meleeWeapon;
    public GameObject meleePrefab;

    GameObject rangedWeapon;
    public GameObject rangedPrefab;

    GameObject activeItem;
    public GameObject activePrefab;

    // Use this for initialization
    void Start()
    {
        speed = 0f;
        maxSpeed = 5f;
        boostSpeed = 10f;
        acceleration = .5f;
        friction = .9f;
        playerID = this.GetComponent<Roomba>().PlayerID;

        meleeWeapon = (GameObject)Instantiate(meleePrefab, transform.position, transform.rotation);
        meleeWeapon.transform.parent = this.transform;

        rangedWeapon = (GameObject)Instantiate(rangedPrefab, transform.position, transform.rotation);
        rangedWeapon.transform.parent = this.transform;

        activeItem = (GameObject)Instantiate(activePrefab, transform.position, transform.rotation);
        activeItem.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // reset booster
        maxSpeed = 5f;

        if ((playerID == 1 && Input.GetKey(KeyCode.W)) || (playerID == 2 && Input.GetKey(KeyCode.UpArrow)))
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
        if ((playerID == 1 && Input.GetKey(KeyCode.B)) || (playerID == 2 && Input.GetKey(KeyCode.Keypad1)))
        {
            meleeWeapon.GetComponent<Weapon>().Fire();
        }
        if ((playerID == 1 && Input.GetKeyUp(KeyCode.B)) || (playerID == 2 && Input.GetKeyUp(KeyCode.Keypad1)))
        {
            Debug.Log(meleeWeapon.GetComponent<Weapon>().name);
            if(meleeWeapon.GetComponent<Weapon>().name.Contains("Flamethrower"))
            {
                meleeWeapon.GetComponent<Weapon>().StopFire();
            }
        }
        if ((playerID == 1 && Input.GetKey(KeyCode.M)) || (playerID == 2 && Input.GetKey(KeyCode.Keypad3)))
        {
			activeItem.GetComponent<Weapon>().Fire(this.gameObject);
        }
        if ((playerID == 1 && Input.GetKey(KeyCode.Space)) || (playerID == 2 && Input.GetKey(KeyCode.Keypad0)))
        {
            maxSpeed = boostSpeed;
            speed += acceleration * 2;
            effectsHelper.Instance.Boost(transform.position, transform.rotation);
        }
        else if ((playerID == 1 && Input.GetKey(KeyCode.N)) || (playerID == 2 && Input.GetKey(KeyCode.Keypad2)))
        {
            rangedWeapon.GetComponent<Weapon>().Fire();
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
		if (slowed) {
			speed = speed * 0.7f;
		}

        //Debug.Log(speed + ", " + maxSpeed);
        speed = speed * friction;
		if (knockingBack){
			transform.Translate(knockVec * maxSpeed * Time.deltaTime);
			knockCounter++;
			if (knockCounter >= 15){
				knockingBack = false;
				knockCounter = 0;
			}
		}
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

	public void KnockBack(Vector2 otherVec){
		knockVec = otherVec;
		knockingBack = true;
		//transform.Translate(otherVec * (maxSpeed * 0.25f));
	}

	public bool Slow
	{
		get { return slowed;}
		set { slowed = value;}
	}

	public GameObject MeleePrefab {
		get { return meleePrefab;}
		set { meleePrefab = value;}
	}

	public GameObject RangedPrefab {
		get { return rangedPrefab;}
		set { rangedPrefab = value;}
	}

	public GameObject ActivePrefab {
		get { return activePrefab;}
		set { activePrefab = value;}
	}
}

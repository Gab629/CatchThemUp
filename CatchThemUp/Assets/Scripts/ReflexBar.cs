using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexBar : MonoBehaviour
{

    
    private Rigidbody2D rbTrigger;

    private float direction = 1;
    public float speed = 160f;

    public bool isOnHotSpot = false;

    [SerializeField] GameObject player;



    void Start()
    {
        rbTrigger = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        MoveTrigger();
        CatchFish();
    }

    private void CatchFish()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnHotSpot)
        {
            player.GetComponent<FishingMecanic>().FishCatched();
        }
    }

    private void MoveTrigger()
    {

        
        Vector2 directionVector = new Vector2(direction * speed, gameObject.transform.position.y);
        rbTrigger.velocity = directionVector;


        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "HotSpot")
        {
            isOnHotSpot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "ReflexBar")
        {
            direction = -direction;
        }
        else if(collision.transform.tag == "HotSpot")
        {
            isOnHotSpot = false;
        }
    }

}

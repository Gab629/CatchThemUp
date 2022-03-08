using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexBar : MonoBehaviour
{

    
    private Rigidbody2D rbTrigger;

    private float directionSpeed = 150f;

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

        
        Vector2 directionVector = new Vector2(directionSpeed, gameObject.transform.position.y);
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
            directionSpeed = -directionSpeed;
        }else if(collision.transform.tag == "HotSpot")
        {
            isOnHotSpot = false;
        }
    }

}

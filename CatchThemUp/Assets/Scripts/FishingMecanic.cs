using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FishingMecanic : MonoBehaviour
{
    public Camera cam;
    public GameObject gameManager;

    private GameObject fishingLine;
    private bool isCurrentFish;

    private GameObject currentFish;

    private int score;

    public GameObject trigger;
    public GameObject reflexBar;


    private void Start()
    {
        fishingLine = GameObject.Find("LineRenderer");
        fishingLine.GetComponent<LineControler>().isFish = false;

        reflexBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



       ClickOnFish();
       

    }

  
    private void ClickOnFish()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.name == "Poisson(Clone)")
                {
                    isCurrentFish = fishingLine.GetComponent<LineControler>().isFish = true;
                    fishingLine.GetComponent<LineControler>().fishCatched = hit.transform.gameObject;
                    currentFish = hit.transform.gameObject;


                    score = hit.transform.gameObject.GetComponent<Fish>().scorePoisson;
                    reflexBar.SetActive(true);


                }
            }
        }
    }


    public void FishCatched()
    {
        Destroy(currentFish);
        gameManager.GetComponent<GameManager>().score += score;
        fishingLine.GetComponent<LineControler>().isFish = false;

        if (trigger.GetComponent<ReflexBar>().speed >= -600f && trigger.GetComponent<ReflexBar>().speed <= 600f)
        {
            trigger.GetComponent<ReflexBar>().speed += 20;
            gameManager.GetComponent<GameManager>().timer += 3f;
        }

        reflexBar.SetActive(false);
    }


    
    
}

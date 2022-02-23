using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FishingMecanic : MonoBehaviour
{
    private GameObject currentClickedGameObject;
    public Camera cam;
    public GameObject gameManager;

    

    // Update is called once per frame
    void Update()
    {
 
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if(hit.transform.name == "Poisson")
                {
                    int score = hit.transform.gameObject.GetComponent<Fish>().scorePoisson;
                    int health = hit.transform.gameObject.GetComponent<Fish>().health --;
                    gameManager.GetComponent<GameManager>().score += score;
                    

                }


            }
        }
    }

    
    
}

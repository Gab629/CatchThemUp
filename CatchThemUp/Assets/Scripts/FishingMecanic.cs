using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FishingMecanic : MonoBehaviour
{
    private GameObject currentClickedGameObject;
    public Camera cam;
    public GameObject gameManager;

    //Mouvement poisson
    public float speed = 2f;
    public Transform target;

    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private float rotationOffset = 90;


    // Start is called before the first frame update
    void Start()
    {
         target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

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
                    gameManager.GetComponent<GameManager>().score += score;
                }
                
            }
        }
    }

    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int scorePoisson;
    public float speed = 2f;
    public int health;



    //Mouvement poisson
    
    private Transform target;
    private string targetName = "Target";
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private float rotationOffset = -90;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(targetName + Random.Range(1, 8).ToString()).GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        float distance = Vector2.Distance(transform.position, target.position);
        if(distance <= 0){
            target = GameObject.Find(targetName + Random.Range(1, 11).ToString()).GetComponent<Transform>();
        }


    }

}

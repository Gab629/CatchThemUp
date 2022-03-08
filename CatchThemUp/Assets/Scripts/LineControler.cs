using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControler : MonoBehaviour
{

    private LineRenderer lineRenderer;
    public Vector3[] points;

    public GameObject fishingRod;
    public GameObject fishCatched;

    public bool isFish = false; 

    private void Awake()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        

    }

    private void Update()
    {


        IsFish();
    }

    private void IsFish()
    {
        if (isFish != false)
        {
            lineRenderer.enabled = true;
            SetupLine(points);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    



    public void SetupLine(Vector3[] pointsPosition)
    {   
        Vector3 playerPos = fishingRod.transform.position;
        Vector3 fishPos = fishCatched.transform.position;

        points = new Vector3[2] { playerPos, fishPos};


        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(pointsPosition);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControler : MonoBehaviour
{

    private LineRenderer lineRenderer;
    public Vector3[] points;

    public GameObject fishingRod;
    public GameObject fishCatched;

    private void Awake()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        

    }

    private void Update()
    {

        SetFishPosition();
        SetupLine(points);
    }

    void SetFishPosition()
    {

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

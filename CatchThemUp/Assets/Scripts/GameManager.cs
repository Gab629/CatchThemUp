using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private float timer = 30f;
    public Text texteScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AfficherTemps();
    }

    private void AfficherTemps()
    {
        timer -= Time.deltaTime;
        texteScore.text = Mathf.Round(timer).ToString();


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float timer = 60f;
    public Text texteTemps;
    public int score = 20;
    public Text texteScore;

    

    // Update is called once per frame
    void Update()
    {
        AfficherTemps();
        AfficherScore();
    }

    private void AfficherTemps()
    {
        timer -= Time.deltaTime;
        texteTemps.text = Mathf.Round(timer).ToString();

        if(timer <= 0)
        {
            timer = 0;
            SceneManager.LoadScene("End");
        }

    }
    
    private void AfficherScore()
    {
        texteScore.text = score.ToString() + " points";


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalcutor : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text scoreText;
    public void Score(int scoreValue)
    {
        score = score + scoreValue;
        
        scoreText.text ="Score: " +score.ToString();
        Debug.Log(score);

    }
}

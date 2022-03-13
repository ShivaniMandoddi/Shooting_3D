using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalcutor : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public void Score(int scoreValue)
    {
        score = score + scoreValue;
        Debug.Log(score);

    }
}

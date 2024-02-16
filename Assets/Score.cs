using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private TMP_Text scoreText;
    private int scoreCount;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.SetText("0");
    }

    public void UpdateScore(int point)
    {
        scoreCount += point;
        scoreText.SetText(scoreCount.ToString());
    }
}

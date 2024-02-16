using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mole : MonoBehaviour
{
    private Score score;
    private bool readyToDeactivate;
    private float lifeSpan;
    private int pointAmount;

    private void Awake()
    {
        score = GameObject.Find("Text_Score").GetComponent<Score>();
    }
    private void Update()   
    {
        if (readyToDeactivate)  // deactivate self
        {
            lifeSpan -= Time.deltaTime;
            if (lifeSpan <= 0)
            {
                Destroy(gameObject);
                readyToDeactivate = false;
            }
        }
    }

    public void IncreaseScore()     // use by self
    {
        Destroy(gameObject);
        score.UpdateScore(pointAmount);
    }
    public void SetDifficulty(float lifeSpan, int pointAmount)    // use by spawner
    {
        this.lifeSpan = lifeSpan;
        this.pointAmount = pointAmount;
        readyToDeactivate = true;
    }
}

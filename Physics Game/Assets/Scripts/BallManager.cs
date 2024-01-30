using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform spawnPoint;
    [SerializeField] PatternManager pm;
    [SerializeField] Image timeWheel;

    public float dropTime;

    float timeElapsed = 0;
    private void Update()
    {
        if (timeElapsed < dropTime)
        {
            timeElapsed += Time.deltaTime;
            timeWheel.fillAmount = (dropTime - timeElapsed) / 5;
        }
        else
        {
            SpawnBall(true);
        }
    }


    public void SpawnBall(bool resetTime)
    {
        if (resetTime)
        {
            timeElapsed = 0;
        }
        Instantiate(ball, spawnPoint.position, ball.transform.rotation);
    }
}

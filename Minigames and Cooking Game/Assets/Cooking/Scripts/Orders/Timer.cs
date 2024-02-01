using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit;
    public TextMeshProUGUI timeText;

    float timeElapsed;

    private void Start()
    {
        timeElapsed = 0;
    }

    private void Update()
    {
        if (timeElapsed <= timeLimit)
        {
            timeElapsed += Time.deltaTime;
            timeText.text = Mathf.Round(timeLimit - timeElapsed).ToString();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}

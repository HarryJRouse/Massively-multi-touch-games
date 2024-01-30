using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeStart : MonoBehaviour
{
    public bool modeRunning = false;
    public Canvas canvas;
    public TextMeshProUGUI player1Timer;
    public TextMeshProUGUI player2Timer;

    private float timeRemaining = 3;

    void Awake()
    {
        StartCoroutine(DisplayModeText());
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining >= 2)
            {
                player1Timer.SetText(3.ToString());
                player2Timer.SetText(3.ToString());
            }
            else if (timeRemaining >=1 && timeRemaining < 2)
            {
                player1Timer.SetText(2.ToString());
                player2Timer.SetText(2.ToString());
            }
            else if (timeRemaining > 0 && timeRemaining < 1)
            {
                player1Timer.SetText(1.ToString());
                player2Timer.SetText(1.ToString());
            }

        }
    }

    IEnumerator DisplayModeText()
    {
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas.gameObject.SetActive(false);
        modeRunning = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] TextMeshProUGUI timerText;

    public float wordDisplayTime;

    float elapsedTime = 0;
    WordToGuess wtg;
    GuessInputs gi;


    private void Start()
    {
        wtg = FindObjectOfType<WordToGuess>();
        gi = FindObjectOfType<GuessInputs>();
        DisplayWord();
    }

    private void Update()
    {
        if (elapsedTime < wordDisplayTime)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = Mathf.Round(wordDisplayTime - elapsedTime + 1).ToString();

            if (elapsedTime >= wordDisplayTime)
            {
                TurnOffWord();
                gi.trackTime = true;
            }
        }
    }

    public void DisplayWord()
    {
        text1.text = wtg.word;
        text2.text = wtg.word;
    }

    void TurnOffWord()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }
}

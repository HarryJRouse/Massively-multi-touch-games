using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject CustomPrompt;
    [SerializeField] GameObject randomButton;

    WordToGuess wtg;

    private void Start()
    {
        wtg = FindObjectOfType<WordToGuess>();
    }

    public void RandomWord()
    {
        int wordIndex = Random.Range(0, wtg.possibleWords.Length);

        wtg.word = wtg.possibleWords[wordIndex];

        SceneManager.LoadScene(1);
    }

    public void AcceptWord()
    {
        if (inputField.text != "")
        {
            wtg.word = inputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void CustomWord()
    {
        CustomPrompt.SetActive(true);
        randomButton.SetActive(false);
        inputField.ActivateInputField();
    }
}

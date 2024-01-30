using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GuessInputs : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI guessedWords;
    [SerializeField] TextMeshProUGUI guessedWords2;
    [SerializeField] TextMeshProUGUI timeElapsedText;
    [SerializeField] GameObject guessedIt;

    int wordsGuessed = 0;
    float timeElapsed = 0;
    public bool trackTime = false;
    
    WordToGuess wtg;


    private void Start()
    {
        inputField = GameObject.Find("GuessInput").GetComponent<TMP_InputField>();
        wtg = FindObjectOfType<WordToGuess>();
    }

    private void Update()
    {
        inputField.ActivateInputField();
        if (trackTime)
        {
            timeElapsed += Time.deltaTime;
            timeElapsedText.text = Mathf.Round(timeElapsed).ToString();
        }
    }

    public void MakeGuess()
    {
        if (inputField.text.Replace(" ", "") != "")
        {
            wordsGuessed++;
            if (wordsGuessed < 25)
            {
                guessedWords.text = guessedWords.text + inputField.text + "\n";
            }
            else
            {
                guessedWords2.text = guessedWords2.text + inputField.text + "\n";
            }
            if (inputField.text.ToLower() == wtg.word.ToLower())
            {
                trackTime = false;
                guessedIt.SetActive(true);
            }
            inputField.text = "";
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

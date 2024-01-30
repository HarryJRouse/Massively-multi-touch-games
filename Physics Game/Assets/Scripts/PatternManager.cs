using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    [SerializeField] List<MeshRenderer> patternDisplay;
    [SerializeField] List<Material> materials;
    [SerializeField] GameObject winScreen;

    public int patternLength;
    public int maxIndex;
    public BallManager bm;

    public List<int> patternToMatch;
    public List<int> currentPattern;

    int score = 0;

    private void Start()
    {
        NewPattern(patternLength);   
    }


    void NewPattern(int patternLength)
    {
        patternToMatch.Clear();
        for (int i = 0; i < patternLength; i++)
        {
            int c = Random.Range(0, maxIndex);
            patternToMatch.Add(c);
            patternDisplay[i].material = materials[c + 1];
        }
    }

    public void CheckPattern(int colorIndex)
    {
        if (colorIndex == patternToMatch[currentPattern.Count])
        {
            currentPattern.Add(colorIndex);
            patternDisplay[currentPattern.Count - 1].material = materials[0];
            if (currentPattern.Count == patternToMatch.Count)
            {
                score++;
                if (score == 4)
                {
                    winScreen.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    bm.SpawnBall(false);
                    patternLength++;
                    NewPattern(patternLength);
                    currentPattern.Clear();
                }
            }
        }
        else
        {
            currentPattern.Clear();
            for (int i = 0; i < patternLength; i++)
            {
                patternDisplay[i].material = materials[patternToMatch[i] + 1];
            }
        }
    }
}

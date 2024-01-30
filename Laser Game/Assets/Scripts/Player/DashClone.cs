using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashClone : MonoBehaviour
{
    public Color originalColor;
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float duration = 1;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(originalColor, Color.clear, timeElapsed / duration);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

}

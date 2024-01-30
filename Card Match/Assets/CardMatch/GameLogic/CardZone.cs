using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour
{
    public int player;

    public GameObject card = null;

    public CardZone connectedZone;

    public ParticleSystem particle;

    public Transform particle1Spawn;
    public Transform particle2Spawn;

    ScoreManager sm;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        card = other.gameObject;
        if (card != null && connectedZone.card != null)
        {
            if (card.CompareTag(connectedZone.card.tag) && card != connectedZone.card)
            {
                Instantiate(particle, particle1Spawn.position, Quaternion.identity);
                Instantiate(particle, particle2Spawn.position, Quaternion.identity);
                sm.IncrementScore(player);
                Destroy(connectedZone.card);
                Destroy(card);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(SetNullValue());
    }

    IEnumerator SetNullValue()
    {
        yield return new WaitForEndOfFrame();
        card = null;
    }
}

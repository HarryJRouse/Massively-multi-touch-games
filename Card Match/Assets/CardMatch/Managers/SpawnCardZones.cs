using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCardZones : MonoBehaviour
{
    ScoreManager sm;

    public List<GameObject> cardZones = new();
    public List<GameObject> scoreUIs = new();
    public ParticleSystem particle;
    public Transform parentCanvas;
    public TextMeshProUGUI textPrefab;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();

        switch (sm.players)
        {
            case 2:
                Spawn2();
                break;
            case 3:
                Spawn3();
                break;
            case 4:
                Spawn4();
                break;
            case 5:
                Spawn5();
                break;
            case 6:
                Spawn6();
                break;
            case 7:
                Spawn7();
                break;
            case 8:
                Spawn8();
                break;
        }
    }

    void Spawn2()
    {
        int i = 1;
        while (i <= sm.players)
        {
            switch(i)
            {
                case 1:
                    GameObject zone = Instantiate(cardZones[0], new Vector3(0, 4.3f, 1), Quaternion.identity);
                    CardZone[] zoneChildren = zone.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zoneChildren)
                    {
                        z.player = 1;
                        z.particle = particle;
                        z.particle1Spawn = zoneChildren[0].transform;
                        z.particle2Spawn = zoneChildren[1].transform;
                    }
                    TextMeshProUGUI text = Instantiate(textPrefab, new Vector3(0, 366, 1), Quaternion.Euler(0, 0, 180));
                    text.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text);
                    break;
                case 2:
                    GameObject zone2 = Instantiate(cardZones[1], new Vector3(0, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone2Children = zone2.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone2Children)
                    {
                        z.player = 2;
                        z.particle = particle;
                        z.particle1Spawn = zone2Children[0].transform;
                        z.particle2Spawn = zone2Children[1].transform;
                    }
                    TextMeshProUGUI text2 = Instantiate(textPrefab, new Vector3(0, -366, 1), Quaternion.Euler(0, 0, 0));
                    text2.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text2);
                    break;
            }
            i++;
        }
    }

    void Spawn3()
    {
        int i = 1;
        while (i <= sm.players)
        {
            switch (i)
            {
                case 1:
                    GameObject zone = Instantiate(cardZones[0], new Vector3(-4, 4.3f, 1), Quaternion.identity);
                    CardZone[] zoneChildren = zone.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zoneChildren)
                    {
                        z.player = 1;
                        z.particle = particle;
                        z.particle1Spawn = zoneChildren[0].transform;
                        z.particle2Spawn = zoneChildren[1].transform;
                    }
                    TextMeshProUGUI text = Instantiate(textPrefab, new Vector3(-442, 370, 1), Quaternion.Euler(0, 0, 180));
                    text.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text);
                    break;
                case 2:
                    GameObject zone2 = Instantiate(cardZones[1], new Vector3(4, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone2Children = zone2.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone2Children)
                    {
                        z.player = 2;
                        z.particle = particle;
                        z.particle1Spawn = zone2Children[0].transform;
                        z.particle2Spawn = zone2Children[1].transform;
                    }
                    TextMeshProUGUI text2 = Instantiate(textPrefab, new Vector3(442, 370, 1), Quaternion.Euler(0, 0, 180));
                    text2.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text2);
                    break;
                case 3:
                    GameObject zone3 = Instantiate(cardZones[2], new Vector3(0, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone3Children = zone3.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone3Children)
                    {
                        z.player = 3;
                        z.particle = particle;
                        z.particle1Spawn = zone3Children[0].transform;
                        z.particle2Spawn = zone3Children[1].transform;
                    }
                    TextMeshProUGUI text3 = Instantiate(textPrefab, new Vector3(0, -370, 1), Quaternion.Euler(0, 0, 0));
                    text3.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text3);
                    break;
            }
            i++;
        }
    }

    void Spawn4()
    {
        int i = 1;
        while (i <= sm.players)
        {
            switch (i)
            {
                case 1:
                    GameObject zone = Instantiate(cardZones[0], new Vector3(-4, 4.3f, 1), Quaternion.identity);
                    CardZone[] zoneChildren = zone.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zoneChildren)
                    {
                        z.player = 1;
                        z.particle = particle;
                        z.particle1Spawn = zoneChildren[0].transform;
                        z.particle2Spawn = zoneChildren[1].transform;
                    }
                    TextMeshProUGUI text = Instantiate(textPrefab, new Vector3(-442, 370, 1), Quaternion.Euler(0, 0, 180));
                    text.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text);
                    break;
                case 2:
                    GameObject zone2 = Instantiate(cardZones[1], new Vector3(4, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone2Children = zone2.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone2Children)
                    {
                        z.player = 2;
                        z.particle = particle;
                        z.particle1Spawn = zone2Children[0].transform;
                        z.particle2Spawn = zone2Children[1].transform;
                    }
                    TextMeshProUGUI text2 = Instantiate(textPrefab, new Vector3(442, 370, 1), Quaternion.Euler(0, 0, 180));
                    text2.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text2);
                    break;
                case 3:
                    GameObject zone3 = Instantiate(cardZones[2], new Vector3(4, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone3Children = zone3.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone3Children)
                    {
                        z.player = 3;
                        z.particle = particle;
                        z.particle1Spawn = zone3Children[0].transform;
                        z.particle2Spawn = zone3Children[1].transform;
                    }
                    TextMeshProUGUI text3 = Instantiate(textPrefab, new Vector3(442, -370, 1), Quaternion.Euler(0, 0, 0));
                    text3.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text3);
                    break;
                case 4:
                    GameObject zone4 = Instantiate(cardZones[3], new Vector3(-4, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone4Children = zone4.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone4Children)
                    {
                        z.player = 4;
                        z.particle = particle;
                        z.particle1Spawn = zone4Children[0].transform;
                        z.particle2Spawn = zone4Children[1].transform;
                    }
                    TextMeshProUGUI text4 = Instantiate(textPrefab, new Vector3(-442, -370, 1), Quaternion.Euler(0, 0, 0));
                    text4.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text4);
                    break;
            }
            i++;
        }
    }

    void Spawn5()
    {
        int i = 1;
        while (i <= sm.players)
        {
            switch (i)
            {
                case 1:
                    GameObject zone = Instantiate(cardZones[0], new Vector3(-4, 4.3f, 1), Quaternion.identity);
                    CardZone[] zoneChildren = zone.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zoneChildren)
                    {
                        z.player = 1;
                        z.particle = particle;
                        z.particle1Spawn = zoneChildren[0].transform;
                        z.particle2Spawn = zoneChildren[1].transform;
                    }
                    TextMeshProUGUI text = Instantiate(textPrefab, new Vector3(-442, 370, 1), Quaternion.Euler(0, 0, 180));
                    text.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text);
                    break;
                case 2:
                    GameObject zone2 = Instantiate(cardZones[1], new Vector3(4, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone2Children = zone2.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone2Children)
                    {
                        z.player = 2;
                        z.particle = particle;
                        z.particle1Spawn = zone2Children[0].transform;
                        z.particle2Spawn = zone2Children[1].transform;
                    }
                    TextMeshProUGUI text2 = Instantiate(textPrefab, new Vector3(442, 370, 1), Quaternion.Euler(0, 0, 180));
                    text2.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text2);
                    break;
                case 3:
                    GameObject zone3 = Instantiate(cardZones[2], new Vector3(6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone3Children = zone3.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone3Children)
                    {
                        z.player = 3;
                        z.particle = particle;
                        z.particle1Spawn = zone3Children[0].transform;
                        z.particle2Spawn = zone3Children[1].transform;
                    }
                    TextMeshProUGUI text3 = Instantiate(textPrefab, new Vector3(645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text3.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text3);
                    break;
                case 4:
                    GameObject zone4 = Instantiate(cardZones[3], new Vector3(0, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone4Children = zone4.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone4Children)
                    {
                        z.player = 4;
                        z.particle = particle;
                        z.particle1Spawn = zone4Children[0].transform;
                        z.particle2Spawn = zone4Children[1].transform;
                    }
                    TextMeshProUGUI text4 = Instantiate(textPrefab, new Vector3(0, -370, 1), Quaternion.Euler(0, 0, 0));
                    text4.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text4);
                    break;
                case 5:
                    GameObject zone5 = Instantiate(cardZones[4], new Vector3(-6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone5Children = zone5.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone5Children)
                    {
                        z.player = 5;
                        z.particle = particle;
                        z.particle1Spawn = zone5Children[0].transform;
                        z.particle2Spawn = zone5Children[1].transform;
                    }
                    TextMeshProUGUI text5 = Instantiate(textPrefab, new Vector3(-645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text5.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text5);
                    break;
            }
            i++;
        }
    }

    void Spawn6()
    {
        int i = 1;
        while (i <= sm.players)
        {
            switch (i)
            {
                case 1:
                    GameObject zone = Instantiate(cardZones[0], new Vector3(-6, 4.3f, 1), Quaternion.identity);
                    CardZone[] zoneChildren = zone.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zoneChildren)
                    {
                        z.player = 1;
                        z.particle = particle;
                        z.particle1Spawn = zoneChildren[0].transform;
                        z.particle2Spawn = zoneChildren[1].transform;
                    }
                    TextMeshProUGUI text = Instantiate(textPrefab, new Vector3(-645, 370, 1), Quaternion.Euler(0, 0, 180));
                    text.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text);
                    break;
                case 2:
                    GameObject zone2 = Instantiate(cardZones[1], new Vector3(0, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone2Children = zone2.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone2Children)
                    {
                        z.player = 2;
                        z.particle = particle;
                        z.particle1Spawn = zone2Children[0].transform;
                        z.particle2Spawn = zone2Children[1].transform;
                    }
                    TextMeshProUGUI text2 = Instantiate(textPrefab, new Vector3(0, 370, 1), Quaternion.Euler(0, 0, 180));
                    text2.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text2);
                    break;
                case 3:
                    GameObject zone3 = Instantiate(cardZones[2], new Vector3(6, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone3Children = zone3.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone3Children)
                    {
                        z.player = 3;
                        z.particle = particle;
                        z.particle1Spawn = zone3Children[0].transform;
                        z.particle2Spawn = zone3Children[1].transform;
                    }
                    TextMeshProUGUI text3 = Instantiate(textPrefab, new Vector3(645, 370, 1), Quaternion.Euler(0, 0, 180));
                    text3.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text3);
                    break;
                case 4:
                    GameObject zone4 = Instantiate(cardZones[3], new Vector3(6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone4Children = zone4.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone4Children)
                    {
                        z.player = 4;
                        z.particle = particle;
                        z.particle1Spawn = zone4Children[0].transform;
                        z.particle2Spawn = zone4Children[1].transform;
                    }
                    TextMeshProUGUI text4 = Instantiate(textPrefab, new Vector3(645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text4.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text4);
                    break;
                case 5:
                    GameObject zone5 = Instantiate(cardZones[4], new Vector3(0, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone5Children = zone5.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone5Children)
                    {
                        z.player = 5;
                        z.particle = particle;
                        z.particle1Spawn = zone5Children[0].transform;
                        z.particle2Spawn = zone5Children[1].transform;
                    }
                    TextMeshProUGUI text5 = Instantiate(textPrefab, new Vector3(0, -370, 1), Quaternion.Euler(0, 0, 0));
                    text5.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text5);
                    break;
                case 6:
                    GameObject zone6 = Instantiate(cardZones[5], new Vector3(-6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone6Children = zone6.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone6Children)
                    {
                        z.player = 6;
                        z.particle = particle;
                        z.particle1Spawn = zone6Children[0].transform;
                        z.particle2Spawn = zone6Children[1].transform;
                    }
                    TextMeshProUGUI text6 = Instantiate(textPrefab, new Vector3(-645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text6.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text6);
                    break;
            }
            i++;
        }
    }

    void Spawn7()
    {
        int i = 1;
        while (i <= sm.players)
        {
            switch (i)
            {
                case 1:
                    GameObject zone = Instantiate(cardZones[0], new Vector3(-6, 4.3f, 1), Quaternion.identity);
                    CardZone[] zoneChildren = zone.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zoneChildren)
                    {
                        z.player = 1;
                        z.particle = particle;
                        z.particle1Spawn = zoneChildren[0].transform;
                        z.particle2Spawn = zoneChildren[1].transform;
                    }
                    TextMeshProUGUI text = Instantiate(textPrefab, new Vector3(-645, 370, 1), Quaternion.Euler(0, 0, 180));
                    text.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text);
                    break;
                case 2:
                    GameObject zone2 = Instantiate(cardZones[1], new Vector3(0, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone2Children = zone2.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone2Children)
                    {
                        z.player = 2;
                        z.particle = particle;
                        z.particle1Spawn = zone2Children[0].transform;
                        z.particle2Spawn = zone2Children[1].transform;
                    }
                    TextMeshProUGUI text2 = Instantiate(textPrefab, new Vector3(0, 370, 1), Quaternion.Euler(0, 0, 180));
                    text2.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text2);
                    break;
                case 3:
                    GameObject zone3 = Instantiate(cardZones[2], new Vector3(6, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone3Children = zone3.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone3Children)
                    {
                        z.player = 3;
                        z.particle = particle;
                        z.particle1Spawn = zone3Children[0].transform;
                        z.particle2Spawn = zone3Children[1].transform;
                    }
                    TextMeshProUGUI text3 = Instantiate(textPrefab, new Vector3(645, 370, 1), Quaternion.Euler(0, 0, 180));
                    text3.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text3);
                    break;
                case 4:
                    GameObject zone4 = Instantiate(cardZones[3], new Vector3(8.2f, 0, 1), Quaternion.Euler(0, 0, 90));
                    CardZone[] zone4Children = zone4.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone4Children)
                    {
                        z.player = 4;
                        z.particle = particle;
                        z.particle1Spawn = zone4Children[0].transform;
                        z.particle2Spawn = zone4Children[1].transform;
                    }
                    TextMeshProUGUI text4 = Instantiate(textPrefab, new Vector3(795, 0, 1), Quaternion.Euler(0, 0, 90));
                    text4.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text4);
                    break;
                case 5:
                    GameObject zone5 = Instantiate(cardZones[4], new Vector3(6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone5Children = zone5.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone5Children)
                    {
                        z.player = 5;
                        z.particle = particle;
                        z.particle1Spawn = zone5Children[0].transform;
                        z.particle2Spawn = zone5Children[1].transform;
                    }
                    TextMeshProUGUI text5 = Instantiate(textPrefab, new Vector3(645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text5.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text5);
                    break;
                case 6:
                    GameObject zone6 = Instantiate(cardZones[5], new Vector3(0, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone6Children = zone6.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone6Children)
                    {
                        z.player = 6;
                        z.particle = particle;
                        z.particle1Spawn = zone6Children[0].transform;
                        z.particle2Spawn = zone6Children[1].transform;
                    }
                    TextMeshProUGUI text6 = Instantiate(textPrefab, new Vector3(0, -370, 1), Quaternion.Euler(0, 0, 0));
                    text6.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text6);
                    break;
                case 7:
                    GameObject zone7 = Instantiate(cardZones[6], new Vector3(-6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone7Children = zone7.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone7Children)
                    {
                        z.player = 7;
                        z.particle = particle;
                        z.particle1Spawn = zone7Children[0].transform;
                        z.particle2Spawn = zone7Children[1].transform;
                    }
                    TextMeshProUGUI text7 = Instantiate(textPrefab, new Vector3(-645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text7.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text7);
                    break;
            }
            i++;
        }
    }

    void Spawn8()
    {
        int i = 1;
        while (i <= sm.players)
        {
            switch (i)
            {
                case 1:
                    GameObject zone = Instantiate(cardZones[0], new Vector3(-6, 4.3f, 1), Quaternion.identity);
                    CardZone[] zoneChildren = zone.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zoneChildren)
                    {
                        z.player = 1;
                        z.particle = particle;
                        z.particle1Spawn = zoneChildren[0].transform;
                        z.particle2Spawn = zoneChildren[1].transform;
                    }
                    TextMeshProUGUI text = Instantiate(textPrefab, new Vector3(-645, 370, 1), Quaternion.Euler(0, 0, 180));
                    text.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text);
                    break;
                case 2:
                    GameObject zone2 = Instantiate(cardZones[1], new Vector3(0, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone2Children = zone2.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone2Children)
                    {
                        z.player = 2;
                        z.particle = particle;
                        z.particle1Spawn = zone2Children[0].transform;
                        z.particle2Spawn = zone2Children[1].transform;
                    }
                    TextMeshProUGUI text2 = Instantiate(textPrefab, new Vector3(0, 370, 1), Quaternion.Euler(0, 0, 180));
                    text2.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text2);
                    break;
                case 3:
                    GameObject zone3 = Instantiate(cardZones[2], new Vector3(6, 4.3f, 1), Quaternion.identity);
                    CardZone[] zone3Children = zone3.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone3Children)
                    {
                        z.player = 3;
                        z.particle = particle;
                        z.particle1Spawn = zone3Children[0].transform;
                        z.particle2Spawn = zone3Children[1].transform;
                    }
                    TextMeshProUGUI text3 = Instantiate(textPrefab, new Vector3(645, 370, 1), Quaternion.Euler(0, 0, 180));
                    text3.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text3);
                    break;
                case 4:
                    GameObject zone4 = Instantiate(cardZones[3], new Vector3(8.2f, 0, 1), Quaternion.Euler(0, 0, 90));
                    CardZone[] zone4Children = zone4.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone4Children)
                    {
                        z.player = 4;
                        z.particle = particle;
                        z.particle1Spawn = zone4Children[0].transform;
                        z.particle2Spawn = zone4Children[1].transform;
                    }
                    TextMeshProUGUI text4 = Instantiate(textPrefab, new Vector3(795, 0, 1), Quaternion.Euler(0, 0, 90));
                    text4.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text4);
                    break;
                case 5:
                    GameObject zone5 = Instantiate(cardZones[4], new Vector3(6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone5Children = zone5.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone5Children)
                    {
                        z.player = 5;
                        z.particle = particle;
                        z.particle1Spawn = zone5Children[0].transform;
                        z.particle2Spawn = zone5Children[1].transform;
                    }
                    TextMeshProUGUI text5 = Instantiate(textPrefab, new Vector3(645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text5.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text5);
                    break;
                case 6:
                    GameObject zone6 = Instantiate(cardZones[5], new Vector3(0, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone6Children = zone6.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone6Children)
                    {
                        z.player = 6;
                        z.particle = particle;
                        z.particle1Spawn = zone6Children[0].transform;
                        z.particle2Spawn = zone6Children[1].transform;
                    }
                    TextMeshProUGUI text6 = Instantiate(textPrefab, new Vector3(0, -370, 1), Quaternion.Euler(0, 0, 0));
                    text6.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text6);
                    break;
                case 7:
                    GameObject zone7 = Instantiate(cardZones[6], new Vector3(-6, -4.3f, 1), Quaternion.identity);
                    CardZone[] zone7Children = zone7.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone7Children)
                    {
                        z.player = 7;
                        z.particle = particle;
                        z.particle1Spawn = zone7Children[0].transform;
                        z.particle2Spawn = zone7Children[1].transform;
                    }
                    TextMeshProUGUI text7 = Instantiate(textPrefab, new Vector3(-645, -370, 1), Quaternion.Euler(0, 0, 0));
                    text7.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text7);
                    break;
                case 8:
                    GameObject zone8 = Instantiate(cardZones[7], new Vector3(-8.2f, 0, 1), Quaternion.Euler(0, 0, 90));
                    CardZone[] zone8Children = zone8.GetComponentsInChildren<CardZone>();
                    foreach (CardZone z in zone8Children)
                    {
                        z.player = 8;
                        z.particle = particle;
                        z.particle1Spawn = zone8Children[0].transform;
                        z.particle2Spawn = zone8Children[1].transform;
                    }
                    TextMeshProUGUI text8 = Instantiate(textPrefab, new Vector3(-795, 0, 1), Quaternion.Euler(0, 0, -90));
                    text8.transform.SetParent(parentCanvas, false);
                    sm.scoreText.Add(text8);
                    break;
            }
            i++;
        }
    }
}

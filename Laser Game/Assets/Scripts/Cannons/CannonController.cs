using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public string cannonType = "laser";

    public List<GameObject> cannonTypes = new();
    public ParticleSystem powerUpFX;

    bool coroutineRunning = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.CompareTag("PowerUp"))
        {
            Instantiate(powerUpFX, obj.transform.position, obj.transform.rotation);

            SwitchCannonType(obj.GetComponent<PowerUp>().powerUpType);

            if (obj.GetComponent<PowerUp>().timedSwitch)
            {
                StartCoroutine(SwitchBackToLaser(obj.GetComponent<PowerUp>().switchBackTime));
            }

            Destroy(obj);
        }
    }

    IEnumerator SwitchBackToLaser(float switchBackTime)
    {
        if (!coroutineRunning)
        {
            coroutineRunning = true;

            yield return new WaitForSeconds(switchBackTime);

            SwitchCannonType("laser");

            coroutineRunning = false;
        }
    }

    public void SwitchCannonType(string type)
    {
        cannonType = type;

        foreach (GameObject cannon in cannonTypes)
        {
            cannon.GetComponent<CannonBase>().fireCoroutineRunning = false;
            if (cannon.name == type)
            {
                cannon.SetActive(true);
                StopAllCoroutines();
                coroutineRunning = false;
            }
            else
            {
                if (cannon.name == "laser")
                {
                    cannon.GetComponent<LaserCannon>().laserLine.SetPosition(0, Vector2.zero);
                    cannon.GetComponent<LaserCannon>().laserLine.SetPosition(1, Vector2.zero);
                }
                cannon.SetActive(false);
            }
        }
    }

    public void Fire()
    {
        switch(cannonType)
        {
            case "laser":
                LaserCannon lc = FindCannon("laser").GetComponent<LaserCannon>();
                lc.Fire();
                break;

            case "fireball":
                FireballCannon fc = FindCannon("fireball").GetComponent<FireballCannon>();
                fc.Fire();
                break;

            case "homing":
                HomingCannon hc = FindCannon("homing").GetComponent<HomingCannon>();
                hc.Fire();
                break;
            case "ice":
                IceCannon ic = FindCannon("ice").GetComponent<IceCannon>();
                ic.Fire();
                break;
        }
    }

    GameObject FindCannon(string cannonType)
    {
        foreach (GameObject cannon in cannonTypes)
        {
            if (cannon.name == cannonType)
            {
                return cannon;
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedAndDeactivateSelf : MonoBehaviour
{
    float timeAlive;
    float particlePlayTime;

    private void OnEnable()
    {
        particlePlayTime = GetComponent<ParticleSystem>().main.startLifetimeMultiplier;
        GetComponent<ParticleSystem>().Play();
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > particlePlayTime)
        {
            timeAlive = 0f;
            gameObject.SetActive(false);
        }
    }


}

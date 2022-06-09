using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float maxMaskPosX;
    public float minMaskPosX;

    private float maskLenghtX;
    private float unitLenghtPerDamagePoint;

    public RectTransform healthMaskRect;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private int currentHealth;

    private void Start()
    {
        maskLenghtX = maxMaskPosX - minMaskPosX;
        unitLenghtPerDamagePoint = maskLenghtX / 100f;
        DisplayHealth();
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        DisplayHealth();
    }

    void DisplayHealth()
    {
        float xLength = maxMaskPosX - ( (maxHealth - currentHealth) * unitLenghtPerDamagePoint );
        float yLenghth = healthMaskRect.anchoredPosition.y;
        healthMaskRect.anchoredPosition = new Vector3(xLength, yLenghth  );
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }
}

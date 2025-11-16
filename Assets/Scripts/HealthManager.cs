using System;
using UnityEngine;



public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth, maxHealth;

    public float invincbleLenght = 2f;
    private float invincConter;
    
    
    public Sprite[] healthBarImages;
    
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetHealth();
    }

    void Update()
    {
        if (invincConter > 0)
        {
            invincConter -= Time.deltaTime;
            
            for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if(Mathf.Floor(invincConter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);  
                }
                else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);  
                }

                if (invincConter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true); 
                }
               
            }
            
        }
    }

    public void Hurt()
    {
        UpdateUI();
        if (invincConter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.Respawn();

            }
            else
            {
                PlayerController.instance.KnockBack();
                invincConter = invincbleLenght;
            }
            
            
        }

        UpdateUI();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UIManager.instance.healthImage.enabled = true;
        UpdateUI();
    }

    public void AddHealth(int  amountToHeal)
    {
        currentHealth += amountToHeal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    
    public void UpdateUI()
    {
        UIManager.instance.healText.text = currentHealth.ToString();

        switch(currentHealth)
        {
            case 5: 
                UIManager.instance.healthImage.sprite = healthBarImages[4];  
                break;
            case 4:
                UIManager.instance.healthImage.sprite = healthBarImages[3];  
                break;
            case 3:
                UIManager.instance.healthImage.sprite = healthBarImages[2];  
                break;
            case 2:
                UIManager.instance.healthImage.sprite = healthBarImages[1];  
                break;
            case 1:
                UIManager.instance.healthImage.sprite = healthBarImages[0];  
                break;
            case 0:
                UIManager.instance.healthImage.enabled = false;
                break;
        }
    }

    public void PlayerKilled()
    {
        currentHealth = 0;
             UpdateUI();
    }
}

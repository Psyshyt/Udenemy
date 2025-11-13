using System;
using UnityEngine;



public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth, maxHealth;

    public float invincbleLenght = 2f;
    private float invincConter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
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
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}

using UnityEngine;

public class HealthPuckup : MonoBehaviour
{
    public int healAmount;

    public bool isFullHeal;
    
    public GameObject healthEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(healthEffect , transform.position, transform.rotation);
            Destroy(gameObject);
            if (isFullHeal)
            {
                HealthManager.instance.ResetHealth();
            }
            else
            {
                HealthManager.instance.AddHealth(healAmount);
            }
        }
    }
}

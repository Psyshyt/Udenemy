using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;
    
    public GameObject deathEffect;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        respawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        Debug.Log("Старт Корутина");
        StartCoroutine(RespawnCo());
        HealthManager.instance.PlayerKilled();
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        UIManager.instance.fadeToBlack = true;
        HealthManager.instance.ResetHealth();
        
        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f,1f,0f),  PlayerController.instance.transform.rotation);
        
        yield return new WaitForSeconds(2f);
        
        UIManager.instance.fadeFromBlack = true;
        PlayerController.instance.transform.position = respawnPosition;
        
        PlayerController.instance.gameObject.SetActive(true);
        
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn Point Set");
    }
}

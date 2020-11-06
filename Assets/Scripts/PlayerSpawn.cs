using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Vector3 playerSpawnPoint;
    public GameObject player;
    public PlayerHealth playerHealth;



    // Start is called before the first frame update
    void OnEnable()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerSpawnPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RespawnPlayer()
    {
        playerHealth.health = playerHealth.maxHealth;
        player.transform.position = playerSpawnPoint;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Vector3 playerSpawnPoint;
    public GameObject player;
    public float playerHealth;



    // Start is called before the first frame update
    void Start()
    {
        playerSpawnPoint = this.transform.position;
        playerHealth = player.GetComponent<PlayerHealth>().health;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>().health;
        if (playerHealth <= 0)
        {
            RespawnPlayer();
        }
    }
    public void RespawnPlayer()
    {
        player.transform.position = playerSpawnPoint;
    }


}

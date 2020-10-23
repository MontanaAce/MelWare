using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<PlayerHandler>() == null)
        {
            Object.Instantiate(player, this.transform);
            Object.Instantiate(mainCamera, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

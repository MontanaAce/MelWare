using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStation : MonoBehaviour
{
    PauseMenu pauseMenu;
    [TagSelector]
    public string playerTag;
    
    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            pauseMenu.playerInSaveRoom = true;
            Debug.Log("Player entered save room");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            pauseMenu.playerInSaveRoom = false;
            Debug.Log("Player Exited save room");
        }
    }
}

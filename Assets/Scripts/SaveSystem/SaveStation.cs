using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStation : MonoBehaviour
{
    PauseMenu pauseMenu;
    
    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pauseMenu.playerInSaveRoom = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pauseMenu.playerInSaveRoom = false;
    }
}

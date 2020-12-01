using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.SaveSystem;

public class PauseMenu : MonoBehaviour
{
    GameObject player;
    public GameObject mainPauseMenu;
    public GameObject saveMenu;
    public GameObject loadMenu;
    public bool playerInSaveRoom = false;
    public Button[] saveButtons;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        mainPauseMenu.SetActive(false);
        saveMenu.SetActive(false);
        loadMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < saveButtons.Length; i++)
        {
            saveButtons[i].enabled = playerInSaveRoom;
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(mainPauseMenu.activeInHierarchy || saveMenu.activeInHierarchy 
                || loadMenu.activeInHierarchy)
            {
                mainPauseMenu.SetActive(false);
                saveMenu.SetActive(false);
                loadMenu.SetActive(false);
            }
            else
            {
                mainPauseMenu.SetActive(true);
            }
        }
    }
    public void GoToMain()
    {
        mainPauseMenu.SetActive(true);
        saveMenu.SetActive(false);
        loadMenu.SetActive(false);
    }
    public void GoToSave()
    {
        mainPauseMenu.SetActive(false);
        saveMenu.SetActive(true);
        loadMenu.SetActive(false);
    }
    public void SaveGame(string fileName)
    {
        GameData gameData = new GameData(false, player);
        SaveSystem.Save(gameData, fileName);
    }
    public void GoToLoad()
    {
        mainPauseMenu.SetActive(false);
        saveMenu.SetActive(false);
        loadMenu.SetActive(true);
    }
    public void LoadGame(string fileName)
    {
        GameData gameData = SaveSystem.Load(fileName);
        player.transform.position.Set
           (gameData.savePositionX,
            gameData.savePositionY,
            transform.position.z);
        player.GetComponent<PlayerAllinOne>().health = gameData.health;
    }
}

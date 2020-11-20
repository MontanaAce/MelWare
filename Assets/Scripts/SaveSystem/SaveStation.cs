using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.SaveSystem;

public class SaveStation : MonoBehaviour
{
    public GameObject player;
    string fileName;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            GameData gameData = new GameData(false, player.GetComponent<PlayerHealth>().health);
            SaveSystem.Save(gameData, fileName);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            GameData gameData = SaveSystem.Load(fileName);
            player.GetComponent<PlayerHealth>().health = gameData.health;
        }
    }
}

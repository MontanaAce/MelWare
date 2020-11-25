using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.SaveSystem
{
    [System.Serializable] 
    public class GameData 
    {
        public bool hasGrenade;
        public int health;
        public float savePositionX;
        public float savePositionY;
        //Dictionary<string, bool> abilities;
        //Dictionary<string, bool> bosses;
        public GameData(bool inGrenade, GameObject newPlayer)
        {
            hasGrenade = inGrenade;
            health = newPlayer.GetComponent<PlayerHealth>().health;
            savePositionX = newPlayer.transform.position.x;
            savePositionY = newPlayer.transform.position.y;
        }
    }
}

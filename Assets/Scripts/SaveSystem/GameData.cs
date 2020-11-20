using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Scripts.SaveSystem
{
    [System.Serializable] 
    public class GameData 
    {
        public bool hasGrenade;
        public int health;

        public GameData(bool inGrenade, int inHealth)
        {
            hasGrenade = inGrenade;
            health = inHealth;
        }
    }
}

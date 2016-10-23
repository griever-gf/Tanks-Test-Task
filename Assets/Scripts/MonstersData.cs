using UnityEngine;
using System.Collections;

public class MonstersData : MonoBehaviour {

    public struct MonsterParameters
    {
        public int health;
        public int defense;
        public int damage;
        public int speed;
        
        public MonsterParameters(int hlth, int def, int dmg, int spd)
        {
            health = hlth;
            defense = def;
            damage = dmg;
            speed = spd;
        }
    }

    MonsterParameters[] monsterParams = new MonsterParameters[] { new MonsterParameters(200, 5, 500, 7),
                                                                  new MonsterParameters(500, 7, 400, 4),
                                                                  new MonsterParameters(700, 8, 300, 2),
                                                                };

    public MonsterParameters GetMonsterParameters(int idx)
    {
        return monsterParams[idx];
    }
}

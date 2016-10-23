using UnityEngine;
using System.Collections;

public class MonstersManager : MonoBehaviour {

    public MonstersData monstersData;
    public MonstersView monstersView;
    public int maxMonsterCount = 10;
    int currentMonsterCount;

    void Start()
    {
        currentMonsterCount = 0;
        MonsterController.OnMonsterDeath += DescreaseMonsterCounter;
    }

    void Update()
    {
        if ((currentMonsterCount < maxMonsterCount) && (!GameController._instance.isGameOver()))
        {
            currentMonsterCount++;
            monstersView.SpawnMonster();
        }
    }

    void DescreaseMonsterCounter()
    {
        if (currentMonsterCount >= 0)
            currentMonsterCount--;
    }


    public MonstersData.MonsterParameters GetMonsterParams(int idx)
    {
        return monstersData.GetMonsterParameters(idx);
    }

    public int GetMaxMonsterCount()
    {
        return maxMonsterCount;
    }

    public void DestroyMonsters()
    {
        monstersView.DestroyAllMonsters();
        currentMonsterCount = 0;
    }
}

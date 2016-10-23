using UnityEngine;
using System.Collections;

public class MonstersView : MonoBehaviour {

    public GameObject[] monsterPrefabs;
    GameObjectPool[] monsterPools;
    
    public GameObject gameField;
    Vector3 maxSpawnPoint, minSpawnPoint;
    public float monsterDiameter = 1.5f;
    public float monsterSpawnHeight = 0.5f;
    GameObject monsterTarget;
    public MonstersManager monstersManager;

    void Start ()
    {

        //filling moster pools
        monsterPools = new GameObjectPool[monsterPrefabs.Length];
        for (int i = 0; i < monsterPrefabs.Length; i++)
        {
            monsterPools[i] = gameObject.AddComponent<GameObjectPool>();
            monsterPools[i].Fill(monstersManager.GetMaxMonsterCount(), monsterPrefabs[i]);
        }

        //determining spawn borders
        Vector3 maxFieldPoint = Vector3.Scale(gameField.GetComponent<MeshFilter>().mesh.bounds.max, gameField.transform.localScale);
        Vector3 minFieldPoint = Vector3.Scale(gameField.GetComponent<MeshFilter>().mesh.bounds.min, gameField.transform.localScale);
        maxSpawnPoint = new Vector3(maxFieldPoint.x - monsterDiameter, monsterSpawnHeight, maxFieldPoint.z - monsterDiameter);
        minSpawnPoint = new Vector3(minFieldPoint.x + monsterDiameter, monsterSpawnHeight, minFieldPoint.z + monsterDiameter);
    }

    public void SetMonsterTarget(GameObject target)
    {
        monsterTarget = target;
    }

    public void SpawnMonster()
    {
        int monsterPoolIndex = UnityEngine.Random.Range(0, monsterPrefabs.Length);
        GameObject monster = monsterPools[monsterPoolIndex].GetPoolObject();
        if (monster == null) return;
        monster.GetComponent<MonsterController>().SetStartParams(monsterTarget, monstersManager.GetMonsterParams(monsterPoolIndex));

        Vector3 monsterPosition;
        bool isMonsterPositionVisible = false;
        do
        {
            monsterPosition = new Vector3(UnityEngine.Random.Range(minSpawnPoint.x, maxSpawnPoint.x), monsterSpawnHeight, UnityEngine.Random.Range(minSpawnPoint.z, maxSpawnPoint.z));
            Vector3 screenPos = Camera.main.WorldToViewportPoint(monsterPosition);
            isMonsterPositionVisible = ((screenPos.x > 0) && (screenPos.x < 1) && (screenPos.y > 0) && (screenPos.y < 1));
        }
        while (isMonsterPositionVisible);
        monster.transform.position = monsterPosition;
    }

    public void DestroyAllMonsters()
    {
        for (int i = 0; i < monsterPrefabs.Length; i++)
            for (int j = 0; j < monstersManager.GetMaxMonsterCount(); j++)
            {
                monsterPools[i].PoolObjectDirectAcccess(j).GetComponent<MonsterController>().DeathIfActive();
            }
    }
}

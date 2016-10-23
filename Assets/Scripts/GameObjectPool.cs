using UnityEngine;
using System.Collections;

public class GameObjectPool: MonoBehaviour {

    GameObject[] gameObjects;

    public void Fill(int capacity, GameObject prefab)
    {
        gameObjects = new GameObject[capacity];
        for (int i=0; i<capacity; i++)
        {
            gameObjects[i] = Instantiate(prefab);
            gameObjects[i].SetActive(false);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < gameObjects.Length; i++)
            if (!gameObjects[i].activeInHierarchy)
            {
                gameObjects[i].SetActive(true);
                return gameObjects[i];
            }
        return null;
    }

    public GameObject PoolObjectDirectAcccess(int idx)
    {
        return gameObjects[idx];
    }
}

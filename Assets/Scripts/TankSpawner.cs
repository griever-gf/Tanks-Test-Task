using UnityEngine;
using System.Collections;

public class TankSpawner : MonoBehaviour {

    public GameObject prefabTank;
    public Transform spawnPoint;
    GameObject tank;
    public TankManager tankManager;
    public MonstersView monsterView;

    public void SpawnTank()
    {
        tank = Instantiate(prefabTank, spawnPoint.position, spawnPoint.rotation) as GameObject;
        tank.GetComponent<TankMovementController>().SetTankParams(tankManager.GetTankMovementSpeed(), tankManager.GetTankRotationSpeed());
        tankManager.SetTankMovementAndWeaponControllers(tank.GetComponent<TankMovementController>(), tank.GetComponentInChildren<WeaponController>());
        monsterView.SetMonsterTarget(tank);
    }

    public void DestroyTank()
    {
        Destroy(tank);
    }
}

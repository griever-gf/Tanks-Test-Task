using UnityEngine;
using System.Collections;

public class TankManager : MonoBehaviour {

    public CameraController cameraController;
    public TankData tankData;
    public TankSpawner tankSpawner;
    TankMovementController tankMovementController;
    WeaponController weaponController;
    public MonstersManager monstersManager;

    public void ProcessKeyHold(KeyCode key_code)
    {
        switch (key_code)
        {
            case KeyCode.LeftArrow:
            case KeyCode.RightArrow:
            case KeyCode.UpArrow:
            case KeyCode.DownArrow:
                tankMovementController.ProcessKeyHold(key_code);
                cameraController.UpdateCameraPosition(tankMovementController.GetTankPosition());
                break;
        }
    }

    public void ProcessKeyUp(KeyCode key_code)
    {
        switch (key_code)
        {
            case KeyCode.LeftArrow:
            case KeyCode.RightArrow:
            case KeyCode.UpArrow:
            case KeyCode.DownArrow:
                tankMovementController.ProcessKeyUp(key_code);
                cameraController.UpdateCameraPosition(tankMovementController.GetTankPosition());
                break;
            case KeyCode.X:
                weaponController.StopShooting();
                break;
        }
    }

    public void ProcessKeyDown(KeyCode key_code)
    {
        switch (key_code)
        {
            case KeyCode.Q:
                tankData.SwitchCurrentWeapon(false);
                break;
            case KeyCode.W:
                tankData.SwitchCurrentWeapon(true);
                break;
            case KeyCode.X:
                weaponController.StartShooting();
                break;
        }
    }

    public float GetTankMovementSpeed()
    {
        return tankData.GetTankMovementSpeed();
    }

    public float GetTankRotationSpeed()
    {
        return tankData.GetTankRotationSpeed();
    }

    public void UpdateTankWeapon(int idx, bool play_sound, TankData.WeaponParameters weapon_params)
    {
        weaponController.UpdateCurrentWeapon(idx, play_sound, weapon_params);
    }

    void Awake()
    {
        SpawnTank();
    }

    public void SpawnTank()
    {
        tankSpawner.SpawnTank();
        tankData.ProcessTankStart();
    }

    public void SetTankMovementAndWeaponControllers(TankMovementController tmc, WeaponController twc)
    {
        tankMovementController = tmc;
        weaponController = twc;
    }

    public void DestroyTank()
    {
        tankSpawner.DestroyTank();
    }

    public void ProcessGameOver()
    {
        GameController._instance.ProcessGameOver();
    }
}

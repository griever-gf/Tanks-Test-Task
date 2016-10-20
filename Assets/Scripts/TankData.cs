using UnityEngine;
using System.Collections;

public class TankData : MonoBehaviour {

    public TankManager tankManager;

    public float tankMovementSpeed;
    public float tankRotationSpeed;

    public class TankParameters
    {
        public float tankMovementSpeed = 10;
        public float tankRotationSpeed = 200;
        public int health;
        public int defense;
    }

    TankParameters tankParameters;

    public struct WeaponParameters
    {
        int power;
        int speed;

        public WeaponParameters(int power, int speed)
        {
            this.power = power;
            this.speed = speed;
        }
    }

    WeaponParameters[] weapons = new WeaponParameters[] {new WeaponParameters(20,5), new WeaponParameters(10,10), new WeaponParameters(5,20) };
    int currentWeaponIndex;

    void Start()
    {
        tankParameters = new TankParameters();
        SetCurrentWeapon(0);
    }

    public float GetTankMovementSpeed()
    {
        return tankParameters.tankMovementSpeed;
    }

    public float GetTankRotationSpeed()
    {
        return tankParameters.tankRotationSpeed;
    }

    public void SetCurrentWeapon(int idx)
    {
        currentWeaponIndex = idx;
        tankManager.UpdateTankWeapon(currentWeaponIndex, false);
    }

    public void SwitchCurrentWeapon(bool is_forward)
    {
        if (is_forward)
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        else
        {
            currentWeaponIndex--;
            if (currentWeaponIndex == -1) currentWeaponIndex = weapons.Length - 1;
        }
        tankManager.UpdateTankWeapon(currentWeaponIndex, true);
    }
}

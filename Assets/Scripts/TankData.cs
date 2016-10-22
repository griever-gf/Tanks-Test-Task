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
        public int health = 300;
        public int defense = 4;
    }

    TankParameters tankParameters;

    public struct WeaponParameters
    {
        public int power;
        public int speed;

        public WeaponParameters(int power, int speed)
        {
            this.power = power;
            this.speed = speed;
        }
    }

    WeaponParameters[] weapons = new WeaponParameters[] {new WeaponParameters(600,5), new WeaponParameters(400,10), new WeaponParameters(200,30) };
    int currentWeaponIndex;

    void Start()
    {
        tankParameters = new TankParameters();
        SetCurrentWeapon(0);
        MonsterController.OnMonsterTouchTankAction += DescreaseTankHealth;
        GUIView._instance.UpdateTankHealth(tankParameters.health);
    }

    public float GetTankMovementSpeed()
    {
        return tankParameters.tankMovementSpeed;
    }

    public float GetTankRotationSpeed()
    {
        return tankParameters.tankRotationSpeed;
    }

    public void DescreaseTankHealth(int monster_damage)
    {
        tankParameters.health = MonsterController.CalculateDamage(tankParameters.health, monster_damage, tankParameters.defense);
        //Debug.Log("Tank Damaged: " + tankParameters.health + " health remains");
        GUIView._instance.UpdateTankHealth((tankParameters.health > 0) ? tankParameters.health : 0);
    }

    public void SetCurrentWeapon(int idx)
    {
        currentWeaponIndex = idx;
        tankManager.UpdateTankWeapon(currentWeaponIndex, false, weapons[currentWeaponIndex]);
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
        tankManager.UpdateTankWeapon(currentWeaponIndex, true, weapons[currentWeaponIndex]);
    }
}

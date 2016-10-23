using UnityEngine;
using System.Collections;

public class TankData : MonoBehaviour {

    public TankManager tankManager;

    public float tankMovementSpeed;
    public float tankRotationSpeed;

    public class TankParameters
    {
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

    public void ProcessTankStart()
    {
        tankParameters = new TankParameters();
        SetCurrentWeapon(0);
        MonsterController.OnMonsterTouchTankAction += DescreaseTankHealth;
        GUIView._instance.UpdateTankHealth(tankParameters.health);
    }

    public float GetTankMovementSpeed()
    {
        return tankMovementSpeed;
    }

    public float GetTankRotationSpeed()
    {
        return tankRotationSpeed;
    }

    public void DescreaseTankHealth(int monster_damage)
    {
        tankParameters.health = MonsterController.CalculateDamage(tankParameters.health, monster_damage, tankParameters.defense);
        //Debug.Log("Tank Damaged: " + tankParameters.health + " health remains");

        if (tankParameters.health > 0)
        {
            GUIView._instance.UpdateTankHealth(tankParameters.health);
        }
        else
        {
            GUIView._instance.UpdateTankHealth(0);
            tankManager.ProcessGameOver();
        }
        
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

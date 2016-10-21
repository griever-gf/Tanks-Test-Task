using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public WeaponView weaponView;
    TankData.WeaponParameters weaponParams;

    public void UpdateCurrentWeapon(int idx, bool play_sound, TankData.WeaponParameters weapon_params)
    {
        this.weaponParams = weapon_params;
        weaponView.UpdateWeapon(idx, play_sound);
    }

    public void StartShooting()
    {
        InvokeRepeating("Fire", 0, 1f/weaponParams.speed);
    }

    public void StopShooting()
    {
        CancelInvoke();
        weaponView.StopFire();
    }

    void Fire()
    {
        weaponView.FireBullet(weaponParams.power);
    }
}

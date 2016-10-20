using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public WeaponView weaponView;

    public void UpdateCurrentWeapon(int idx, bool play_sound)
    {
        weaponView.UpdateWeapon(idx, play_sound);
    }

    public void StartShooting()
    {
        InvokeRepeating("Fire", 0, 0.05f);
    }

    public void StopShooting()
    {
        CancelInvoke();
        weaponView.StopFire();
    }

    void Fire()
    {
        weaponView.FireBullet();
    }
}

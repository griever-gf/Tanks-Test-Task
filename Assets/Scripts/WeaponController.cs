using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public WeaponView weaponView;

    public void UpdateCurrentWeapon(int idx, bool play_sound)
    {
        weaponView.UpdateWeapon(idx, play_sound);
    }
}

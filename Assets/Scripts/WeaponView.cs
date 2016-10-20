using UnityEngine;
using System.Collections;

public class WeaponView : MonoBehaviour {

    public GameObject[] weaponPrefabs;
    GameObject[] weapons;
    public Transform pointHidden;
    public AudioClip weaponSwitchSound;
    public AudioSource aSource;

    int currentWeaponIndex;

	void Start () {
        weapons = new GameObject[weaponPrefabs.Length];
        for (int i = 0; i < weaponPrefabs.Length; i++)
            weapons[i] = Instantiate(weaponPrefabs[i], pointHidden.position, Quaternion.identity) as GameObject;
	}


    public void UpdateWeapon(int new_weapon_idx, bool play_sound)
    {
        if ((new_weapon_idx >=0)&&(new_weapon_idx<weaponPrefabs.Length))
        {
            weapons[currentWeaponIndex].transform.parent = null;
            weapons[currentWeaponIndex].transform.position = pointHidden.position;
            currentWeaponIndex = new_weapon_idx;
            weapons[currentWeaponIndex].transform.SetParent(gameObject.transform);
            weapons[currentWeaponIndex].transform.localPosition = weaponPrefabs[currentWeaponIndex].transform.localPosition;
            weapons[currentWeaponIndex].transform.localRotation = weaponPrefabs[currentWeaponIndex].transform.localRotation;
            if (play_sound)
            {
                aSource.Stop();
                aSource.clip = weaponSwitchSound;
                aSource.loop = false;
                aSource.Play();
            }
        }
    }
}

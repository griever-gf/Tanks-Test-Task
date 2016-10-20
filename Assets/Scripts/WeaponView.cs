using UnityEngine;
using System.Collections;

public class WeaponView : MonoBehaviour {

    public GameObject[] weaponPrefabs;
    GameObject[] weapons;
    public AudioClip weaponSwitchSound;
    public AudioSource aSource;

    int currentWeaponIndex;

	void Start () {
        weapons = new GameObject[weaponPrefabs.Length];
        for (int i = 0; i < weaponPrefabs.Length; i++)
        {
            weapons[i] = Instantiate(weaponPrefabs[i]);
            weapons[i].SetActive(false);
            weapons[i].transform.SetParent(gameObject.transform);
            weapons[i].transform.localPosition = weaponPrefabs[i].transform.localPosition;
            weapons[i].transform.localRotation = weaponPrefabs[i].transform.localRotation;
        }
	}


    public void UpdateWeapon(int new_weapon_idx, bool play_sound)
    {
        if ((new_weapon_idx >=0)&&(new_weapon_idx<weaponPrefabs.Length))
        {
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = new_weapon_idx;
            weapons[currentWeaponIndex].SetActive(true);
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

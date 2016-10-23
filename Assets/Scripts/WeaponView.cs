using UnityEngine;
using System.Collections;

public class WeaponView : MonoBehaviour {

    public GameObject[] weaponPrefabs;
    GameObject[] weapons;
    public AudioClip weaponSwitchSound;
    public AudioClip[] bulletSounds;
    public AudioSource aSource;

    int currentWeaponIndex;

    public GameObject[] bulletPrefabs;
    GameObjectPool[] bulletPools;
    public int maxBulletCount = 100;
    Transform currentBulletPosition;

    int bulletMoveSpeed = 20;

    void Awake () {
        weapons = new GameObject[weaponPrefabs.Length];
        bulletPools = new GameObjectPool[weaponPrefabs.Length];
        for (int i = 0; i < weaponPrefabs.Length; i++)
        {
            weapons[i] = Instantiate(weaponPrefabs[i]);
            weapons[i].SetActive(false);
            weapons[i].transform.SetParent(gameObject.transform);
            weapons[i].transform.localPosition = weaponPrefabs[i].transform.localPosition;
            weapons[i].transform.localRotation = weaponPrefabs[i].transform.localRotation;
            bulletPools[i] = gameObject.AddComponent<GameObjectPool>();
            bulletPools[i].Fill(maxBulletCount, bulletPrefabs[i]);
        }
	}


    public void UpdateWeapon(int new_weapon_idx, bool play_sound)
    {
        if ((new_weapon_idx >=0)&&(new_weapon_idx<weaponPrefabs.Length))
        {
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = new_weapon_idx;
            weapons[currentWeaponIndex].SetActive(true);
            currentBulletPosition = weapons[currentWeaponIndex].transform.FindChild("point_bullet_spawn").transform;
            if (play_sound)
            {
                aSource.Stop();
                aSource.clip = weaponSwitchSound;
                aSource.loop = false;
                aSource.Play();
            }
        }
    }

    public void FireBullet(int damage)
    {
        GameObject bullet = bulletPools[currentWeaponIndex].GetPoolObject();
        if (bullet == null) return;
        bullet.GetComponent<BulletController>().SetBulletDamage(damage);
        bullet.transform.position = currentBulletPosition.position;
        bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletMoveSpeed);

        if ((!aSource.isPlaying)||(aSource.clip != bulletSounds[currentWeaponIndex]))
        {
            aSource.clip = bulletSounds[currentWeaponIndex];
            aSource.loop = true;
            aSource.Play();
        }
    }

    public void StopFire()
    {
        aSource.Stop();
    }
}

using UnityEngine;
using System.Collections;

public class MonsterSound : MonoBehaviour
{
    public static MonsterSound _instance { get; private set; } //singleton

    public void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    public AudioClip monsterDeathByBullet;
    public AudioClip monsterDeathByTank;

    public AudioSource aSource;

    public void PlayDeathByBullet()
    {
        aSource.Stop();
        aSource.clip = monsterDeathByBullet;
        aSource.Play();
    }

    public void PlayDeathByTank()
    {
        aSource.Stop();
        aSource.clip = monsterDeathByTank;
        aSource.Play();
    }
}

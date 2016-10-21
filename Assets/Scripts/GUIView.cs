using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIView : MonoBehaviour {

    public static GUIView _instance { get; private set; } //singleton

    public void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    public Text lTankHealth;
    public Text lMonsterHealth;
    public Text lDeathCount;

    public void UpdateTankHealth(int value)
    {
        lTankHealth.text = "Tank Health " + value.ToString();
    }

    public void UpdateMonsterHealth(int value)
    {
        lMonsterHealth.text = "Monster Health " + value.ToString();
    }
}

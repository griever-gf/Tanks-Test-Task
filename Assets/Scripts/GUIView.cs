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
    public GameObject pPopupRestart;
    GameObject popupRestart;
    public Canvas canvas;

    public void UpdateTankHealth(int value)
    {
        lTankHealth.text = "Tank Health " + value.ToString();
    }

    public void UpdateMonsterHealth(int value)
    {
        lMonsterHealth.text = "Monster Health " + value.ToString();
    }

    public void UpdateDeathCounter(int value)
    {
        lDeathCount.text = "Death Count " + value.ToString();
    }

    public void SpawnRestartPopup()
    {
        Debug.Log("Spawn restart popup");
        popupRestart = Instantiate(pPopupRestart);
        popupRestart.transform.SetParent(canvas.transform, false);
        popupRestart.GetComponentInChildren<Button>().onClick.AddListener(RestartButtonPressed);
    }

    void RestartButtonPressed()
    {
        Destroy(popupRestart);
        GameController._instance.RestartGame();
    }
}

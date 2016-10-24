using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController _instance { get; private set; } //singleton

    public void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    public enum GameCycleState { gameplay, gameOver };
    GameCycleState state;
    int deathCounter = 0;

    public TankManager tankManager;
    public MonstersManager monstersManager;
    public CameraController cameraController;

    void Start()
    {
        GUIView._instance.UpdateDeathCounter(deathCounter);
    }

    public bool isGameOver()
    {
        return (state == GameCycleState.gameOver);
    }

    public void SetGameCycleState(GameCycleState new_state)
    {
        state = new_state;
    }

    public void IncreaseDeathCounter()
    {
        deathCounter++;
        GUIView._instance.UpdateDeathCounter(deathCounter);
    }

    public void ProcessGameOver()
    {
        SetGameCycleState(GameController.GameCycleState.gameOver);
        tankManager.DestroyTank();
        monstersManager.DestroyMonsters();
        GUIView._instance.SpawnRestartPopup();
    }

    public void RestartGame()
    {
        SetGameCycleState(GameController.GameCycleState.gameplay);
        tankManager.SpawnTank();
        cameraController.ResetCameraPosition();
        deathCounter = 0;
        GUIView._instance.UpdateDeathCounter(deathCounter);
    }
}

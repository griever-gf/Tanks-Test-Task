using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {


    public static GameState _instance { get; private set; } //singleton

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
}

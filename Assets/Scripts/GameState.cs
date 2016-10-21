using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public enum GameCycleState { gameplay, gameOver };
    GameCycleState state;
    int deathCounter = 0;

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
    }
}

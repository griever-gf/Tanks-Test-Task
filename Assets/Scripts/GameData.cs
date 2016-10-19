using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    public float tankMovementSpeed;
    public float tankRotationSpeed;

    public class TankParameters
    {
        public float tankMovementSpeed = 10;
        public float tankRotationSpeed = 200;
        public int health;
        public int defense;
    }

    TankParameters tankParameters;

    void Start()
    {
        tankParameters = new TankParameters();
    }

    public float GetTankMovementSpeed()
    {
        return tankParameters.tankMovementSpeed;
    }

    public float GetTankRotationSpeed()
    {
        return tankParameters.tankRotationSpeed;
    }
}

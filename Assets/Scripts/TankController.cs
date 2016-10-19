using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour
{
    public float rotationSpeed = 100;
    public float movementSpeed = 10;

    public TankManager tankManager;
    public TankView tankView;

    void Start()
    {
    }

    void Update()
    {
    }

    public void ProcessKeyHold(KeyCode key_code)
    {
        switch (key_code)
        {
            case KeyCode.LeftArrow:
                tankView.TankRotate(false);
                tankView.PlayMotorSound();
                break;
            case KeyCode.RightArrow:
                tankView.TankRotate(true);
                tankView.PlayMotorSound();
                break;
            case KeyCode.UpArrow:
                tankView.TankMove(true);
                tankView.PlayMotorSound();
                break;
            case KeyCode.DownArrow:
                tankView.TankMove(false);
                tankView.PlayMotorSound();
                break;
        }
    }

    public void ProcessKeyUp(KeyCode key_code)
    {
        switch (key_code)
        {
            case KeyCode.LeftArrow:
            case KeyCode.RightArrow:
            case KeyCode.UpArrow:
            case KeyCode.DownArrow:
                tankView.StopMotorSound();
                break;
        }
    }

    public float GetTankMovementSpeed()
    {
        return tankManager.GetTankMovementSpeed();
    }

    public float GetTankRotationSpeed()
    {
        return tankManager.GetTankRotationSpeed();
    }

    public Vector3 GetTankPosition()
    {
        return transform.position;
    }
}

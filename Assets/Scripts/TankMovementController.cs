using UnityEngine;
using System.Collections;

public class TankMovementController : MonoBehaviour
{
    float rotationSpeed;
    float movementSpeed;
    public TankView tankView;

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

    public void SetTankParams(float mov_spd, float rot_spd)
    {
        movementSpeed = mov_spd;
        rotationSpeed = rot_spd;
    }

    public float GetTankMovementSpeed()
    {
        return movementSpeed;
    }

    public float GetTankRotationSpeed()
    {
        return rotationSpeed;
    }

    public Vector3 GetTankPosition()
    {
        return transform.position;
    }
}

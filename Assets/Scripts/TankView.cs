using UnityEngine;
using System.Collections;

public class TankView : MonoBehaviour {

    public TankMovementController tankMovementController;
    public AudioClip motorSound;
    public AudioSource audioSource;

    void Start () {
	
	}
	
	void Update () {
	
	}

    public void TankMove(bool is_forward)
    {
        transform.Translate((is_forward ? Vector3.forward : Vector3.back) * tankMovementController.GetTankMovementSpeed() * Time.deltaTime, Space.Self);
    }

    public void TankRotate(bool is_clockwise)
    {
        transform.Rotate((is_clockwise? Vector3.up : Vector3.down) * (tankMovementController.GetTankRotationSpeed() * Time.deltaTime), Space.Self);
    }

    public void StopMotorSound()
    {
        audioSource.Stop();
    }

    public void PlayMotorSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = motorSound;
            audioSource.Play();
        }
    }
}

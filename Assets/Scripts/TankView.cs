using UnityEngine;
using System.Collections;

public class TankView : MonoBehaviour {

    public TankController tankController;
    public AudioClip motorSound;
    public AudioSource audioSource;

    void Start () {
	
	}
	
	void Update () {
	
	}

    public void TankMove(bool is_forward)
    {
        transform.Translate((is_forward ? Vector3.forward : Vector3.back) * tankController.GetTankMovementSpeed() * Time.deltaTime, Space.Self);
    }

    public void TankRotate(bool is_clockwise)
    {
        transform.Rotate((is_clockwise? Vector3.up : Vector3.down) * (tankController.GetTankRotationSpeed() * Time.deltaTime), Space.Self);
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

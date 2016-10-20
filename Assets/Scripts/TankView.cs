using UnityEngine;
using System.Collections;

public class TankView : MonoBehaviour {

    public TankMovementController tankMovementController;
    public AudioClip motorSound;
    public AudioSource audioSource;
    Rigidbody rBody;

    void Start () {
        rBody = GetComponent<Rigidbody>();
	}
	
	void Update () {
	
	}

    public void TankMove(bool is_forward)
    {
        transform.Translate((is_forward ? Vector3.forward : Vector3.back) * tankMovementController.GetTankMovementSpeed() * Time.deltaTime, Space.Self);
        //rBody.MovePosition(transform.position + (is_forward ? transform.forward : -transform.forward) * tankMovementController.GetTankMovementSpeed() * Time.deltaTime);
    }

    public void TankRotate(bool is_clockwise)
    {
        transform.Rotate((is_clockwise? Vector3.up : Vector3.down) * (tankMovementController.GetTankRotationSpeed() * Time.deltaTime), Space.Self);
        //Quaternion deltaRotation = Quaternion.Euler((is_clockwise ? Vector3.up : Vector3.down) * (tankMovementController.GetTankRotationSpeed() * Time.deltaTime));
        //rBody.MoveRotation(rigidbody.rotation * deltaRotation);
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

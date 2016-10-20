using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    float lifeTime = 1f;


	void Start () {
        Invoke("DestroyBullet", lifeTime);
	}
	
	void DestroyBullet()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    void OnCollisionEnter()
    {
        CancelInvoke();
        DestroyBullet();
    }
}

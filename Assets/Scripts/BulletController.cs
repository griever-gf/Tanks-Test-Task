using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    float lifeTime = 1f;
    int bulletDamage;


	void Start () {
        Invoke("DestroyBullet", lifeTime);
	}

    public void SetBulletDamage(int dmg)
    {
        bulletDamage = dmg;
    }
	
	void DestroyBullet()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        CancelInvoke();
        DestroyBullet();
        if (col.gameObject.layer == LayerMask.NameToLayer("monsters"))
            col.gameObject.GetComponent<MonsterController>().ApplyDamage(bulletDamage);
    }
}

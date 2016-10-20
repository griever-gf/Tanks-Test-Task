using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    public Transform target;
    float rotationSpeed = 1;
    float movementSpeed = 8;

    public void SetTaregt (GameObject target)
    {
        this.target = target.transform;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPos), Time.deltaTime * rotationSpeed);
    }


    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("tank"))
            Destroy(gameObject);
    }
}

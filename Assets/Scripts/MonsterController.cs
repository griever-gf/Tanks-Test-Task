using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    Transform target;
    float rotationSpeed = 1;
    int movementSpeed;
    int health;
    int defense;
    int damage;

    public delegate void MonsterDeathAction();
    public static event MonsterDeathAction OnMonsterDeath;

    public delegate void MonsterTouchTankAction(int dmg);
    public static event MonsterTouchTankAction OnMonsterTouchTankAction;

    bool isTankTouched = false;

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

    public static int CalculateDamage(int curr_health, int attacker_damage, int defense)
    {
        return (curr_health - (int)(Random.Range(0f, 1f) * attacker_damage / defense));
    }

    public void SetStartParams(GameObject target, MonstersData.MonsterParameters m_params)
    {
        this.target = target.transform;
        movementSpeed = m_params.speed;
        health = m_params.health;
        defense = m_params.defense;
        damage = m_params.damage;
    }

    void OnCollisionEnter(Collision col)
    {
        if ((!isTankTouched)&&(col.gameObject.layer == LayerMask.NameToLayer("tank")))
        {
            isTankTouched = true;
            MonsterSound._instance.PlayDeathByTank();
            OnMonsterTouchTankAction(damage);
            Death();
        }
    }

    void Death()
    {
        //Debug.Log("Monster Death");
        OnMonsterDeath();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
        GameController._instance.IncreaseDeathCounter();
    }

    public void ApplyDamage(int attacker_damage)
    {
        if (health > 0)
        {
            health = CalculateDamage(health, attacker_damage, defense);
            //Debug.Log("Applying Damage To Monster,  " + health + " remains");
            GUIView._instance.UpdateMonsterHealth((health > 0) ? health : 0);
            if (health <= 0)
            {
                MonsterSound._instance.PlayDeathByBullet();
                Death();
            }
        }
    }

    public void DeathIfActive()
    {
        if (gameObject.activeInHierarchy)
            Death();
    }
}

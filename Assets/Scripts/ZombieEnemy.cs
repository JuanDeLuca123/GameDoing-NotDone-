using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    public Rigidbody2D zombieRB;

    [SerializeField] private float CooldownDamage;
    private float CooldownNextDamage;

    public float AttackRange;
    Vector2 enemyPos;
    public GameObject PlayerMov;
    bool followPlayer;
    public int Vel;

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyPos, Vel * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, enemyPos) > 12F)
        {
            followPlayer = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Character") 
        { 
            enemyPos = PlayerMov.transform.position;
            followPlayer = true;
            if (Mathf.Abs(transform.position.x - enemyPos.x) < AttackRange)
            {
                CooldownNextDamage -= Time.deltaTime;
                if (CooldownNextDamage <= 0)
                {
                    collision.GetComponent<CharacterHealth>().Damaged(10);
                    CooldownNextDamage = CooldownDamage;
                    Debug.Log("El zombie ataco al jugador");
                }
            }    
        }
    }
    public void Death()
    {
        Destroy(gameObject);
        Debug.Log("Mataste al zombie");
    }
}

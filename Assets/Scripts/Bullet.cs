using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    public ZombieEnemy zombieEnemy;
    public LeechEnemy leechEnemy;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limit")
        {
            Destroy(this.gameObject);
            Debug.Log("Bala choco con limite y fue destruida");
        }
       
        if (collision.gameObject.tag == "Zombie")
        {
            //Supuestamente esto tendria que mandarte a la funcion de ZombieEnemy para que mate al enemigo pero no se porque no lo hace si se te ocurre una solucion agradeceria
            //que la pongas en los comentarios :3

            zombieEnemy.Death();
            Destroy(this.gameObject);
            Debug.Log("Bala impacto al zombie");
            
        }
        if (collision.gameObject.tag == "Leech")
        {
            leechEnemy.Death();
            Destroy(this.gameObject);
            Debug.Log("Bala impacto a la sanguijuela");
        }

    }

}

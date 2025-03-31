using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechEnemy : MonoBehaviour
{
    public GameObject[] pointsTrack;
    public int random;
    public float speed;
    public float time;
    [SerializeField] private float CooldownDamage;
    private float CooldownNextDamage;

    // Start is called before the first frame update
    void Start()
    {
        pointsTrack = GameObject.FindGameObjectsWithTag("Point");
        random = Random.Range(0,pointsTrack.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsTrack[random].transform.position, speed * Time.deltaTime);
        time += Time.deltaTime;
        
        if(time >= 1)
        {
            random = Random.Range(0, pointsTrack.Length);
            time = 0;
        }
    }
    public void Death()
    {

        Destroy(this.gameObject);
        Debug.Log("Se destruyo al enemigo");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            CooldownNextDamage -= Time.deltaTime;
            if (CooldownNextDamage <= 0)
            {
                collision.GetComponent<CharacterHealth>().Damaged(10);
                CooldownNextDamage = CooldownDamage;
                Debug.Log("La sanguijuela ataco al jugador");
            }
        }
        if (collision.tag == "Bullet")
        {
            Destroy(gameObject);
            Debug.Log("Mataste a la sanguijuela");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Character")
        {
            Destroy(this.gameObject);
            Debug.Log("Moneda destruida");
        }
    }
}

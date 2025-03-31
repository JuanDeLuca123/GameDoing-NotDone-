using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float CharacterMovSpeed = 5f;
    private float MovX, MovY;
    private Vector2 MovDirec;
    public Rigidbody2D CharacterRB;

    public Camera sceneCamera;
    public Weapon weapon;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        CharacterRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovX = Input.GetAxisRaw("Horizontal");
        MovY = Input.GetAxisRaw("Vertical");
        MovDirec = new Vector2 (MovX, MovY);

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
            Debug.Log("Disparo");
        }

        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        CharacterRB.MovePosition(CharacterRB.position + MovDirec * CharacterMovSpeed * Time.fixedDeltaTime);
        Move();
    }

    void Move()
    {
        Vector2 aimDirection = mousePosition - CharacterRB.position;

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        CharacterRB.rotation = aimAngle;
    }
}

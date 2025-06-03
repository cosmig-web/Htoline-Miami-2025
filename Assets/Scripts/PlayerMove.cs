using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.7f;
    public float dashForce = 10f;
    public Transform camera;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
        
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2) transform.position).normalized;
        transform.up = direction;
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        Move();
    }

    public void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        transform.position = new  Vector3(transform.position.x + x * Time.deltaTime * speed, transform.position.y + y * Time.deltaTime * speed, transform.position.z);
        
    }

   
}

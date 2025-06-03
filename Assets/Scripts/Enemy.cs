using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Vector2> Points;
    public int currentPathIndex = 1;
    private bool repeate = true;
    public bool loop = true;
    public float radius;
    public Transform player;
    public int speed = 5;
    public Vector2 size;

    private Vector2 target;
    private int indexer = 0;
    private Rigidbody2D rb;

    void Start()
    {
        target = Points[currentPathIndex];
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        var isPlayerInRange = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));
        if (isPlayerInRange)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            rb.SetRotation(Quaternion.LookRotation(transform.forward, player.position));

        }

        if (!isPlayerInRange)
        {
            if (Vector3.Distance(transform.position, target) < 0.3f)
            {
                if (!repeate)
                {
                    currentPathIndex++;
                    indexer++;
                }

                if (repeate)
                {
                    currentPathIndex--;
                    indexer++;
                }
                target = Points[currentPathIndex];
                if (1+(indexer) >= Points.Count)
                {
                    
                    indexer = 0;
                    if (loop)
                    {
                        repeate = true;
                    }
                    
                }

                if (currentPathIndex == 0)
                {
                    repeate = false;
                }
            }
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < Points.Count - 1; i++)
        {
            Gizmos.DrawLine(Points[i], Points[i + 1]);
        }
    } 
}

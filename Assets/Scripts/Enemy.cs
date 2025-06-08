using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public List<Vector2> waypoints;
    public int currentWaypoint;
    public float dis;
    public bool loop = true;
    
    private float distance;
    private Vector3 target;
    private bool repeate = false;
    private int indexer = 0;

    void Start()
    {
      target = waypoints[currentWaypoint];
    }

    void Update()
    {
        bool PlayerInRange = Vector2.Distance(player.transform.position, transform.position) <= dis;


        if (PlayerInRange)
        {
            distance = Vector2.Distance(player.transform.position, transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward *  angle);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            distance = Vector2.Distance(target, transform.position);
            Vector2 direction = target - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward *  angle);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) < 0.3f)
            {
                if (!repeate)
                {
                    currentWaypoint++;
                    indexer++;
                }

                if (repeate)
                {
                    currentWaypoint--;
                    indexer++;
                }
                target = waypoints[currentWaypoint];
                if (1+(indexer) >= waypoints.Count)
                {
                    
                    indexer = 0;
                    if (loop)
                    {
                        repeate = true;
                    }
                    
                }

                if (currentWaypoint == 0)
                {
                    repeate = false;
                }
            }
            
        }

    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
        }
    } 
}

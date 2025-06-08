using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Bullet : MonoBehaviour
{

    public float destroy = 2;
    public float speed = 5;


    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        destroy -=  Time.deltaTime;
        if (destroy <= 0)
        {
            Destroy(gameObject);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject);
        print("Hit");
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Animations : MonoBehaviour
{
    public Transform muzzle;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    bool HasGun = false;
    public Transform Bullet;
    public float fireRate = 0.5f;
    

    private float TrueFireRate;
    private AudioSource audio;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TrueFireRate = fireRate;
        audio = GetComponent<AudioSource>();
    }


    

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && HasGun && fireRate <= 0)
        {
            spriteRenderer.sprite = sprites[1];
            Instantiate(Bullet, muzzle.position, muzzle.rotation);
            fireRate = TrueFireRate;
            audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();
        }else if (HasGun)
        {
            spriteRenderer.sprite = sprites[0];
        }
        fireRate -= Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mk"))
        {
            HasGun =  true;
            spriteRenderer.sprite = sprites[0];
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bullet") )
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    
}

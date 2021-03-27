using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilAmmo : MonoBehaviour
{
    //protected float levelWidth = 4.8f;
    //protected float levelHeight = 3.6f;
    //protected float posOffset = 0.2f;

    [SerializeField] private int damage;

    [SerializeField] private float velocity;
    [SerializeField] private float lifeTime;

    void Start()
    {
        velocity = -velocity;
        //Instantiate(ammoEffect, gameObject.transform.position, Quaternion.identity);
        Invoke("DestroyAmmo", lifeTime);
    }
    void Update()
    {
        //SpaceLoop();

        transform.Translate(Vector2.up * (-velocity) * Time.deltaTime);
    }
    private void DestroyAmmo()
    {
        //Instantiate(ammoEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerPlatformerController>().Attacked(damage);
            DestroyAmmo();
        }
        //if (collision.tag == "Respawn")
        //{
        //    //collision.GetComponent<Enemy>().Attacked(2);
        //    DestroyAmmo();
        //}
        //DestroyAmmo();

    }

    //void SpaceLoop()
    //{
    //    if (transform.position.x < -levelWidth / 2 - posOffset)
    //    {
    //        transform.position = new Vector2(-transform.position.x - posOffset, transform.position.y);
    //    }
    //    if (transform.position.x > levelWidth / 2 + posOffset)
    //    {
    //        transform.position = new Vector2(-transform.position.x + posOffset, transform.position.y);
    //    }
    //    if (transform.position.y < -levelHeight / 2 - posOffset)
    //    {
    //        transform.position = new Vector2(transform.position.x, -transform.position.y - posOffset);
    //    }
    //    if (transform.position.y > levelHeight / 2 + posOffset)
    //    {
    //        transform.position = new Vector2(transform.position.x, -transform.position.y + posOffset);
    //    }
    //}
}

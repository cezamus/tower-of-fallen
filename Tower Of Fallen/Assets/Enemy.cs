using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Enemy : PhysicsObject
public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject destroyParticles;

    protected float levelWidth = 4.8f;
    protected float levelHeight = 3.6f;
    protected float posOffset = 0.2f;

    protected SpriteRenderer spriteRenderer;
    private Animator animator;

    public Transform player;

    protected void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Attacked(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyEnemy(gameObject);
        }
    }

    public void DestroyEnemy(GameObject gameObject)
    {
        Destroy(gameObject);
        ScoreText.UpdateScore();
        Instantiate(destroyParticles, gameObject.transform.position, Quaternion.identity);

        // Spawn pickup - random

    }

    protected void SpaceLoop()
    {
        if (transform.position.x < -levelWidth / 2 - posOffset)
        {
            transform.position = new Vector2(-transform.position.x - posOffset, transform.position.y);
        }
        if (transform.position.x > levelWidth / 2 + posOffset)
        {
            transform.position = new Vector2(-transform.position.x + posOffset, transform.position.y);
        }
        if (transform.position.y < -levelHeight / 2 - posOffset)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y - posOffset);
        }
        if (transform.position.y > levelHeight / 2 + posOffset)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y + posOffset);
        }
    }
    // ShouldSpawnPickup
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboGubma : Enemy
{
    private float speed = 1f;
    private int damage = 1;
    private float attackRange = 1f;
    private float shotTime = 0f;
    private float turnTime = 1f;
    private float shootDelay = 2f;
    private float turnDelay = 2f;
    private float speedModifier;
    private Vector2[] directions = { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
    private Vector2 direction;

    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject spiderWeb;

    private Animator animator;

    
    void Update()
    {
        SpaceLoop();
        shotTime += Time.deltaTime;
        turnTime += Time.deltaTime;

        if (shotTime > shootDelay)
        {
            shotTime = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                Vector2 shotDirection = directions[i];
                float angle = Mathf.Atan2(shotDirection.y, shotDirection.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                startPoint.rotation = rotation;
                Instantiate(spiderWeb, startPoint.position, startPoint.rotation);
            }
        }

        if (turnTime > turnDelay)
        {
            turnTime = 0;
            direction = directions[Random.Range(0, directions.Length)];
            speedModifier = Random.Range(0.6f, 1.2f);

        }
        
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime * 0.5f);

        

    }
}

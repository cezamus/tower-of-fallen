using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gumba : Enemy
{

    private float speed = 1f;
    private int damage = 1;
    private float attackRange = 1f;
    private float time = 0f;
    private float shootDelay = 2f;

    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject missile;

    private Animator animator;

    //private bool calm = false;
    //private bool side = false;

    // Start is called before the first frame update
    //void Awake()
    //{
    //   base.Awake();
    //   animator = GetComponent<Animator>();

    //}
    //void Start()
    //{
    //    gameObject.GetComponent<Animation>().Play();
    //}
    //Update is called once per frame
    void Update()
    {
        SpaceLoop();    //funkcja odpowiedzialna za przenoszenie obiektów na drugą stronę po wyjściu za krawędź ekranu
        time += Time.deltaTime;

        if (player != null)
        {
            GumbaBehavior();
        }
    }

    private void GumbaBehavior()    //zachowanie Gumby
    {
        if (Vector2.Distance(transform.position, player.position) > attackRange)    //sprawdzanie odległości od gracza
        {   
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);  //śledzenie gracza
        }
        else
        {
            if (time > shootDelay)  //odstęp czasowy między strzałami
            {
                time = 0;
                Vector2 direction = player.position - startPoint.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                startPoint.rotation = rotation;
                Instantiate(missile, startPoint.position, startPoint.rotation);
            }
        }
    }

    //protected override void ComputeVelocity()
    //{
    //    //LoopChecking();

    //    Vector2 move = Vector2.zero;

    //    move.x = Input.GetAxis("Horizontal");

    //    if (Input.GetButtonDown("Jump") && grounded)
    //    {
    //        velocity.y = jumpTakeOffSpeed;
    //    }
    //    else if (Input.GetButtonUp("Jump"))
    //    {
    //        if (velocity.y > 0)
    //        {
    //            velocity.y = velocity.y * 0.5f;
    //        }
    //    }

    //    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

    //    //bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.1f) : (move.x < -0.1f));
    //    bool flipSprite = (spriteRenderer.flipX ? (direction.x > 0.1f) : (direction.x < -0.1f));

    //    if (flipSprite)
    //    {
    //        spriteRenderer.flipX = !spriteRenderer.flipX;
    //    }

    //    animator.SetBool("grounded", grounded);
    //    animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    //    targetVelocity = move * maxSpeed;
    //}

    //void CalmMove()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    //}

    //void RageMove()
    //{
    //    if (player)
    //    {
    //        if (Vector2.Distance(transform.position, player.position) > range)
    //        {
    //            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    //        }
    //    }
    //}

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

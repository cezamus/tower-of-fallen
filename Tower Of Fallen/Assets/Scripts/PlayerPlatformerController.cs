using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPlatformerController : PhysicsObject
{
    public int health = 4;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    protected SpriteRenderer spriteRenderer;

    private Animator animator;

    [SerializeField] private Image[] status;
    [SerializeField] private Sprite red;
    [SerializeField] private Sprite grey;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        checkMovement();

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.1f) : (move.x < -0.1f));
        bool flipSprite = (spriteRenderer.flipX ? (direction.x > 0.1f) : (direction.x < -0.1f));

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        targetVelocity = move * maxSpeed;
    }

    private void checkMovement()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetBool("playerIsMoving", true);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("playerIsMoving", false);
        }
    }

    public void Attacked(int damage)
    {
        health -= damage;
        //Debug.Log(damage);
        CheckHealth();
        if (health <= 0)
        {
            //velocity.y = jumpTakeOffSpeed;
            LossText.SetLoss();
            animator.SetBool("playerIsDead", true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void Healed(int heal)
    {
        if (health < 3)
        {
            health += heal;
        }
        CheckHealth();
    
    }

    private void CheckHealth()
    {
        for (int i = 1; i <= status.Length; i++)
        {
            if (i > health)
            {
                status[i - 1].sprite = grey;
            }
            else
            {
                status[i - 1].sprite = red;

            }
        }
    }

}




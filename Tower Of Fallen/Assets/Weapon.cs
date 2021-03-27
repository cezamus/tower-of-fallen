using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PlayerPlatformerController
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform startPoint;

    private SpriteRenderer weaponSpriteRenderer;

    void Awake()
    {
        weaponSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        transform.rotation = rotation;


       bool flipSprite = (weaponSpriteRenderer.flipX ? (direction.x > 0.1f) : (direction.x < -0.1f));

        if (flipSprite)
        {
            weaponSpriteRenderer.flipX = !weaponSpriteRenderer.flipX;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ammo, startPoint.position, transform.rotation);
        }
    }
}
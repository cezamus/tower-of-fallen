using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoop : MonoBehaviour
{

    private Transform level;
    //privateate BoxCollider2D level;
    
    private float levelWidth = 4.8f;
    private float horizontalOffset = 0f;
    private float levelHeight = 3.6f;
    private float verticalOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("Respawn").transform;
        //Vector2 level = Set(0f, 0f, 0f);
        //level.position = Vector2(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoopChecking()
    {
        if(level)
        {
            if (transform.position.x < level.position.x - 0.5f * levelWidth - horizontalOffset)
            {
                transform.position.Set(level.position.x + 0.5f * levelWidth + horizontalOffset, transform.position.y, transform.position.z);
            }

            if (transform.position.y < level.position.y - 0.5f * levelHeight - verticalOffset)
            {
                transform.position.Set(transform.position.x, level.position.y + 0.5f * levelHeight + verticalOffset, transform.position.z);
            }
        }
        
    }
}

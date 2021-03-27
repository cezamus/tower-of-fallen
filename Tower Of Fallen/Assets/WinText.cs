using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinText : MonoBehaviour
{
    private Text endText;

    // Start is called before the first frame update
    void Start()
    {
        endText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreText.score > 9)
        {
            endText.color = Color.yellow;

            if(Input.GetButtonDown("Jump"))
            {
                ScoreText.score = 0;
                if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
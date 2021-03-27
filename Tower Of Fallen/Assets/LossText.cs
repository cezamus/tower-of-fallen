using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LossText : MonoBehaviour
{
    private Text endText;
    private static bool loss = false;

    // Start is called before the first frame update
    void Start()
    {
        endText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loss)
        {
            endText.color = Color.yellow;
        }

        if (Input.GetButtonDown("Jump") && loss)
        {
            loss = false;
            ScoreText.score = 0;
            SceneManager.LoadScene(0);
        }
    }

    public static void SetLoss()
    {
        loss = true;
    }
}

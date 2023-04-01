using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EyeExercise : MonoBehaviour
{
    public CanvasManager canvasManager;

    public GameObject tipText;
    public GameObject startText;
    public GameObject beginButton;
    public Image dot;

    public float speed;

    public bool movingRight = false;
    public bool movingLeft = false;
    public bool movingUp = false;
    public bool movingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight == true)
        {
            dot.rectTransform.localPosition += Vector3.right * speed * Time.deltaTime;
        }
        if(dot.rectTransform.localPosition.x >= 475 && movingRight == true)
        {
            movingRight = false;
            movingDown = true;
        }
        if(movingDown == true)
        {
            dot.rectTransform.localPosition += Vector3.down * speed * Time.deltaTime;
        }
        if (dot.rectTransform.localPosition.y <= -200 && movingDown == true)
        {
            movingDown = false;
            movingLeft = true;
        }
        if (movingLeft == true)
        {
            dot.rectTransform.localPosition += Vector3.left * speed * Time.deltaTime;
        }
        if (dot.rectTransform.localPosition.x <= -475 && movingLeft == true)
        {
            movingLeft = false;
            movingUp = true;
        }
        if (movingUp == true)
        {
            dot.rectTransform.localPosition += Vector3.up * speed * Time.deltaTime;
        }
        if (dot.rectTransform.localPosition.y >= 200 && movingUp == true)
        {
            movingUp = false;
            tipText.SetActive(true);
            startText.SetActive(true);
            beginButton.SetActive(true);
        }
    }

    public void BeginEye()
    {
        canvasManager.beginCount += 1;

        movingRight = true;
        tipText.SetActive(false);
        startText.SetActive(false);
        beginButton.SetActive(false);
    }
}

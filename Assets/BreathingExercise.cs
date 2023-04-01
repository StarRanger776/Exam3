using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreathingExercise : MonoBehaviour
{
    public CanvasManager canvasManager;

    public bool filling = false;
    public bool draining = false;
    public bool waiting = false;
    public float speed;
    public int count;

    public Image fillCircle;
    public Button beginButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(filling == true && fillCircle.fillAmount < 1)
        {
            fillCircle.fillAmount += speed * Time.deltaTime;
        }
        if(filling == true && fillCircle.fillAmount >= 1 && waiting == false)
        {
            StartCoroutine(WaitTime());
            waiting = true;
        }
        if (draining == true && fillCircle.fillAmount > 0)
        {
            fillCircle.fillAmount -= speed * Time.deltaTime;
        }
        if (draining == true && fillCircle.fillAmount <= 0 && waiting == false)
        {
            count += 1;
            StartCoroutine(WaitTime());
            waiting = true;
        }
    }

    public void BeginBreathing()
    {
        canvasManager.beginCount += 1;

        beginButton.interactable = false;

        filling = true;
    }

    public IEnumerator WaitTime()
    {
        Debug.Log("WaitTime Started");
        yield return new WaitForSeconds(3);
        if(filling == true)
        {
            filling = false;
            waiting = false;
            draining = true;
        }
        else if (draining == true)
        {
            if(count < 3)
            {
                draining = false;
                waiting = false;
                filling = true;
            }
            else
            {
                count = 0;
                draining = false;
                waiting = false;
                filling = false;
                beginButton.interactable = true;
            }
        }
    }
}

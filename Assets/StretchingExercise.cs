using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StretchingExercise : MonoBehaviour
{
    public CanvasManager canvasManager;

    public bool filling = false;
    public bool draining = false;
    public bool waiting = false;
    public float speed;

    public Image fillBar;
    public Button beginButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (filling == true && fillBar.fillAmount < 1)
        {
            fillBar.fillAmount += speed * Time.deltaTime;
        }
        if (filling == true && fillBar.fillAmount >= 1 && waiting == false)
        {
            StartCoroutine(WaitTime());
            waiting = true;
        }
        if (draining == true && fillBar.fillAmount > 0)
        {
            fillBar.fillAmount -= speed * Time.deltaTime;
        }
        if (draining == true && fillBar.fillAmount <= 0 && waiting == false)
        {
            StartCoroutine(WaitTime());
            waiting = true;
        }
    }

    public void BeginStretching()
    {
        canvasManager.beginCount += 1;

        beginButton.interactable = false;

        filling = true;
    }

    public IEnumerator WaitTime()
    {
        Debug.Log("WaitTime Started");
        yield return new WaitForSeconds(5);
        if (filling == true)
        {
            filling = false;
            waiting = false;
            draining = true;
        }
        else if (draining == true)
        {
            draining = false;
            waiting = false;
            filling = false;
            beginButton.interactable = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public BreathingExercise bExc;
    public StretchingExercise sExc;
    public EyeExercise eExc;

    public int points = 0;
    public int beginCount = 0;
    public int stretchThresh = 40;
    public int eyeThresh = 20;

    public GameObject menu;
    public GameObject breathing;
    public GameObject stretching;
    public GameObject eye;

    public bool unlockedStretch = false;
    public bool unlockedEye = false;

    public Button stretchBegin;
    public Button eyeBegin;
    public Button stretchUnlock;
    public Button eyeUnlock;

    public Vector3 resetVector;

    public TMP_Text pointDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointDisplay.text = "Points: " + points;

        if(unlockedStretch == true)
        {
            stretchBegin.interactable = true;
            stretchUnlock.interactable = false;
        }
        if (unlockedEye == true)
        {
            eyeBegin.interactable = true;
            eyeUnlock.interactable = false;
        }
    }

    public void OpenBreathing()
    {
        menu.SetActive(false);
        breathing.SetActive(true);
    }
    public void OpenStretching()
    {
        menu.SetActive(false);
        stretching.SetActive(true);
    }
    public void OpenEye()
    {
        menu.SetActive(false);
        eye.SetActive(true);
    }
    public void CloseBreathing()
    {
        bExc.count = 0;
        bExc.draining = false;
        bExc.waiting = false;
        bExc.filling = false;
        bExc.beginButton.interactable = true;
        bExc.fillCircle.fillAmount = 0;

        points += beginCount * 10;
        beginCount = 0;
        menu.SetActive(true);
        breathing.SetActive(false);
    }
    public void CloseStretching()
    {
        sExc.draining = false;
        sExc.waiting = false;
        sExc.filling = false;
        sExc.beginButton.interactable = true;
        sExc.fillBar.fillAmount = 0;

        points += beginCount * 20;
        beginCount = 0;
        menu.SetActive(true);
        stretching.SetActive(false);
    }
    public void CloseEye()
    {
        eExc.movingUp = false;
        eExc.movingDown = false;
        eExc.movingLeft = false;
        eExc.movingRight = false;
        eExc.tipText.SetActive(true);
        eExc.startText.SetActive(true);
        eExc.beginButton.SetActive(true);
        eExc.dot.rectTransform.localPosition = resetVector;

        points += beginCount * 10;
        beginCount = 0;
        menu.SetActive(true);
        eye.SetActive(false);
    }

    public void UnlockStretch()
    {
        if(points >= stretchThresh)
        {
            unlockedStretch = true;
            points -= stretchThresh;
        }
    }
    public void UnlockEye()
    {
        if (points >= eyeThresh)
        {
            unlockedEye = true;
            points -= eyeThresh;
        }
    }
}

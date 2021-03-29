using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideDisplay : MonoBehaviour
{
    public TextMeshProUGUI GuideText;

    public void displayGuide()
    {
        switch(LevelOptions.GameGuide)
        {
            case "ColourRecall":
                GuideText.text = "Step 1 : \n\tRemember all the colours in each segments showen. " +
                                 "\n\nstep 2: \n\tin the colouring mode , tap on the button below for the colour you wish to paint." +
                                 "Then tap on the segments to colour the image." +
                                 "\n\nStep 3: \n\tonce you think that the painted image is correct tap on the submit button." +
                                 "\n\nClear button to clear all the painted colour on the image.";
                break;
            case "QuickFinger":
                GuideText.text = "Enter Guide for Quick Finger";
                break;
            case "MentalMath":
                GuideText.text = "Enter Guide for Mental Math";
                break;

        }
    }
}

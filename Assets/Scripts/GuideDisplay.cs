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
                GuideText.text = "Select the button with the same color as the color shown on the centre of the screen." +
                                 "\nMove your fingers quickly! and Match the colors correctly!";
                break;
            case "MentalMath":
                GuideText.text = "Step 1: \n\t Remember the numbers and aritmethic symbols" +
                                 "\n\nStep 2: \n\tcalculate the equation" +
                                 "\n\nstep 3: \n\tEnter the Answer and tap on subtmit answer";
                break;
            case "Credits":
                
                GuideText.text = "\t  Credits " +
                            "Project Manger |\n Lee Zhen Wei \n\n" +
                            "Release Manager |\n Jeremaih Chan \n\n" +
                            "Lead Developer |\n Chien Yong Qiang \n\n" +
                            "Frontend Developer |\n Delon Lim Long Ting \n\n"+
                            "Backend Developer |\n Aide Iskandar \n\n"+
                            " Quality Assurance Manager |\n Hong Ze Yi \n\n" +
                            "\n" + 
                            "Special thanks \n\n" +
                            " Icons made by https://www.freepik.com Freepik \n\n Freepik from https://www.flaticon.com/  Flaticon \n\n"+
                            " Game Engine \nUnity Engine";
                break;
        }
    }
}

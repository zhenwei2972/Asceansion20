using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class Mental_math: MonoBehaviour
{
    public List<TMP_Text> textNo, sign, ansText, ansFinal, ansCfm;
    //public TMP_Text no1, no2, no3, no4, no5, no6, no7, no8, no9;
    //public TMP_Text sign1, sign2, sign3, sign4, sign5, sign6;
    public List<GameObject> ans;
    public GameObject Alert, replay, mainmenu;
    public Button cfmbtn1, cfmbtn2, cfmbtn3, finalcfmbtn, replaybtn, mainmenubtn;
    // Start is called before the first frame update

    private char[] arithSign = { '+', '-', 'x', '÷' };
    private bool Ans1Sel = false, Ans2Sel = false, Ans3Sel = false, isRow1 = true, isRow2 = false, isRow3= false;
    private int currAns;
    private float sec = 2.0f;
    private int gcal1, gcal2, gcal3, gcal4, gcal5, gcal6, gcal7, gcal8, gcal9;
    private char garith1, garith2, garith3, garith4, garith5, garith6;
    private List<int> rowNo = new List<int>();
    private List<char> arith = new List<char>();
    private int qnsNo = 5, score = 0;

    void Start()
    {
        setupQns();
        Alert.SetActive(false);
        replay.SetActive(false);
        mainmenu.SetActive(false);

        Button btn = cfmbtn1.GetComponent<Button>();
        btn.onClick.AddListener(SelectedAns1);
        Button btn2 = cfmbtn2.GetComponent<Button>();
        btn2.onClick.AddListener(SelectedAns2);
        Button btn3 = cfmbtn3.GetComponent<Button>();
        btn3.onClick.AddListener(SelectedAns3);
        Button Cfmbtn = finalcfmbtn.GetComponent<Button>();
        Cfmbtn.onClick.AddListener(confirmAns);
       
        ans[1].SetActive(false);
        ans[2].SetActive(false);
    }
    void SelectedAns1()
    {
        Ans1Sel = true;
        Ans2Sel = false;
        Ans3Sel = false;
        if (isRow1)
        {
            ansFinal[0].text = ansCfm[0].text;
        }
        else if (isRow2)
        {
            ansFinal[1].text = ansCfm[0].text;
        }
        else
        {
            ansFinal[2].text = ansCfm[0].text;
        }
        
    }
    void SelectedAns2()
    {
        Ans1Sel = false;
        Ans2Sel = true;
        Ans3Sel = false;
        if (isRow1)
        {
            ansFinal[0].text = ansCfm[1].text;
        }
        else if (isRow2)
        {
            ansFinal[1].text = ansCfm[1].text;
        }
        else
        {
            ansFinal[2].text = ansCfm[1].text;
        }
    }
    void SelectedAns3()
    {
        Ans1Sel = false;
        Ans2Sel = false;
        Ans3Sel = true;
        if (isRow1)
        {
            ansFinal[0].text = ansCfm[2].text;
        }
        else if (isRow2)
        {
            ansFinal[1].text = ansCfm[2].text;
        }
        else
        {
            ansFinal[2].text = ansCfm[2].text;
        }
    }

    void confirmAns()
    {
        if (Ans1Sel || Ans2Sel || Ans3Sel)
        {
            checkAns();
        }
        else
        {
            Alert.SetActive(true);
            StartCoroutine(LateCall());
            Debug.Log("Please select one of the answer");
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
        Alert.SetActive(false);
    }
    private void checkAns()
    {
        if (Ans1Sel && int.Parse(ansCfm[0].text) == currAns)
        {
            score++;
        }
        else if (Ans2Sel && int.Parse(ansCfm[0].text) == currAns)
        {
            score++;
        }
        else if (Ans3Sel && int.Parse(ansCfm[0].text) == currAns)
        {
            score++;
        }
        else
        {
            //does not do anything when incorrect
        }
        //unlock next row if curr row is last row next questions
        nextRowQns();
        //return 0;
    }

    void gotoMainMenu()
    {
        LevelOptions.GameType = "string";
        SceneManager.LoadScene("MainMenu");
    }
    void replaygame()
    {
        SceneManager.LoadScene("Mental_Math");
    }
    void nextRowQns()
    {
        if (isRow3)
        {
            //next qns
            if (qnsNo == 0)
            {
                this.GetComponent<DataHandler>().postMentalMathStats(score.ToString());
                replay.SetActive(true);
                mainmenu.SetActive(true);

                finalcfmbtn.interactable = false;
                cfmbtn1.interactable = false;
                cfmbtn2.interactable = false;
                cfmbtn3.interactable = false;

                Button replybtn = replaybtn.GetComponent<Button>();
                replybtn.onClick.AddListener(replaygame);
                Button menubtn = mainmenubtn.GetComponent<Button>();
                menubtn.onClick.AddListener(gotoMainMenu);
                
            }
            else
            {
                qnsNo--;
                ans[1].SetActive(false);
                ans[2].SetActive(false);
                ansFinal[0].text = "";
                ansFinal[1].text = "";
                ansFinal[2].text = ""; 
                isRow1 = true;
                isRow2 = false;
                isRow3 = false;
                setupQns();
            }
            
        }else if (isRow2)
        {
            //enabled row 3
            isRow3 = true;
            isRow2 = false;
            thirdRowQns();
            ans[2].SetActive(true);
        }
        else
        {
            isRow1 = false;
            isRow2 = true;
            secRowQns();
            ans[1].SetActive(true);
        }
    }

    private int setDifficulty()
    {
        switch (LevelOptions.Level)
        {
            case "Easy":
                return 1;
            case "Medium":
                return 2;
            case "Hard":
                return 3;
            default:
                return 1;
        }
    }

    public void setupQns()
    {
        rowNo.Clear();
        arith.Clear();

        

        for (int i = 0; i < 9; i++)
        {
            rowNo.Add(Random.Range(0, 10));
            textNo[i].text = rowNo[i].ToString();
        }

        if(LevelOptions.Level == "Medium")
        {
            for (int i = 0; i < 6; i++)
            {
                arith.Add(arithSign[Random.Range(0, 3)]);
                sign[i].text = arith[i].ToString();
            }
        }
        else if (LevelOptions.Level == "Hard")
        {
            //hard
            for (int i = 0; i < 6; i++)
            {
                arith.Add(arithSign[Random.Range(0, 3)]);
                sign[i].text = arith[i].ToString();
            }
        }
        else 
        {

            for (int i = 0; i < 6; i++)
            {
                arith.Add(arithSign[Random.Range(0, 2)]);
                sign[i].text = arith[i].ToString();
            }
        }

        firstRowQns();
    }

    private void firstRowQns()
    {
        var ansCal = new List<string>();

        ansCal = popAns(arith[0], arith[3], rowNo[0], rowNo[3], rowNo[6]);
        ansCal.Shuffle();

        for(int i = 0; i < 3; i++)
        {
            ansText[i].text = ansCal[i];
        }
    }
    private void secRowQns()
    {
        var ansCal = new List<string>();

        ansCal = popAns(arith[1], arith[4], rowNo[1], rowNo[4], rowNo[7]);
        ansCal.Shuffle();

        for (int i = 0; i < 3; i++)
        {
            ansText[i].text = ansCal[i];
        }
    }
    private void thirdRowQns()
    {
        var ansCal = new List<string>();

        ansCal = popAns(arith[2], arith[5], rowNo[2], rowNo[5], rowNo[8]);
        ansCal.Shuffle();

        for (int i = 0; i < 3; i++)
        {
            ansText[i].text = ansCal[i];
        }
    }
    private List<string> popAns(char Arithe1, char Arithe2, int num1, int num2, int num3)
    {
        var AnsRet = new List<string>();
        int ans = CheckSign1(Arithe1, Arithe2, num1, num2, num3);

        Debug.Log("The answer is "+ ans);
        currAns = ans; 
        AnsRet.Add(ans.ToString());

        int a1 = 0, a2 = 0;
        int a3 = Random.Range(0, 3);
        while (true)
        {
            if (a3 == 0)
            {
                a1 = ans + Random.Range(1, 4);
                a2 = ans + Random.Range(1, 4);
            }
            else if (a3 == 1)
            {
                a1 = ans - Random.Range(1, 4);
                a2 = ans - Random.Range(1, 4);
            }
            else
            {
                a1 = ans + Random.Range(1, 4);
                a2 = ans - Random.Range(1, 4);
            }

            if (a1 != a2)
            {
                break;
            }
        }
        AnsRet.Add(a1.ToString());
        AnsRet.Add(a2.ToString());

        return AnsRet;
    }

    private int CheckSign1(char Arithe1, char Arithe2, int num1, int num2, int num3)
    {
        int total = 0;
        if (Arithe1 == '÷')
        {
            total = signDivide(Arithe1, Arithe2, num1, num2, num3);
        }
        else if (Arithe1 == 'x')
        {
            total = signMul(Arithe1, Arithe2, num1, num2, num3);
        }
        else if (Arithe1 == '-')
        {
            total = signMinus(Arithe1, Arithe2, num1, num2, num3);
        }
        else if (Arithe1 == '+')
        {
            total = signPlus(Arithe1, Arithe2, num1, num2, num3);
        }

        return total;
    }
    private int signDivide(char Arithe1, char Arithe2, int num1, int num2, int num3)
    {
        int total = 0;
        if (Arithe2 == '÷')
        {
            total = num1 / num2 / num3;
        }
        else if (Arithe2 == 'x')
        {
            total = num1 / num2 * num3;
        }
        else if (Arithe2 == '-')
        {
            total = num1 / num2 - num3;
        }
        else if (Arithe2 == '+')
        {
            total = num1 / num2 + num3;
        }
        return total;   
    }
    private int signMul(char Arithe1, char Arithe2, int num1, int num2, int num3)
    {
        int total = 0;
        if (Arithe2 == '÷')
        {
            total = num1 * num2 / num3;
        }
        else if (Arithe2 == 'x')
        {
            total = num1 * num2 * num3;
        }
        else if (Arithe2 == '-')
        {
            total = num1 * num2 - num3;
        }
        else if (Arithe2 == '+')
        {
            total = num1 * num2 + num3;
        }
        return total;
    }
    private int signMinus(char Arithe1, char Arithe2, int num1, int num2, int num3)
    {
        int total = 0;
        if (Arithe2 == '÷')
        {
            total = num1 - num2 / num3;
        }
        else if (Arithe2 == 'x')
        {
            total = num1 - num2 * num3;
        }
        else if (Arithe2 == '-')
        {
            total = num1 - num2 - num3;
        }
        else if (Arithe2 == '+')
        {
            total = num1 - num2 + num3;
        }
        return total;
    }
    private int signPlus(char Arithe1, char Arithe2, int num1, int num2, int num3)
    {
        int total = 0;
        if (Arithe2 == '÷')
        {
            total = num1 + num2 / num3;
        }
        else if (Arithe2 == 'x')
        {
            total = num1 + num2 * num3;
        }
        else if (Arithe2 == '-')
        {
            total = num1 + num2 - num3;
        }
        else if (Arithe2 == '+')
        {
            total = num1 + num2 + num3;
        }
        return total;
    }

}

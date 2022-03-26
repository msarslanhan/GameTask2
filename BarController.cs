using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public Image MoneyBar1, MoneyBar2;
    public Text economyText;
    int moneyValue;
    public Animator characterAnim;
    bool dontTurnAgain;
    void Update()
    {
        moneyValue = PlayerPrefs.GetInt("Money");
        MoneyBar1.fillAmount = moneyValue/200f;
        if(moneyValue>=200)
        {
            economyText.text = "Average";
            MoneyBar2.fillAmount = (moneyValue -200)/200f;
        }
        if(moneyValue>=400)
        {
            economyText.text = "Rich";
        }

        if(moneyValue==200 && dontTurnAgain ==false || moneyValue==400 && dontTurnAgain == false )
        {
            characterAnim.SetTrigger("Turn");
            dontTurnAgain=true;
            Invoke("DontTurnAgainTrueler",7f);
        }
    }
    void DontTurnAgainTrueler()
    {
        dontTurnAgain = false;
    }
}

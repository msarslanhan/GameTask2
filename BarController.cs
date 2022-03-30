using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public Image MoneyBar1, MoneyBar2;
    public Text economyText;
    int moneyValue;
    public Animator characterAnim2;
    public Animator Turn;
    public GameObject poorObject,averageObject,richObject;
    bool dontTurnAgain,firstUpgrade,secondUpgrade;
    void Start()
    {
        Turn.Play("Turn");
        Turn.enabled = false;
        dontTurnAgain = false;
        firstUpgrade = false;
        secondUpgrade = false;
    }
    void Update()
    {
        moneyValue = PlayerPrefs.GetInt("Money");
        MoneyBar1.fillAmount = moneyValue/200f;
        if(moneyValue>=200)
        {
            MoneyBar2.fillAmount = (moneyValue -200)/200f;
        }
        
        if(moneyValue<200 && firstUpgrade==true && dontTurnAgain == false)
        {
            firstUpgrade = false;
            dontTurnAgain=true;
            characterAnim2.SetTrigger("Sad");

            Turn.enabled = true;
            Invoke("TurnFalser",0.6666f);
            economyText.text = "Poor";
            averageObject.SetActive(false);
            poorObject.SetActive(true);
            Invoke("DontTurnAgainFalser",1.5f);
        }
        

        if(moneyValue>=200 && moneyValue <400 && secondUpgrade==true && dontTurnAgain == false)
        {
            secondUpgrade = false;
            dontTurnAgain=true;
            characterAnim2.SetTrigger("Sad");

            Turn.enabled = true;
            Invoke("TurnFalser",0.6666f);
            richObject.SetActive(false);
            averageObject.SetActive(true);
            economyText.text = "Average";
            Invoke("DontTurnAgainFalser",1.5f);
        }

        if(moneyValue==200 && dontTurnAgain ==false && firstUpgrade==false)
        {
            characterAnim2.SetTrigger("Happy");
            Turn.enabled = true;
            Invoke("TurnFalser",0.6666f);
            dontTurnAgain=true;
            Invoke("DontTurnAgainFalser",1.5f);

            firstUpgrade = true;
            poorObject.SetActive(false);
            averageObject.SetActive(true);
            economyText.text = "Average";
        }
        else if(moneyValue==400 && dontTurnAgain == false && secondUpgrade==false)
        {    
            characterAnim2.SetTrigger("Happy");
            Turn.enabled = true;
            Invoke("TurnFalser",0.6666f);
            dontTurnAgain=true;

            Invoke("DontTurnAgainFalser",1.5f);
            secondUpgrade = true;
            averageObject.SetActive(false);
            richObject.SetActive(true);
            economyText.text = "Rich";
        }    
    }
    void TurnFalser()
    {
        Turn.enabled = false;
    }
    void DontTurnAgainFalser()
    {
        /*characterAnim.ResetTrigger("Turn");*/
        dontTurnAgain = false;
    }
}

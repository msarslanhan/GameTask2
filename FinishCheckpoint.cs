using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheckpoint : MonoBehaviour
{
    public Animator characterAnim;
    public GameObject GameOverPanel;
    bool workOnTime;
    void Start()
    {
        workOnTime =  true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            PlayerPrefs.SetInt("RunXPlane",0);
            PlayerPrefs.SetInt("RunZPlane",0);
            int moneyValue = PlayerPrefs.GetInt("Money");
            if(moneyValue <200 && workOnTime == true)
            {
                workOnTime = false;
                characterAnim.SetTrigger("Die");
                GameOverPanel.SetActive(true);
            }
            else if(moneyValue>=200 && moneyValue<400 && workOnTime == true)
            {
                workOnTime = false;
                characterAnim.SetTrigger("average");
                GameOverPanel.SetActive(true);
            }
            else if(moneyValue>=400 && workOnTime == true)
            {
                workOnTime = false;
                characterAnim.SetTrigger("Dance");
                GameOverPanel.SetActive(true);
            }
        }
    }
}

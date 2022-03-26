using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject StartUI;
    public Text moneyText;
    void Update()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();
    }
    public void PlayButton()
    {
        PlayerPrefs.SetInt("RunZPlane",1);
        StartUI.SetActive(false);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

}

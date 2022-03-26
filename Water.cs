using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject deathPanel;
    public Animator characterAnim;
    void Start()
    {
        Time.timeScale =1f;
        deathPanel.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            characterAnim.SetTrigger("Die");
            deathPanel.SetActive(true);
            Invoke("TimeStoper",1f);
        }
    }
    void DeathPanelActiver()
    {
        deathPanel.SetActive(true);
    }
    void TimeStoper()
    {
        Time.timeScale = 0f;
    }
}

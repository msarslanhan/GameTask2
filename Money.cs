using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Money",0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money")+10);
            Destroy(gameObject);
        }
    }
}

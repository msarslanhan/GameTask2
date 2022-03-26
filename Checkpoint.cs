using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Checkpoint : MonoBehaviour
{
    public GameObject Character, Camera;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            PlayerPrefs.SetInt("RunXPlane",1);
            PlayerPrefs.SetInt("RunZPlane",0);
            Character.transform.DOLocalRotate(new Vector3 (0,90f,0),1f);
            Camera.transform.DOLocalRotate(new Vector3 (19.173f,90f,0),1.5f);
        }
    }
}

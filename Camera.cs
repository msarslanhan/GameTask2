using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camera : MonoBehaviour
{
    public GameObject player;     
    private Vector3 offset;
    void Awake()
    {
        offset= new Vector3(0f,5f,-5.7f);
    }
    void LateUpdate() 
    {
        if(PlayerPrefs.GetInt("RunZPlane")==1)
        {
            offset= new Vector3(0f,5f,-5.7f);
        }
        else if(PlayerPrefs.GetInt("RunXPlane")==1)
        {
            offset= new Vector3(-5.7f,5f,0f);
        }
        /*transform.position = player.transform.position + offset;*/
        if(player.transform!=null)
        {
            transform.DOLocalMove(player.transform.position + offset,1.5f);
        }
    }
}

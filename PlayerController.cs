using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    public int HorizontalSpeed,Speed;
    float HorizontalMove;
    public Animator characterAnim;
    void Start()
    {
        speedModifier = 0.005f;
        if(PlayerPrefs.HasKey("RunZPlane")==false)
        {
            PlayerPrefs.SetInt("RunZPlane",0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("RunZPlane")==1)
        {
            TouchMoveZ();
            HorizontalMove = Input.GetAxis("Horizontal");
            transform.position += new Vector3(HorizontalMove*HorizontalSpeed*Time.deltaTime,0,0);
            transform.position += new Vector3(0,0,Speed*Time.deltaTime);
            characterAnim.SetTrigger("Run");
        }
        else if(PlayerPrefs.GetInt("RunXPlane")==1)
        {
            TouchMoveX();
            HorizontalMove = Input.GetAxis("Horizontal");
            transform.position -= new Vector3(0,0,HorizontalMove*HorizontalSpeed*Time.deltaTime);
            transform.position += new Vector3(Speed*Time.deltaTime,0,0);
            characterAnim.SetTrigger("Run");
        }
        else
        {
            characterAnim.ResetTrigger("Run");
        }

    }

    void TouchMoveZ()
    {
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            {
                transform.position = new Vector3
                (
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z
                );
            }
        }
    }
    void TouchMoveX()
    {
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            {
                transform.position = new Vector3
                (
                    transform.position.x,
                    transform.position.y,
                    transform.position.z - touch.deltaPosition.x * speedModifier
                );
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    public int Speed,HorizontalSpeed;
    float HorizontalMove;
    public Animator characterAnim;
    void Start()
    {
        speedModifier = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        TouchMove();
        if(PlayerPrefs.GetInt("RunZPlane")==1)
        {
            HorizontalMove = Input.GetAxis("Horizontal");
            transform.position += new Vector3(HorizontalMove*HorizontalSpeed*Time.deltaTime,0,0);
            transform.position += new Vector3(0,0,Speed*Time.deltaTime);
            characterAnim.SetTrigger("Run");
        }
        else if(PlayerPrefs.GetInt("RunXPlane")==1)
        {
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

    void TouchMove()
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
}

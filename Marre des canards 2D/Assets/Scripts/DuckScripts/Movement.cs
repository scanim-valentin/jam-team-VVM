using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1; 
    public float rotationSpeed = 1;
    public float borderX = 6, borderY = 3.5f;
    public int PlayerID;
    private string VerticalAxis;
    private string HorizontalAxis;
    private Rigidbody2D rig ;
    // Start is called before the first frame update
    void Start()
    {
        rig = transform.GetComponent<Rigidbody2D>() ;
        switch (PlayerID)
        {
            case 0:
                VerticalAxis = "Vertical";
                HorizontalAxis = "Horizontal";
                break;
            case 1:
                VerticalAxis = "Fire1";
                HorizontalAxis = "Fire2";
                break;
            /*case 2:
                VerticalAxis = "Fire3";
                HorizontalAxis = "Jump";
                break;
            case 3:
                VerticalAxis = "MouseX";
                HorizontalAxis = "MouseY";
                break; */
            default:
                VerticalAxis = "Vertical";
                HorizontalAxis = "Horizontal";
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.AddForce(movementSpeed * transform.right * Input.GetAxis(VerticalAxis), ForceMode2D.Impulse);
        transform.Rotate(rotationSpeed * Vector3.forward * Input.GetAxis(HorizontalAxis));
        ConstraintPosition();
    }

    private void ConstraintPosition()
    {
        if (transform.position.x > borderX)
        {
            transform.position = new Vector3(borderX, transform.position.y, transform.position.z);
        } 
        else if (transform.position.x < -borderX)
        {
            transform.position = new Vector3(-borderX, transform.position.y, transform.position.z);
        }

        if (transform.position.y > borderY)
        {
            transform.position = new Vector3(transform.position.x, borderY, transform.position.z);
        } 
        else if (transform.position.y < -borderY)
        {
            transform.position = new Vector3(transform.position.x, -borderY, transform.position.z);
        }

    }

}


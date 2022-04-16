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

    private bool gameStarted = false; 
    // Start is called before the first frame update
    void Start()
    {
        //On ajoute s'abonne à l'event gameHasStartedEvent
        GameObject.Find("HUD").GetComponent<HUD>().gameHasStartedEvent += onGameStart; 
        
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
        if (gameStarted)
        {
            rig.AddForce(movementSpeed * transform.right * Input.GetAxis(VerticalAxis), ForceMode2D.Impulse);
            transform.Rotate(rotationSpeed * Vector3.forward * Input.GetAxis(HorizontalAxis));
        }
    }

    void onGameStart(HUD hud)
    {
        gameStarted = true; 
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float remainingTime = 30 ;
    private float initTime = 30 ;

    //event li� � la fin du timer
    public delegate void timerExpirationDelegate(Timer t);
    public event timerExpirationDelegate timerExpirationEvent;

    private bool gameStarted = false;
    void Start()
    {
        remainingTime = initTime;
        //On ajoute s'abonne à l'event gameHasStartedEvent
        GameObject.Find("HUD").GetComponent<HUD>().gameHasStartedEvent += onGameStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

            }
            else
            {
                if (timerExpirationEvent != null)
                    timerExpirationEvent(this);
                gameStarted = false; 
            }
        }

    }
    void onGameStart(HUD hud)
    {
        gameStarted = true;
    }


}

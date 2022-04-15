using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float remainingTime;
    private float initTime = 10 ;

    //event li� � la fin du timer
    public delegate void timerExpirationDelegate(Timer t);
    public event timerExpirationDelegate timerExpirationEvent;
    void Start()
    {
        remainingTime = initTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (timerExpirationEvent != null)
                timerExpirationEvent(this); 
        }
    }

}

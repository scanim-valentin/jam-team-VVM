using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Text;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform TextDisplay ; 
    private float timeStartLeft ; 
    private float timeStartInit = 4 ; 
    private bool hasStarted = false ; 
    //event lié au début de la game
    public delegate void GameHasStartedDelegate(HUD t);
    public event GameHasStartedDelegate gameHasStartedEvent;
    void Start()
    {
       timeStartLeft = timeStartInit ; 
       //TextDisplay = transform.Find("Canvas/TextDisplay") ; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            timeStartLeft -= Time.deltaTime ; 
            if(timeStartLeft > 0 )
                TextDisplay.GetComponent<UnityEngine.UI.Text>().text = ""+Mathf.Floor(timeStartLeft);
            else{
                TextDisplay.GetComponent<UnityEngine.UI.Text>().text = "" ; 
                hasStarted = true ;
                if(gameHasStartedEvent != null)
                    gameHasStartedEvent(this) ;  
            }
        }
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
   
    public GameObject playerGreen;
    public GameObject playerRed;
    private bool GameOver = false; 
    void Start()
    {
        timeStartLeft = timeStartInit ;
        //TextDisplay = transform.Find("Canvas/TextDisplay") ; 
        //On ajoute s'abonne à l'event timerExpirationEvent
        GameObject.Find("Controller").GetComponent<Timer>().timerExpirationEvent += onTimerExpiration ;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            timeStartLeft -= Time.deltaTime ;
            if (timeStartLeft > 1)
                TextDisplay.GetComponent<UnityEngine.UI.Text>().text = "" + Mathf.Floor(timeStartLeft);
            else if (timeStartLeft > 0)
                TextDisplay.GetComponent<UnityEngine.UI.Text>().text = "Go!"; 
            else
            {
                TextDisplay.GetComponent<UnityEngine.UI.Text>().text = "";
                hasStarted = true;
                if (gameHasStartedEvent != null)
                    gameHasStartedEvent(this);
            }
        }
        if (GameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    public void onTimerExpiration(Timer T)
    {
        GameOver = true; 
        string winner = ""; 
        if(playerRed.GetComponent<Score>().ScoreValue > playerGreen.GetComponent<Score>().ScoreValue)
        {
            winner = "Blue";
        }
        else if(playerRed.GetComponent<Score>().ScoreValue < playerGreen.GetComponent<Score>().ScoreValue)
        {
            winner = "Green";
        }
        else
        {
            winner = "No one";
        }
        TextDisplay.GetComponent<UnityEngine.UI.Text>().fontSize = 32; 
        TextDisplay.GetComponent<UnityEngine.UI.Text>().text = winner+" won\n\nPress R to play again";
    }


}

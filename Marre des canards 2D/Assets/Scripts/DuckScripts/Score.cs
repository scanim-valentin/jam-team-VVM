using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int ScoreValue = 0;

    private bool isAngry = false;
    private int AngryThreshold = 3; 

    private bool isEating = false;
    private float animTime;
    private float initAnimTime = 1f ;
    public float frameTime;
    private float initFrameTime = 0.3f;

    //Size of an angry duck
    public float angrySize = 3f;

    //Speed at which the duck changes scale when bread bar is full
    public float rescalingSpeed = 1.005f;

    //event lié à la perte de vie
    public delegate void UpdateScoreDelegate(Score t);
    public event UpdateScoreDelegate updateScoreEvent;
    private GameObject normalSprite;
    private GameObject eatingSprite;
    private GameObject angrySprite;

    void Start()
    {
        normalSprite = transform.GetChild(0).gameObject;
        angrySprite = transform.GetChild(1).gameObject;
        eatingSprite = transform.GetChild(2).gameObject;
        animTime = initAnimTime;
        frameTime = initFrameTime; 

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAngry && (ScoreValue >= AngryThreshold ))
        {
            angrySprite.SetActive(true);
            normalSprite.SetActive(false);
            eatingSprite.SetActive(false);
            isAngry = true;
        }

        if( isAngry && (transform.localScale.x <= angrySize )  )
        {
            transform.localScale *= rescalingSpeed * (1f + Time.deltaTime);
        }

        if(isEating)
        {
            if (animTime > 0) {
                animTime -= Time.deltaTime; 
                if (frameTime >= initFrameTime)
                {
                    if (eatingSprite.activeSelf)
                    {
                        eatingSprite.SetActive(false);
                        normalSprite.SetActive(true);
                    }
                    else
                    {

                        eatingSprite.SetActive(true);
                        normalSprite.SetActive(false);
                    }
                    frameTime -= Time.deltaTime;
                }
                else
                {
                    frameTime = (frameTime >= 0) ? (frameTime - Time.deltaTime) : (initFrameTime);  
                }
            }
            else
            {
                animTime = initAnimTime;
                isEating = false;
                eatingSprite.SetActive(false);
                normalSprite.SetActive(true);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collider){
        //Debug.Log("Col"); 
        GameObject collided = collider.gameObject ; 
        if(collider.tag == "Bullet" && isAngry){
            //Taking damage when angry
            if(collided.GetComponent<Trajectory>().Source != gameObject){
                AddToScore(-1); 
                Destroy(collided) ;
            }
        } else {
            if(collider.tag == "Item"){
                AddToScore(1); 
                Destroy(collided) ;
                if(!isAngry)
                    isEating = true;  
            }
        }
    }

    private void AddToScore(int Value)
    {
        ScoreValue += Value ;
        if (updateScoreEvent != null)
            updateScoreEvent(this);
    }
}

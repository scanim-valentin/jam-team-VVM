using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int ScoreValue = 0;
    public int BreadValue = 0; 
    public bool isAngry = false;
    private int AngryThreshold = 4; 

    private bool isEating = false;
    private float animTime;
    private float initAnimTime = 1f ;
    public float frameTime;
    private float initFrameTime = 0.3f;

    //Size of an angry duck
    public float angrySize = 3f;
    public float regularSize = 1f; 

    //Speed at which the duck changes scale when bread bar is full
    public float rescalingSpeed = 1.005f;

    public float KnockbackForce = 5f;

    public float forceLimiter = 2.0f;

    //event lié à la perte de vie
    public delegate void UpdateScoreDelegate(Score t);
    public event UpdateScoreDelegate updateScoreEvent;
    private GameObject normalSprite;
    private GameObject eatingSprite;
    private GameObject angrySprite;

    public GameObject PainBar;
    private SpriteRenderer PainBarSpriteRenderer;
    //timing variables used to score points when angry
    public float scoreTime;
    public float scoreTimeInit = 0.5f ; 

    void Start()
    {
        normalSprite = transform.GetChild(0).gameObject;
        angrySprite = transform.GetChild(1).gameObject;
        eatingSprite = transform.GetChild(2).gameObject;
        animTime = initAnimTime;
        frameTime = initFrameTime;
        scoreTime = scoreTimeInit;
        PainBarSpriteRenderer = PainBar.GetComponent<SpriteRenderer>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if (isAngry)
        {
            if (scoreTime > 0) 
                scoreTime -= Time.deltaTime;
            else
            {
                ScoreValue += 1;
                scoreTime = scoreTimeInit; 
            }
        }

        if (!isAngry && (BreadValue >= AngryThreshold ))
        {
            angrySprite.SetActive(true);
            normalSprite.SetActive(false);
            eatingSprite.SetActive(false);
            isAngry = true;
        }

        if(isAngry && BreadValue <= 0)
        {
            angrySprite.SetActive(false);
            normalSprite.SetActive(true);
            eatingSprite.SetActive(false);
            isAngry = false;
        }

        if( isAngry && (transform.localScale.x <= angrySize )  )
        {
            transform.localScale *= rescalingSpeed * (1f + Time.deltaTime);
        }

        if (!isAngry && (transform.localScale.x > regularSize))
        {
            transform.localScale /= (rescalingSpeed) * (1f + Time.deltaTime);
        }

        if (isEating)
        {
            if (animTime > 0) {
                animTime -= Time.deltaTime; 
                if (frameTime >= initFrameTime)
                {
                    if (eatingSprite.activeSelf)
                    {
                        eatingSprite.SetActive(false);
                        if (isAngry)
                        {
                            angrySprite.SetActive(true);
                            normalSprite.SetActive(false);
                        }
                        else
                        {
                            normalSprite.SetActive(true);
                            angrySprite.SetActive(false);
                        }
                    }
                    else
                    {

                        eatingSprite.SetActive(true);
                        angrySprite.SetActive(false);
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
                if (isAngry)
                {
                    angrySprite.SetActive(true);
                    normalSprite.SetActive(false);
                }
                else
                {
                    normalSprite.SetActive(true);
                    angrySprite.SetActive(false);
                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collider){

        GameObject collided = collider.gameObject ;
        if (collider.tag == "Bullet")
        {
            //Taking damage when angry
            if (collided.GetComponent<Trajectory>().Source != gameObject)
            {
                Destroy(collided);
                transform.GetComponent<Rigidbody2D>().AddForce(-KnockbackForce * transform.right, ForceMode2D.Impulse);
                

            }
        }
        else if (collider.tag == "Item")
        {
            if (BreadValue < AngryThreshold) 
            { 
                BreadValue++;
                PainBarSpriteRenderer.size = new Vector2(BreadValue * 4 / AngryThreshold, PainBarSpriteRenderer.size.y);
            }
            Destroy(collided) ;
            isEating = true;  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.GetComponent<Rigidbody2D>().AddForce(-KnockbackForce * (collision.gameObject.transform.position - transform.position), ForceMode2D.Impulse);
            if (isAngry)
            {
                BreadValue--;
                PainBarSpriteRenderer.size = new Vector2(BreadValue * 4 / AngryThreshold, PainBarSpriteRenderer.size.y);
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

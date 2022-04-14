using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int HealthValue = 20; 

    //event lié à la perte de vie
    public delegate void DamageDelegate(HealthScript t);
    public event DamageDelegate damageEvent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider){
        GameObject collided = collider.gameObject ; 
        if(collider.tag == "Bullet"){
            //Damages
            if(collided.GetComponent<Trajectory>().Source != gameObject){
                if (damageEvent != null)
                    damageEvent(this);
                HealthValue -= 1 ; 
                Destroy(collided) ;
            }
        } else {
            if(collider.tag == "Item"){
                Destroy(collided) ;
            }
        }
    }
}

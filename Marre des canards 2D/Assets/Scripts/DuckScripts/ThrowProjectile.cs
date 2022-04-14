using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    //Projectile used by ducks
    public GameObject projectile ; 

    //Throwing force of ducks
    public float throwForce = 10 ; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //To be changed later using unity input manager
        if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject projectileInstance = Instantiate(projectile, transform.localPosition, transform.rotation);
                    projectileInstance.GetComponent<Trajectory>().Source = gameObject ;    
                }
    }
}

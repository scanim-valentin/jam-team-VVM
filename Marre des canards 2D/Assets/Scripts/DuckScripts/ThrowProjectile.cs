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
                    GameObject projectileInstance = Instantiate(projectile, transform.localPosition+ new Vector3(2f,0f,0f), transform.rotation);
                    projectileInstance.GetComponent<Rigidbody2D>().AddForce(throwForce*transform.right, ForceMode2D.Impulse);      
                }
    }
}

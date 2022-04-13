using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeed ; 
    public float RotationSpeed ;
    private Rigidbody2D rig ; 
    // Start is called before the first frame update
    void Start()
    {
        rig = transform.GetComponent<Rigidbody2D>() ; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("z")){
            rig.AddForce(MovementSpeed*transform.right, ForceMode2D.Impulse);
        }
        if(Input.GetKey("s")){
            rig.AddForce(-MovementSpeed*transform.right, ForceMode2D.Impulse);
        }
        if(Input.GetKey("d")){
            transform.Rotate(RotationSpeed*transform.forward) ; 
        }
        if(Input.GetKey("q")){
            transform.Rotate(-RotationSpeed*transform.forward) ;
        }
    }
}

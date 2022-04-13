using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed ; 
    public float rotationSpeed ;
    public float borderX = 6, borderZ = 3.5f;
    private Rigidbody rig ; 
    // Start is called before the first frame update
    void Start()
    {
        rig = transform.GetComponent<Rigidbody>() ; 
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(movementSpeed * transform.right * Input.GetAxis("Vertical"), ForceMode.Impulse);
        transform.Rotate(rotationSpeed * Vector3.forward * Input.GetAxis("Horizontal"));
        ConstraintPosition();
    }

    private void ConstraintPosition()
    {
        if (transform.position.x > borderX)
        {
            transform.position = new Vector3(borderX, transform.position.y, transform.position.z);
        } 
        else if (transform.position.x < -borderX)
        {
            transform.position = new Vector3(-borderX, transform.position.y, transform.position.z);
        }

        if (transform.position.z > borderZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, borderZ);
        } 
        else if (transform.position.z < -borderZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -borderZ);
        }
    }

}


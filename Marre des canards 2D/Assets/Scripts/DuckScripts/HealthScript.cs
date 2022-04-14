using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    //Default = ??
    public int HealthValue = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthValue == 0){
            //Call death event
            Destroy(gameObject) ; 
        }
    }
}

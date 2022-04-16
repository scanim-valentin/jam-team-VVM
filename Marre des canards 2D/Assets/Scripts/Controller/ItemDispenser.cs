using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : MonoBehaviour
{
    public int itemQuantity = 10;
    // Start is called before the first frame update
    private Transform spawnAreaTrans;
    public GameObject food; 
    void Start()
    {
        spawnAreaTrans = GameObject.Find("SpawnArea").transform; 

        for (int k = 0; k < itemQuantity; k++)
        {
            //Randomly spawn items
            float randX = Random.Range(-(spawnAreaTrans.localScale.x / 2), (spawnAreaTrans.localScale.x / 2));
            float randY = Random.Range(-(spawnAreaTrans.localScale.y / 2), (spawnAreaTrans.localScale.y / 2));
            Instantiate(food, new Vector3(randX, randY, -3), Quaternion.Euler(0,0,Random.Range(0,360))); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

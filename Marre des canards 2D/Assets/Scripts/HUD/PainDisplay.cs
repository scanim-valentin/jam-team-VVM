using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainDisplay : MonoBehaviour
{
    public int nbPainsAManger = 5;
    public Vector3 lastMiePosition;
    private int painManges = 0;

    private Vector3 increaseBarrePain;

    // Start is called before the first frame update
    void Start()
    {
        increaseBarrePain = (lastMiePosition - transform.position)/nbPainsAManger;
    }

    // Update is called once per frame
    void IncreaseBarre()
    {
        painManges++;
        if (painManges > nbPainsAManger)
        {

        } else
        {
            transform.position += increaseBarrePain;
        }
    }
}

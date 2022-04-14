using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Text;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ScoreRouge ; 
    public GameObject ScoreBleu ; 
    public GameObject ScoreVert ; 
    public GameObject ScoreRose ; 
    void Start()
    {
       //public Text Test_Text = "Fait chier";
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreBleu = HUD.GetComponent<UnityEngine.UI.Text>();
        //ScoreBleu.text = "test";
        ScoreBleu.GetComponent<UnityEngine.UI.Text>().text = "Score : Bleu";
        ScoreRouge.GetComponent<UnityEngine.UI.Text>().text = "Score : Rouge";
        ScoreRose.GetComponent<UnityEngine.UI.Text>().text = "Score : Rose";
        ScoreVert.GetComponent<UnityEngine.UI.Text>().text = "Score : Vert";
        //ScoreBleu.Text = "test";
        //EncoreUnTest.GetComponent<UnityEngine.UI.Text>().text = "Tu vas marcher oui ???";
    }
}

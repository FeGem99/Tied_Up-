using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monete : MonoBehaviour
{
    public Text moneteText;
    public GameObject scoreProgressObject;

    private void Start()
    {
        score_progress scoreProgress = scoreProgressObject.GetComponent<score_progress>();

        int puntiTotali = score_progress.score;

        int moneteAssegnate = 0;

        if (puntiTotali == 100000)
        {
            moneteAssegnate = 25;
        }
        else if (puntiTotali >= 80001 && puntiTotali <= 99999)
        {
            moneteAssegnate = 20;
        }
        else if (puntiTotali >= 65000 && puntiTotali <= 80000)
        {
            moneteAssegnate = 15;
        }
        else if (puntiTotali >= 40000 && puntiTotali <= 64999)
        {
            moneteAssegnate = 10;
        }
        else if (puntiTotali >= 10000 && puntiTotali <= 39999)
        {
            moneteAssegnate = 5;
        }
        else if (puntiTotali >= 0 && puntiTotali <= 9999)
        {
            moneteAssegnate = 0;
        }

        // Assegna le monete alla tua logica di gioco
        // ...

        moneteText.text = " " + moneteAssegnate.ToString();
    }
}
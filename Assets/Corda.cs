using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corda : MonoBehaviour
{
     public Transform personaggio1;
    public Transform personaggio2;
    public float lunghezzaMassima = 5f;

    private LineRenderer lineRenderer;
  
  
    // Start is called before the first frame update
    void Start()
    {
     lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;   
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 posizione1 = personaggio1.position;
        Vector3 posizione2 = personaggio2.position;

        float distanza = Vector3.Distance(posizione1, posizione2);
        float lunghezzaAttuale = Mathf.Min(distanza, lunghezzaMassima);

        Vector3 direzione = (posizione2 - posizione1).normalized;
        Vector3 posizioneFine = posizione1 + direzione * lunghezzaAttuale;

        lineRenderer.SetPosition(0, posizione1);
        lineRenderer.SetPosition(1, posizioneFine);
    }
}

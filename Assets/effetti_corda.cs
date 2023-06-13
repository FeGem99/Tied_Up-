using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effetti_corda : MonoBehaviour
{
     public Rigidbody2D personaggio1;
    public Rigidbody2D personaggio2;
    public float lunghezzaMassima;
    public float rigiditaMolla;

    private DistanceJoint2D distanceJoint;
    // Start is called before the first frame update
    void Start()
    {
       distanceJoint = gameObject.AddComponent<DistanceJoint2D>();
        distanceJoint.connectedBody = personaggio2;
        distanceJoint.autoConfigureDistance = false;
        distanceJoint.distance = lunghezzaMassima;
        distanceJoint.maxDistanceOnly = true; 
    }

    // Update is called once per frame
    void Update()
    {
        float distanza = Vector2.Distance(personaggio1.position, personaggio2.position);

        if (distanza > lunghezzaMassima)
        {
            Vector2 direzione = personaggio2.position - personaggio1.position;
            distanceJoint.distance = lunghezzaMassima;
            personaggio1.MovePosition(personaggio2.position - direzione.normalized * lunghezzaMassima);
        }
        else
        {
            distanceJoint.distance = distanza;
        }
    }
}

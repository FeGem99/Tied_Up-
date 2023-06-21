using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corda1_menu : MonoBehaviour
{

    public LineRenderer lineRenderer;
public Transform cursorTransform;

    // Use this for initialization
   void Start()
{
    lineRenderer = GetComponent<LineRenderer>();
}
    // Update is called once per frame
   void Update()
{
    // Ottieni la posizione del cursore del mouse nel mondo
    Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    cursorPosition.z = 0f; // Assicurati che la corda si trovi sul piano z=0

    // Imposta la posizione finale della corda come la posizione del cursore del mouse
    lineRenderer.SetPosition(1, cursorPosition);
}
}
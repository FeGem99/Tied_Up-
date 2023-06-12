using UnityEngine;

public class RopeController : MonoBehaviour
{
    public Transform personaggio1;
    public Transform personaggio2;
    public float lunghezzaIniziale = 5f;

    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Imposta i personaggi come solidali alla corda
        personaggio1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        personaggio2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        // Calcola la distanza iniziale e aggiorna il Line Renderer
        CalcolaEAggiornaDistanzaIniziale();
    }

    void CalcolaEAggiornaDistanzaIniziale()
    {
        Vector2 posizionePersonaggio1 = personaggio1.position;
        Vector2 posizionePersonaggio2 = personaggio2.position;

        float distanzaIniziale = Vector2.Distance(posizionePersonaggio1, posizionePersonaggio2);

        // Aggiorna il Line Renderer
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, posizionePersonaggio1);
        lineRenderer.SetPosition(1, posizionePersonaggio2);

        // Imposta la distanza del Distance Joint
        distanceJoint = gameObject.AddComponent<DistanceJoint2D>();
        distanceJoint.connectedBody = personaggio2.GetComponent<Rigidbody2D>();
        distanceJoint.distance = distanzaIniziale;
    }

    void Update()
    {
        // Aggiorna dinamicamente la lunghezza della corda
        float distanzaAttuale = Vector2.Distance(personaggio1.position, personaggio2.position);
        distanceJoint.distance = distanzaAttuale;

        // Aggiorna i punti del Line Renderer
        lineRenderer.SetPosition(0, personaggio1.position);
        lineRenderer.SetPosition(1, personaggio2.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class Rope : MonoBehaviour
{
   private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();

    private float lineWidth = 0.1f;
    private int MaxDistance = 8;
    public Transform personaggio1;
    public Transform personaggio2;
   
    private float ropeSegLen = 0.1f;
    private int segmentLength = 35;
    private EdgeCollider2D edgeCollider2D;
    private float tensionSpeed;





    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = personaggio1.position;
        //inserisco i punti di collisione della corda
        edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;

            if (i == 35)
         break;
            
        }
         Vector2[] colliderPoints = new Vector2[segmentLength];
    for (int i = 0; i < segmentLength; i++)
    {
        colliderPoints[i] = ropeSegments[i].posNow;
    }
        edgeCollider2D.points = colliderPoints;

        
    }

    // Update is called once per frame
    void Update()
    {
        this.DrawRope();
    }

    private void FixedUpdate()
    {
        this.Simulate();
    }

    private void Simulate()
    {
        // SIMULATION
        Vector2 forceGravity = new Vector2(0f, -1.5f);

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;
        }
        //logica della collisione
         if (Vector2.Distance(personaggio1.position, personaggio2.position) > MaxDistance)
    {
        Vector2 direction = (personaggio2.position - personaggio1.position).normalized;
        Vector2 targetPosition = (Vector2)personaggio1.position + direction * MaxDistance;
        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment segment = this.ropeSegments[i];
            segment.posNow = targetPosition;
            this.ropeSegments[i] = segment;
        }
    }
    
        //CONSTRAINTS
        for (int i = 0; i < 10; i++)
        {
            this.ApplyConstraint();
        }
        
    }

    private void ApplyConstraint()
{
    // Constraint to Mouse
    RopeSegment firstSegment = this.ropeSegments[0];
    firstSegment.posNow = personaggio1.position;
    this.ropeSegments[0] = firstSegment;

    RopeSegment lastSegment = this.ropeSegments[segmentLength - 1];
    lastSegment.posNow = personaggio2.position;
    this.ropeSegments[segmentLength - 1] = lastSegment;

    Vector2 charactersDistance = personaggio2.position - personaggio1.position;
    float currentDistance = charactersDistance.magnitude;

    if (currentDistance > MaxDistance)
{
    Vector2 direction = charactersDistance.normalized;
    Vector2 maxDistanceOffset = direction * (currentDistance - MaxDistance);

    RopeSegment firstSeg = this.ropeSegments[0];
    firstSeg.posNow += maxDistanceOffset;
    this.ropeSegments[0] = firstSeg;

    RopeSegment lastSeg = this.ropeSegments[segmentLength - 1];
    lastSeg.posNow -= maxDistanceOffset;
    this.ropeSegments[segmentLength - 1] = lastSeg;

    Vector2 newPosition1 = (Vector2)personaggio2.position - direction * MaxDistance;
    Vector2 newPosition2 = (Vector2)personaggio1.position + direction * MaxDistance;

    personaggio1.position = newPosition1;
    personaggio2.position = newPosition2;
}
    for (int i = 0; i < this.segmentLength - 1; i++)
    {
        RopeSegment firstSeg = this.ropeSegments[i];
        RopeSegment secondSeg = this.ropeSegments[i + 1];

        float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
        float error = Mathf.Abs(dist - this.ropeSegLen);
        Vector2 changeDir = Vector2.zero;

        if (dist > ropeSegLen)
        {
            changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
        }
        else if (dist < ropeSegLen)
        {
            changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
        }

        Vector2 changeAmount = changeDir * error;
        if (i != 0)
        {
            firstSeg.posNow -= changeAmount * 0.5f;
            this.ropeSegments[i] = firstSeg;
            secondSeg.posNow += changeAmount * 0.5f;
            this.ropeSegments[i + 1] = secondSeg;
        }
        else
        {
            secondSeg.posNow += changeAmount;
            this.ropeSegments[i + 1] = secondSeg;
        }
    }
}



    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
// aggiornamento punti del collider
    Vector2[] colliderPoints = new Vector2[segmentLength];
    for (int i = 0; i < segmentLength; i++)
    {
        colliderPoints[i] = ropeSegments[i].posNow;
    }
    edgeCollider2D.points = colliderPoints;
    }
}
public struct RopeSegment
{
    public Vector2 posNow;
    public Vector2 posOld;

    public RopeSegment(Vector2 pos)
    {
        this.posNow = pos;
        this.posOld = pos;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videocamera : MonoBehaviour
{
    public Transform personaggio1;
    public Transform personaggio2;

    private void Update()
    {
        // Calcola la posizione media tra i due personaggi
        Vector3 posizioneMedia = (personaggio1.position + personaggio2.position) / 2f;

        // Aggiorna la posizione della telecamera in base alla posizione media
        transform.position = new Vector3(posizioneMedia.x, posizioneMedia.y, transform.position.z);
    }
}

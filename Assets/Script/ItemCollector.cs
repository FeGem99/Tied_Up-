using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text GemsText;
    public int gemme = 0;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Gems")){
            Destroy(collision.gameObject);
            gemme++;
            GemsText.text = "Gemme: " +gemme;
        }
    }
}

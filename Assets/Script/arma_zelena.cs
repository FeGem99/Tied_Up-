using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class arma_zelena : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proiettile da istanziare
    public Transform firePoint; // Punto di origine del proiettile
    public KeyCode fireKey = KeyCode.DownArrow; // Tasto per attivare l'azione dell'arma

    private bool canFire = true; // Indica se l'arma può sparare

    void Update()
    {
        if (Input.GetKeyDown(fireKey) && canFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Crea un nuovo proiettile a partire dal prefab
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Esegui eventuali altre azioni dell'arma, come l'animazione dell'attacco

        // Esempio: applica una forza al proiettile in avanti
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.AddForce(firePoint.right * 500f);

        // Disabilita temporaneamente la possibilità di sparare per evitare il fuoco continuo
        canFire = false;

        // Avvia una coroutine per riabilitare l'uso dell'arma dopo un certo intervallo di tempo
        StartCoroutine(ResetFire());
    }

    IEnumerator ResetFire()
    {
        // Attendi per un certo intervallo di tempo prima di riabilitare l'uso dell'arma
        yield return new WaitForSeconds(1f); // Modifica il valore se desideri un intervallo diverso

        // Riabilita l'uso dell'arma
        canFire = true;
    }
}


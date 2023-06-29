using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacco_scheletrino: MonoBehaviour
{
    public Animator animator; // Riferimento all'animator del personaggio
    public KeyCode attackKey = KeyCode.S; // Tasto per attivare l'attacco
    public Transform gunBarrel; // Riferimento al punto di origine del proiettile
    public GameObject bulletPrefab; // Prefab del proiettile
    public float attackInterval = 2f; // Intervallo di tempo tra gli attacchi

    private bool isAttacking = false; // Flag per l'attacco in corso
    private float attackTimer = 0f; // Timer per il controllo degli attacchi

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            // Attiva l'attacco
            StartAttack();
        }
    }

    private void StartAttack()
    {
        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;
            isAttacking = true;
            animator.SetTrigger("Shoot"); // Avvia l'animazione di sparare nel controller dell'animator
        }
    }

    // Metodo chiamato dall'animazione quando l'attacco è completo
    public void FinishAttack()
    {
        isAttacking = false;
    }

    // Metodo chiamato dall'animazione durante il frame in cui l'arma spara
    public void FireBullet()
    {
        // Crea il proiettile dal prefab
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        
        // Implementa il comportamento del proiettile (movimento, danni, ecc.)
        // Puoi accedere al componente del proiettile e impostare i parametri necessari
        
        // Esempio: Ottieni il componente BulletController dal proiettile e imposta la velocità
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetVelocity(gunBarrel.right); // Supponendo che il proiettile abbia un metodo SetVelocity per impostare la direzione

        // Puoi anche collegare il proiettile al personaggio, ad esempio, impostando il personaggio come genitore del proiettile
        bullet.transform.SetParent(transform);
    }
}

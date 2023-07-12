using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma_zelena : MonoBehaviour
{
    private Animator anim;
    public GameObject projectilePrefab; // Prefab del proiettile da istanziare
    public Transform firePoint; // Punto di origine del proiettile
    public KeyCode fireKey = KeyCode.DownArrow; // Tasto per attivare l'azione dell'arma

    private bool canFire = true; // Indica se l'arma può sparare

    private Zelena_Movement zelenaMovement; // Riferimento allo script del personaggio

    private void Start()
    {
        anim = GetComponent<Animator>();
        zelenaMovement = GetComponent<Zelena_Movement>(); // Otteniamo il riferimento allo script Zelena_Movement
    }

    private void Update()
    {
        if (Input.GetKeyDown(fireKey) && canFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
    
   // Crea un'offset per regolare la posizione di partenza del proiettile
Vector3 firePointOffset = new Vector3(0f, -2f, 0f);

// Calcola la posizione di partenza del proiettile tenendo conto dell'offset
Vector3 projectileStartPosition = firePoint.position + firePointOffset;

// Crea un nuovo proiettile a partire dal prefab


 // Crea un nuovo proiettile a partire dal prefab
    GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

    // Determina la direzione del personaggio in base all'input di movimento
    float direction = Input.GetAxisRaw("HorizontalZ");

    // Esegui eventuali altre azioni dell'arma, come l'animazione dell'attacco

    // Esempio: applica una forza al proiettile nella direzione corretta
    Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
    projectileRigidbody.AddForce(Vector2.right * direction * 500f);
    projectileRigidbody.gravityScale = 0f; // Imposta la gravità a 0 per il proiettile

    // Disabilita temporaneamente la possibilità di sparare per evitare il fuoco continuo
    canFire = false;

    // Avvia una coroutine per riabilitare l'uso dell'arma dopo un certo intervallo di tempo
    StartCoroutine(ResetFire(projectile));
}

   private IEnumerator ResetFire(GameObject projectile)
{
    // Attendi per un certo intervallo di tempo prima di riabilitare l'uso dell'arma
    yield return new WaitForSeconds(1f); // Modifica il valore se desideri un intervallo diverso

    // Riabilita l'uso dell'arma
    canFire = true;

    // Distruggi il proiettile
    if (projectile != null)
    {
        Destroy(projectile);
    }
}



    private IEnumerator EnableCharacterCollision(Collider2D characterCollider, Collider2D projectileCollider)
    {
        yield return new WaitForSeconds(0.1f); // Modifica il valore se necessario

        // Abilita le collisioni tra il personaggio e il proiettile
        Physics2D.IgnoreCollision(characterCollider, projectileCollider, false);
    }

    private IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(0.1f); // Modifica il valore se necessario

        // Riabilita lo script del personaggio
        zelenaMovement.enabled = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Nemico"))
        {
            Sheletrini sheletrini = collision.gameObject.GetComponent<Sheletrini>();
            if (sheletrini != null)
            {
                sheletrini.TakeDamage(1);
            }
        }
    }
}
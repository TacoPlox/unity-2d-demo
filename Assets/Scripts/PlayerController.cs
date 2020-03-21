using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject projectile;

    public float fireDelay = 1f;

    private float timeSinceLastFire = 0f;

    public float playerSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //-1 <-- 0 --> 1
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        // if (verticalMovement != 0f) {
        //     Vector2 newPosition = new Vector2(0f, (verticalMovement * 0.1f));
        //     transform.Translate(newPosition);
        // }

        // if (horizontalMovement != 0f) {
        //     Vector2 newPosition = new Vector2(horizontalMovement * 0.1f, 0f);
        //     transform.Translate(newPosition);
        // }

        if (verticalMovement != 0f || horizontalMovement != 0f) {
            //Vector2(x, y)
            Vector2 newPosition = new Vector2(horizontalMovement * playerSpeed, verticalMovement * playerSpeed);
            transform.Translate(newPosition);
        }

        //Agregar tiempo de ultimo frame al tiempo transcurrido
        timeSinceLastFire += Time.deltaTime;

        //Solamente se puede disparar si ya pasó el tiempo definido
        if (timeSinceLastFire >= fireDelay) {
            //Can shoot
            // if (Input.GetKeyDown(KeyCode.Space)) {
            if (Input.GetButton("Fire1")) {

                //Crear proyectil
                Instantiate(projectile, transform.position + new Vector3(0f, 2f, 0f), transform.rotation);
                projectile.GetComponent<Projectile>().damageableTargetTag = "Enemy";

                //Reiniciar contador de tiempo para disparar                
                timeSinceLastFire = 0f;
            }
        }


        
    }
}

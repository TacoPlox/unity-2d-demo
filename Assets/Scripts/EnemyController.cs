using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float fireDelay = 1f;
    public int onFireProjectileCount = 3;
    private int projectilesFired = 0;

    public GameObject projectile;
    private float timeSinceLastFire = 0f;

    private float minPositionX = 0f;
    private float maxPositionX = 1f;

    private bool movingRight = true;

    public float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Tamaño pantalla
        //Screen.width

        //Tamaño de la nave
        // SpriteRenderer sr = GetComponent<SpriteRenderer>();
        // float spriteWidth = sr.sprite.rect.width;

        // maxPositionX = GetWindow<SceneView>().camera.pixelRect.width;
        // maxPositionX = Camera.current.pixelRect.width - (spriteWidth / 2);
        // maxPositionX = 1;
        // minPositionX = 0;

        // var pos = Camera.main.WorldToViewportPoint(transform.position);
        // pos.x = Mathf.Clamp01(pos.x);
        // pos.y = Mathf.Clamp01(pos.y);


        // Debug.Log($"maxPositionX = {maxPositionX}");
        // Debug.Log($"minPositionX = {minPositionX}");
        // minPositionX = 0 + (spriteWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {

        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        timeSinceLastFire += Time.deltaTime;

        if (movingRight) {
            // Debug.Log("Moving Right");
            //Move right
            transform.Translate(new Vector2(movementSpeed, 0f));

            //Revisar si llega al límite superior en X permitido
            // if (transform.position.x >= maxPositionX) {
            if (pos.x >= maxPositionX) {
                //Ahora se debe mover a la izquierda
                movingRight = false;
            }
        } else {
            // Debug.Log("Moving Left");
            //Move left
            transform.Translate(new Vector2(-movementSpeed, 0f));

            //Revisar si llega al límite inferior en X permitido
            // if (transform.position.x <= minPositionX) {
            if (pos.x <= minPositionX) {
                //Ahora se debe mover a la derecha
                movingRight = true;
            }
        }

        if (timeSinceLastFire >= fireDelay && projectilesFired < onFireProjectileCount) {
            // Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            
            Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            projectile.GetComponent<Projectile>().damageableTargetTag = "Player";

            //Instantiate(farmingPlot, farmPosition,  Quaternion.Euler(Vector3(45, 0, 0)));

            projectilesFired++;

            if (projectilesFired >= onFireProjectileCount) {
                timeSinceLastFire = 0f;
                projectilesFired = 0;
            }
        }
    }
}

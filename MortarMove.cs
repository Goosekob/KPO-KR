using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera sceneCamera;
    private Vector2 mousePosition;
    public GameObject Bullet;
    public GameObject Enemy;
    public Transform FirePoint;
    public float FireForce;
    public float FireTime;
    public float _FireTime = 0.5f;
    public GameObject GamePause;
    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public bool dead;

    public void Fire()
    {
        if (FireForce > 0)
        {
            GameObject projectile = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        }
        else
        {
            FireForce = 0;
            GameObject projectile = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(FirePoint.right * FireForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dead = Enemy.GetComponent<MoveEnemy>().isDead;
        ProcessInput();
        if (dead == true)
        {
            spriteRenderer.sprite = sprite2;
        }
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (FireTime > 0)
        {
            FireTime -= Time.deltaTime;
            if (FireTime <= 0) FireTime = 0;
        }

        if (GamePause.activeInHierarchy == false)
            if (Input.GetMouseButtonDown(0) & FireTime <= 0 & dead == false)
            {
                FireTime = _FireTime;
                Fire();
            }

        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Clamp(Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg, 5f, 85f);
        rb.rotation = aimAngle;
    }

}

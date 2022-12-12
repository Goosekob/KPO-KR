using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveEnemy : MonoBehaviour
{
    public GameObject Mortar;
    public Rigidbody2D rb;
    public float speed;
    public Manager GameManager;
    public bool isDead;
    public GameObject Enemy;

    void Update()
    {
        speed = Enemy.GetComponent<EnemyDestroy>().Speed;
        if (SceneManager.GetActiveScene().name != "Main menu" && Enemy.GetComponent<EnemyDestroy>().destroy == 0 && isDead == false)
        {
            if (speed > 0)
                transform.position += new Vector3(-1.0f * speed * Time.deltaTime, 0, 0);
            else
            {
                transform.position += new Vector3(0, 0, 0);
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                break;
            case "WeaponMortar":
                if (!isDead)
                {
                    isDead = true;
                    Invoke("Over", 0.3f);
                }
                break;
        } 
    }
    
    public void Over()
    {
        GameManager.GameOver();
        Destroy(Mortar);
        Destroy(gameObject);
    }
    
}

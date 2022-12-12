using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
        }
    }
}

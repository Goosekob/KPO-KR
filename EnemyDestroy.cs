using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject Enemy;
    public int count;
    public TextMeshProUGUI countText;
    public Sprite sprite1; 
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;
    public int destroy = 0;
    public float Speed = 0f;
    public GameObject PS1;
    public GameObject PS2;

    void Start()
    {
         count = 0;
         countText.text = "Score: " + count.ToString();
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (destroy == 0)
        {
            switch (other.gameObject.tag)
            {
                case "Wall":
                    break;
                case "Bullet":
                    destroy = 1;
                    Particle1();
                    Invoke("Particle2", 0.1f);
                    spriteRenderer.sprite = sprite2;
                    Invoke("DestroyEnemy", 0.3f);
                    Invoke("SpawnEnemy", 0.7f);
                    break;
            }
        }
    }

    public void Particle1()
    {
        Instantiate(PS1, transform.position, Quaternion.identity);
    }

    public void Particle2()
    {
        Instantiate(PS2, transform.position, Quaternion.identity);
    }

    public void ScoreCount()
    {
        count++;
        countText.text = "Score: " + count.ToString();
    }

    public void DestroyEnemy()
    {
        ScoreCount();
        gameObject.SetActive(false);
        if (Speed < 2.0f)
            Instantiate(Enemy, gameObject.transform.position = new Vector2(Random.Range(-0.5f, 8.5f), -1.1f), Quaternion.identity);
        else
            Instantiate(Enemy, gameObject.transform.position = new Vector2(Random.Range(0f, 8.5f), -1.1f), Quaternion.identity);

    }

    public void SpawnEnemy()
    {
        destroy = 0;
        Speed = Speed + (-0.05f);
        spriteRenderer.sprite = sprite1;
        gameObject.SetActive(true);
    }
}

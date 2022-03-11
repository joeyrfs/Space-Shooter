using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    private void Start()
    {
        correctLayer = gameObject.layer;

        // NOTA1 Isse apenas pega o render do objeto pai.
        // Não funciona para os filhos. Ex.: "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite render");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger!!!");
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
    }

    private void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
            
            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;

                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if(spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}

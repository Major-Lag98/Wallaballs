using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    public float speed = 1;

    float invincibleTimer = 3.0f;
    float timeInvincible = 3.0f;

    bool isInvincible = false;

    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;

    BallSpawner ballSpawner;

    public PolygonCollider2D pc3hp;
    public PolygonCollider2D pc2hp;
    public PolygonCollider2D pc1hp;

    public Sprite twohp;
    public Sprite onehp;

    int maxHealth = 3;
    int currentHealth;




    void Start()
    {
        //set health && get ridgidbody ready for movement
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject gameController = GameObject.Find("CanvasGameController");
        ballSpawner = gameController.GetComponent<BallSpawner>();
        pc3hp.enabled = true;
        currentHealth = maxHealth;
    }


    void Update()
    {
        //movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical); //vector2 for new movement
        Vector2 position = rigidbody2d.position;
        position = position + move * speed;
        rigidbody2d.MovePosition(position);

        //rotation
        float rotation = Input.GetAxis("Rotation");
        rigidbody2d.AddTorque(rotation); //Possibly better if i use transform, idk what i like yet

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (currentHealth > 0)
            {
                blink();
            }
            
            
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
                if (ballSpawner.alive == true)
                {
                    spriteRenderer.enabled = true;
                }
                else spriteRenderer.enabled = false;
                
            }
        }

    }
    
    public void ChangeHealth(int amount)
    {
        if (amount < 0) //Take Damage
        {
            
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            invincibleTimer = timeInvincible;


        }
        else if (amount > 0)//heal
        {
            //Debug.Log("Pretend this is a heal animation");
            //healEffect.Play();
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        

        //change sprite based on health
        if (currentHealth == 2)
        {

            spriteRenderer.sprite = twohp;
            pc3hp.enabled = false;
            pc2hp.enabled = true;
        }
        if (currentHealth == 1)
        {
            spriteRenderer.sprite = onehp;
            pc2hp.enabled = false;
            pc1hp.enabled = true;
        }
        if (currentHealth <= 0)
        {
            spriteRenderer.enabled = false;
            pc1hp.enabled = false;
            ballSpawner.alive = false;
        }
        Debug.Log(currentHealth + "/" + maxHealth);

    }


    void blink() //for invincible frames
    {
        
            if (Time.fixedTime % .3 < .2)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.enabled = true;
            }
        
    }
}

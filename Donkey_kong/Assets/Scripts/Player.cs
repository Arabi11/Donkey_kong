using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private Sprite[] runSprites;
     [SerializeField] public float moveSpeed = 5f;


    




    [SerializeField] public float jumpStrength = 4f;

    private SpriteRenderer spriteRenderer;


    private int spriteIndex;

    private new Rigidbody2D rigidbody;
    private new Collider2D collider;

    private Collider2D[] overlaps = new Collider2D[4];
    public Vector2 direction;

    public bool grounded;

    private bool giant = false;

    
    

    public PlayerIdle playerIdle = new PlayerIdle();

     public PlayerRunning playerRunning = new PlayerRunning();

      public PlayerJumping playerJumping = new PlayerJumping();

      public IPlayerState currentState;

    
    






    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        instance = this;

    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(AnimateSprite), 1f / 12f, 1f / 12f);
        currentState = playerIdle;



    }



    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Update()
    {
        CheckCollision();

       currentState =currentState.Tick(this);
    }



    private void CheckCollision()
    {
        grounded = false;


        Vector3 size = collider.bounds.size;
        size.y += 0.1f;
        size.x /= 2f;

        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0, overlaps);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = overlaps[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Ground"))
            {
                // Only set as grounded if the platform is below the player
                grounded = hit.transform.position.y < (transform.position.y - 0.5f);


                // Turn off collision on platforms the player is not grounded to
                Physics2D.IgnoreCollision(overlaps[i], collider, !grounded);
            }



        }
    }

    
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * Time.fixedDeltaTime);
    }

    private void AnimateSprite()
    {
        if (direction.x == 0f)
        {
            spriteRenderer.sprite = runSprites[0];
        }
        else if (direction.x != 0f)
        {
            spriteIndex++;

            if (spriteIndex >= runSprites.Length)
            {
                spriteIndex = 0;
            }

            spriteRenderer.sprite = runSprites[spriteIndex];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !giant)
        {
            FindObjectOfType<GameManager>().LevelFailed();

        }

        else if (collision.gameObject.CompareTag("Obstacle") && giant)
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.AddPoint(500);
        }





    }



    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            if (collider.GetType() == typeof(CapsuleCollider2D))
            {
                if (direction.x > collider.transform.position.x)
                {
                    ScoreManager.instance.AddPoint(50);
                }
                else
                {
                    unlockAchievement("JumpMan");
                   
                    ScoreManager.instance.AddPoint(150);
                }




            }
            else if (direction.x > collider.transform.position.x)
            {
                ScoreManager.instance.AddPoint(10);

            }

        }
    }
     IEnumerator jumpbackAch(){

       unlockAchievement("JumpMan");
         yield return new WaitForSeconds(10f);
     
    

   }

    

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public void setMoveSpeed(float x)
    {
        moveSpeed = x;
    }

    public void setGiant(bool x)
    {
        giant = x;
    }
    public void unlockAchievement(string ID)
    {

        AchievementService achServ = FindObjectOfType<AchievementService>();

        if (achServ)
        {
            achServ.GetComponent<AchievementService>().unlockAchievement(ID);
        }
    }

    

   

  
    
   

    

}




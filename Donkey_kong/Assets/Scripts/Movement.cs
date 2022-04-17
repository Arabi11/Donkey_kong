using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    [SerializeField] private Sprite[] runSprites;
    [SerializeField] private  float moveSpeed = 6f;


    
    

    [SerializeField] private float jumpStrength = 4f;
    
    private SpriteRenderer spriteRenderer;
    
   
    private int spriteIndex;

    private new Rigidbody2D rigidbody;
    private new Collider2D collider;

    private Collider2D[] overlaps = new Collider2D[4];
    private Vector2 direction;

    private bool grounded;

  
  

    
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        
        instance = this;
    
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(AnimateSprite), 1f/12f, 1f/12f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Update()
    {
        CheckCollision();
        SetDirection();
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

    

    private void SetDirection()
    {
        
         if (grounded && Input.GetButtonDown("Jump")) {
            direction = Vector2.up * jumpStrength;
        } else {
            direction += Physics2D.gravity * Time.deltaTime*3;
        }

        direction.x = Input.GetAxis("Horizontal") * moveSpeed;

        // Prevent gravity from building up infinitely
        if (grounded) {
            direction.y = Mathf.Max(direction.y, -1f);
        }

        if (direction.x > 0f) {
            transform.eulerAngles = Vector3.zero;
        } else if (direction.x < 0f) {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
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

            if (spriteIndex >= runSprites.Length) {
                spriteIndex = 0;
            }

            spriteRenderer.sprite = runSprites[spriteIndex];
        }
    }

      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().LevelFailed();
            
        }
        
    }

private void OnTriggerExit2D(Collider2D collider){
     if(collider.gameObject.CompareTag("Obstacle")){
        if(direction.y > collider.transform.position.y){
            if(direction.x > collider.transform.position.x){
                ScoreManager.instance.AddPoint(50);
            }
            else{
                ScoreManager.instance.AddPoint(150);
            }
          
            
            
            
        }
        else if(direction.x > collider.transform.position.x) {
           ScoreManager.instance.AddPoint(10);
            
        }
        
     }
}

   
}

using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 direction;
    public float moveSpeed = 1f;
    public float jumpStrength =1f;
    private new Collider2D collider;


    private bool grounded;
    private Collider2D [] results;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        results = new Collider2D[4];
        
    }
    public void CheckCollision(){

        grounded = false;
        Vector2 size = collider.bounds.size;
        size.y += 0.1f;
        size.x /= 2f;
        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, results);

        for(int i= 0; i < amount; i++){
           
           GameObject hit  = results[i].gameObject;

             if (hit.layer == LayerMask.NameToLayer("Ground")){
                 grounded = hit.transform.position.y < (transform.position.y - 0.5f);

                 Physics2D.IgnoreCollision(collider, results[i], !grounded);
            }
        }
    }


    private void Update()
    {

        CheckCollision();
        if (grounded && Input.GetButtonDown("Jump")){
           direction = Vector2.up * jumpStrength;
        }
        else{
            direction += Physics2D.gravity * Time.deltaTime;
        }

        direction.x = Input.GetAxis("Horizontal") * moveSpeed;
        if(grounded){
            direction.y = Mathf.Max(direction.y,-1f);
        }
        

        if (direction.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        } else if (direction.x < 0f){
           transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }


    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * Time.fixedDeltaTime);
    }
}

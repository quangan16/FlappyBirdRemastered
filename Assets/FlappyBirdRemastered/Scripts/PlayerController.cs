using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D playerRb;
   private Collider2D playerCollider;
   private Animator playerAnimator;
   
   [SerializeField] public bool isAlive;
   [SerializeField] private float flyForce;
   private Vector3 velocity;
   [SerializeField] private bool onGround;

   private float rotateSpeed;
   private Quaternion rotateDownBound;
   private Quaternion rotateUpBound;
   

   public void OnEnable()
   {
      GameManager.Instance.OnStartPlaying += OnStartPlaying;
   }
   public void Start()
   {
      Init();

   }

   public void Init()
   {
      
      // playerRb = GetComponent<Rigidbody2D>();
      playerCollider = GetComponent<Collider2D>();
      playerAnimator = GetComponent<Animator>();
      GameManager.Instance.Continue();
      // playerRb.gravityScale = 0.0f;
      isAlive = true;
      flyForce = 20f;
      onGround = false;
      rotateSpeed = 2.2f;
      rotateDownBound = Quaternion.Euler(0, 0, -90.0f);
      rotateUpBound = Quaternion.Euler(0, 0, 60.0f);
   }

  
   public void Update()
   {
      WaitingMode();
      FlyUp();
      Rotate();
      ApplyGravity();
      CheckGrounded();

   }

   public void WaitingMode()
   {
      if (GameManager.Instance.isPlaying == false)
      {
         float positionY = 3 * Mathf.Sin(Mathf.Repeat(Time.time, 360) * 100 * Mathf.Deg2Rad);
         transform.position = new Vector2(transform.position.x, positionY);
      }
     
   }

   public void FixedUpdate()
   {
      CheckUpBounding();
   }

   public void OnStartPlaying()
   {

      playerAnimator.SetBool("isPlaying", true);

   }

   public void FlyUp()
   {
      if (GameManager.Instance.isPlaying)
      {
         if (isAlive)
         {
            if (Input.GetMouseButtonDown(0))
            {
               SoundManager.Instance.PlayOnce(SoundManager.flapwing);
               transform.rotation = rotateUpBound;
               playerAnimator.CrossFade("OnFly", 0, -1, 0);
               velocity = Vector3.up * flyForce;

            }
         }
      }

   }

   public void Rotate()
   {
      if (GameManager.Instance.isPlaying && isAlive)
      {
         transform.rotation = Quaternion.Lerp(transform.rotation, rotateDownBound, Time.unscaledDeltaTime * rotateSpeed);
      }
      
   }

   public void CheckGrounded()
   {
      RaycastHit2D[] results = new RaycastHit2D[1];
      Physics2D.RaycastNonAlloc((Vector2)transform.position, Vector2.down, results,Mathf.Infinity, 1<<6);
      if (results[0].distance < 1.1f && !onGround)
      {
         onGround = true;
         Die();
      }

   }

   public void CheckUpBounding()
   {
      if (transform.position.y >= Camera.main.orthographicSize - 0.5f)
      {
         transform.position = new Vector2(transform.position.x, Camera.main.orthographicSize - 0.5f);
      }
   }
   public void ApplyGravity()
   {
      if (GameManager.Instance.isPlaying)
      {
         if (onGround == false)
         {
            velocity += Vector3.down * (GameManager.Instance.gravityMagnitude * Time.unscaledDeltaTime);
            
         }

         else
         {
            velocity.y = 0.0f;
         }

         transform.position += velocity * Time.unscaledDeltaTime;
      }
      
   }

   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Obstacle"))
      {
         Die();
      }

      if (other.gameObject.CompareTag("Score"))
      {
         GameManager.Instance.GetScore(1);
      }
   }

   // public void OnCollisionEnter2D(Collision2D other)
   // {
   //    if (other.gameObject.CompareTag("Obstacle"))
   //    {
   //       isAlive = false;
   //       GameManager.Instance.PlayFlashEfx();
   //       print("stupid");
   //    }
   // }

   public void Die()
   {
      if (isAlive)
      {
         
         isAlive = false;
         SoundManager.Instance.PlayOnce(SoundManager.hit);
         DOVirtual.DelayedCall(0.4f, () =>
         {
            SoundManager.Instance.PlayOnce(SoundManager.die);
         });
         GameManager.Instance.PlayFlashEfx();
         GameManager.Instance.Pause();
         GameManager.Instance.GameOver();
      }
      
   }

   
}

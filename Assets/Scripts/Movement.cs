using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

  public StudioEventEmitter emitter,jumpEmmiter,groundEmmiter;

  public bool onWall;
   [SerializeField] private Vector2 input;
   [SerializeField] private bool jump;


   [SerializeField] private bool isGrounded;

   public float jumpForce;

    public Rigidbody rb;

    public Vector2 velocity;

    public float speed ;

    public bool isPaused;

    public GameObject pausa;
   
   private void Move( Vector2 input)
   {
    this.input = input;

    if( input.x >= 0|| input.x <=0)
    {

         emitter.Play();

    }else if(input.x == 0)
    {
       emitter.Stop();

    }

   
   
    

   }

   
   

   private void Jump(bool Jump)
   {

    this.jump = Jump;

   }

   private void Pause()
   {
    if(!isPaused)
    {
      isPaused = true;
      pausa.SetActive(true);
    }
    else if(isPaused)
    {

      isPaused = false;
      pausa.SetActive(false);

    }
   }

    private void OnEnable() 
   {

    InputManager.OnplayerMovement += Move;

    InputManager.OnJump += Jump;

    InputManager.OnPause += Pause;

    
   }

   private void OnDisable()
   {
    InputManager.OnplayerMovement -= Move;
    InputManager.OnJump -= Jump;
    InputManager.OnPause -= Pause; 
   }


    private void FixedUpdate() 
   {
     Vector3 velocity = new Vector3(input.x, 0, 0);
     rb.MovePosition(rb.position +(velocity * speed * Time.fixedDeltaTime));

     if(jump && isGrounded)
     {
      jumpEmmiter.Play();
      rb.useGravity = false;
      rb.AddForce(new Vector3(0,1,0) * jumpForce );
     }
     else  
     {
      jumpEmmiter.Stop();
      rb.useGravity = true;
      jumpEmmiter.Stop();
      return;
     }
   }


   private void OnCollisionEnter(Collision other) 
   {

    if(other.collider.CompareTag("Enemy"))
    {
      SceneManager.LoadScene("SampleScene");
    }

    if(other.collider.CompareTag ("Ground"))
    {
      isGrounded = true;
      groundEmmiter.Play();
    }
    
   }

   private void OnCollisionExit(Collision other)
    {
    isGrounded = false;
    groundEmmiter.Stop();
   }




  
}

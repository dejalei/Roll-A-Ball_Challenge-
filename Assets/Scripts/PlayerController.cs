using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour, RollABallControls.IPlayerActions
{

    public float speed;
    public RollABallControls controls;
    public Vector2 motion;
    public Text countText;
    public Text winText;
    
    public Text livesText;
    public Text loseText;
    private Rigidbody rb;
    private int count;
    private int lives;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        SetCountText ();
        winText.text = "";
        loseText.text= "";
        
        
    }

    public void OnEnable()
    {
        if (controls == null)
        {
            controls = new RollABallControls();

            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }
    public void  OnMove(InputAction.CallbackContext context)
    {
        motion = context.ReadValue<Vector2>();
    }
    void FixedUpdate ()
    {
        Vector3 movement = new Vector3 (motion.x, 0.0f, motion.y);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
{
  if (other.gameObject.CompareTag("Pick Up"))
  {
    other.gameObject.SetActive(false);
    count = count + 1; 
     // I added this code to track the score and count separately.
    SetCountText();
  } else if (other.gameObject.CompareTag("Enemy")) {
    other.gameObject.SetActive(false);

    lives = lives -1; // this removes 1 from the score
    SetCountText();
  }
}
    void SetCountText ()
    {
        
        countText.text = "Count: " + count.ToString ();
        livesText.text = "Lives: " + lives.ToString ();
        if (count == 12)
        {
         transform.position = new Vector3(100.0f, transform.position.y, 100.0f); 
        }
        {
        if (count == 20)
         winText.text = "You Win!";
        
    
        else if (lives == 0)
        {
        lives = 0;
         Destroy(gameObject);
        loseText.text = "You Lose!";
        }
        
        }
    }
}
    
 
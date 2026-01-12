using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMoveScript : MonoBehaviour
{
    public GameObject mainPlanet;
    public float moveSpeed = 0.0f;
    public float gravityForce = 0.0f;
    public float jumpSpeedUp = 0.0f;
    public bool upTriggerBool = false;
    public bool downTriggerBool = false;
    public bool noGravityTriggerBool = false;
    public bool playerJumping = false;
    public bool nearGravityUpBool = false;
    public bool nearGravityDownBool = false;
    public bool suparSafeBool = false;


    private Rigidbody2D rb;
    private InputSystem_Actions action;
    private Vector2 worldJumpingSpeed;
    private Vector2 localJumpingSpeed;
    private float moveAngleSpeed;
    private float gravity = 0.0f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        action=new InputSystem_Actions();
    }

    private void OnEnable()
    {
        action.Player.Enable();
    }

    private void OnDisable()
    {
        action.Player.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        GmMg.instance.decision = action.Player.Jump.triggered;

        if (GmMg.instance.decision && !playerJumping)
        {
            playerJumping = true;
            moveSpeed += jumpSpeedUp;
        }

        if (playerJumping)
        {
            PlayerJump();
        }
        else
        {
            PlayerRevolution();
        }
        

    }

    private void PlayerRevolution()
    {
        rb.linearVelocity = Vector2.zero;
        if (mainPlanet == null) return;
        moveAngleSpeed = (moveSpeed) / (Vector2.Distance(transform.position, mainPlanet.transform.position));
        transform.RotateAround(mainPlanet.transform.position, Vector3.forward, -Time.deltaTime * moveAngleSpeed * Mathf.Rad2Deg);
        //地面との向きを指定
        transform.up = (transform.position - mainPlanet.transform.position).normalized;

    }

    private void PlayerJump()
    {
        if (nearGravityUpBool)
        {
            gravity = moveSpeed;
        }
        else if (nearGravityDownBool)
        {
            gravity = -moveSpeed;
        }
        else if (upTriggerBool)
        {
            gravity = gravityForce;
        }
        else if (downTriggerBool)
        {
            gravity = -gravityForce;
        }
        else
        {
            gravity = 0.0f;
        }

        worldJumpingSpeed = new Vector2(moveSpeed, gravity);
        localJumpingSpeed = transform.TransformDirection(worldJumpingSpeed);

        rb.linearVelocity = localJumpingSpeed;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面に着地
        if (collision.gameObject.tag == "Planet" && collision.gameObject != mainPlanet)
        {
            playerJumping = false;
            mainPlanet = collision.gameObject;
            upTriggerBool = false;
            downTriggerBool = false;
            noGravityTriggerBool = false;
            nearGravityUpBool = false;
            nearGravityDownBool = false;
            suparSafeBool = false;

        }
    }



}

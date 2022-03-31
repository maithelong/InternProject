using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementInputDirection;
    private float turnTimer;
    private float wallJumpTimer;
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float moveSpeed; 
    public float jumpForce = 10.0f;
    public float wallCheckDistance;
    public float wallSLideSpeed;
    public float groundCheckRadius;
    public float movementForceInAir;
    public float airDragMultiplier=0.95f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float wallHopForce;
    public float wallJumpForce;
    private float jumpTimer;
    public float jumpTimerSet=0.15f;
    public float turnTimerSet=0.1f;
    public float wallJumpTimerSet=0.5f;
    public float ledgeClimbXOffset1 = 0f;
    public float ledgeClimbYOffset1 = 0f;
    public float ledgeClimbXOffset2 = 0f;
    public float ledgeClimbYOffset2 = 0f;

    private bool isFacingRight=false ;
    private bool checkWallSliding;
    private bool isWalking;
    private bool isGrounded;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isTouchingWall;
    private bool isAttemptingToJump;
    private bool checkJumpMultiplier;
    private bool canMove;
    private bool canFlip;
    private bool hasWallJump;
    private bool isTouchingLedge;
    private bool canClimbLedge = false;
    private bool ledgeDetected;
    
    private Animator anim;
    
    public Transform groundCheck;
    public Transform wallCheck;
    public Transform ledgeCheck;
    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirecion;

    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;
    private Vector2 ledgePos2;
    
    public LayerMask whatIsGround;
    
    public int amountOfJumps=1;
    private int amountOfJumpsLeft;
    public int facingDirection=1;
    public int lastWallJumpDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //amountOfJumpsLeft = amountOfJumps;
        /*wallHopDirection.Normalize();
        wallJumpDirecion.Normalize();*/
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
       /* checkMovmentDirection();
        updateAnimation();
        //checkIfCanJump();
       // checkIfWallSLiding();
        checkJump();*/
        //checkLedge();
    }
    private void FixedUpdate()
    {
        applyMovement();
        //checkSurrounding();
    }
    void  checkInput()
    {
        movementInputDirection = Input.GetAxis("Horizontal");
        /*if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded||amountOfJumpsLeft>0&&isTouchingWall)
            {
                normalJump();
            }
            else {
                jumpTimer = jumpTimerSet;
                isAttemptingToJump = true;

}    
        }
        if(Input.GetButtonDown("Horizontal")&&isTouchingWall)
        {
            if(!isGrounded&&movementInputDirection!=facingDirection)
            {
                canFlip = false;
                canMove = false;
                turnTimer = turnTimerSet;
            }    
        } 
        if(turnTimer>=0)
        {
            turnTimer -= Time.deltaTime;
            if(turnTimer<=0)
            {

                canMove = true;
                canFlip = true;
            }    
        }    */
        /*if (checkJumpMultiplier&&!Input.GetButton("Jump"))
        {
            checkJumpMultiplier = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
        }*/
    }
    private void checkIfCanJump()
    {
        if ((isGrounded && rb.velocity.y <= 0.01f))
        {
            amountOfJumpsLeft = amountOfJumps;
        }
        if(isTouchingWall)
        {
            canWallJump = true;
        }    
        if (amountOfJumpsLeft <= 0)
            canNormalJump = false;
        else
            canNormalJump = true;
         }
    private void  checkIfWallSLiding()
    {
        if(!isGrounded&&isTouchingWall&&movementInputDirection==facingDirection&&rb.velocity.y<0&&!canClimbLedge)
        {
            checkWallSliding = true;
        }
        else
        {
            checkWallSliding = false;
        }  
    }    
    private void checkJump()
    {
        if(jumpTimer>0)
        {
            if(!isGrounded&&movementInputDirection!=0&&movementInputDirection!= facingDirection&&isTouchingWall)
            {
                wallJump();
            } else if(isGrounded)
            {
                normalJump();
            }    
        }
        if(isAttemptingToJump)
        {
            jumpTimer -= Time.deltaTime;
        }
        if(wallJumpTimer>0)
        {
            if(hasWallJump && (movementInputDirection==-lastWallJumpDirection))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                hasWallJump = false;
            }    else if(wallJumpTimer<0)
            {
                hasWallJump = false;
            }
            else
            {
                wallJumpTimer -= Time.deltaTime;
            }
        }    
    } 
    private void normalJump()
    {

        if (canNormalJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;

        }
    }  
    
    private void wallJump()
    {
         if (canWallJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            checkWallSliding = false;
            amountOfJumpsLeft = amountOfJumps;

            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallHopForce * wallHopDirection.x * -facingDirection, wallHopForce * wallHopDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
            turnTimer = 0;
            canFlip = true;
            canMove = true;
            hasWallJump = true;
            wallJumpTimer = wallJumpTimerSet;
            lastWallJumpDirection = -facingDirection;

        }
        else if ((checkWallSliding || isTouchingWall) && movementInputDirection != 0 && canWallJump)
        {
            checkWallSliding = false;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirecion.x * movementInputDirection, wallJumpForce * wallJumpDirecion.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
            turnTimer = 0;
            canFlip = true;
            canMove = true;
        }
    }    
    void applyMovement()
    {
        /*if (isGrounded)

        { rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y); }
        else if(!isGrounded && !checkWallSliding && movementInputDirection!=0){
            Vector2 forceToAdd = new Vector2(movementForceInAir * movementInputDirection, 0);
            rb.AddForce(forceToAdd);
            if(Mathf.Abs(rb.velocity.x)>moveSpeed)
            {
                rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
            }    
        }
        else if (!isGrounded && !checkWallSliding && movementInputDirection == 0&&canMove)
        {
            rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
        }
            if (checkWallSliding)
        {
            if(rb.velocity.y<-wallSLideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSLideSpeed);
            }    
        }    */
        rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
    }
    private void checkMovmentDirection()
    {
        if (isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }else if(!isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }  
        if(rb.velocity.x!=0)
        {
            isWalking = true;
        }
        else
        {
            isWalking= false;
        }    
            
    } 
    private void updateAnimation()
    {
        anim.SetBool("iswalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity",rb.velocity.y);
        anim.SetBool("wallsliding", checkWallSliding);
    }    
    private void Flip()
    {
        if (!checkWallSliding&&canFlip)
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.00f, 180.0f, 0.0f);
        }
    }
    private void checkLedge()
    {
        if(ledgeDetected&&!canClimbLedge)
        {
            canClimbLedge = true;
        }    
        if(isFacingRight)
        {
            ledgePos1 = new Vector2(Mathf.Floor(ledgePosBot.x + wallCheckDistance) - ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y ) + ledgeClimbXOffset1);
            ledgePos2= new Vector2(Mathf.Floor(ledgePosBot.x + wallCheckDistance) + ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y ) + ledgeClimbXOffset2);
        }
        else
        {
            ledgePos1 = new Vector2(Mathf.Ceil(ledgePosBot.x - wallCheckDistance) + ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y ) + ledgeClimbXOffset1);
            ledgePos2 = new Vector2(Mathf.Ceil(ledgePosBot.x - wallCheckDistance) - ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y ) - ledgeClimbXOffset2);

        }
        canMove = false;
        canFlip = false;
        if(canClimbLedge)
        {
            transform.position = ledgePos1;
        }
        anim.SetBool("canClimbLedge", canClimbLedge);
    }  
    public void finishLedgeClimb()
    {
        canClimbLedge = false;
        transform.position = ledgePos2;
        canFlip = true;
        canMove = true;
        ledgeDetected = false;
        anim.SetBool("canClimbLedge", canClimbLedge);

    }
    private void checkSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        isTouchingLedge = Physics2D.Raycast(ledgeCheck.position, transform.right, wallCheckDistance, whatIsGround);
        if(isTouchingWall&&!isTouchingLedge&&!ledgeDetected)
        {
            ledgeDetected = true;
            ledgePosBot = wallCheck.position;
        }    
    }    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position,new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(ledgeCheck.position,new Vector3(ledgeCheck.position.x + wallCheckDistance, ledgeCheck.position.y, ledgeCheck.position.z));
    }
}

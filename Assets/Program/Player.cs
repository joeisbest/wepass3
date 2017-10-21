using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



	[Range(0,150)]
	public float speedX;

	float speedY;
	private Animator anim;


   Rigidbody2D playerRigidbody2D;

    /*[Header("目前的水平速度")]
    public float speedX;

    [Header("目前的水平方向")]
    public float horizontalDiretion;  //-1~1

    const string HORIZONTAL = "Horizontal";

    [Header("目前的水平推力")]
    [Range(0,150)]
    public float xForce;

    //目前的垂直速度
    float speedY;

    [Header("最大水平速度")]
     public float maxspeedX;
    public void Contorlspeed()
    {
        speedX = playerRigidbody2D.velocity.x;
        speedY = playerRigidbody2D.velocity.y;

        float newspeedX = Mathf.Clamp(speedX, -maxspeedX, maxspeedX);

        playerRigidbody2D.velocity = new Vector2(newspeedX, speedY);
     }*/



    [Header("重質向上推力")]
    public float yForce;
    public bool Jumpkey {
        get {
            return Input.GetKeyDown(KeyCode.Space);
        }

    }
    void TryJump()
    {
        if (IsGround && Jumpkey)
        {
            playerRigidbody2D.AddForce(Vector2.up * yForce);
			 //anim
        }
    }
    [Header("感應地板的距離")]
    [Range(0, 0.5f)]
    public float distance;
    [Header("感應地板的射線")]
    public Transform groundCheck;
    [Header("地面圖層")]
    public LayerMask groundLayer;

    public bool grounded;
    bool IsGround {
        get{
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);

            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);

            return grounded;
        }
    }



    void Start(){
        playerRigidbody2D = GetComponent<Rigidbody2D>();   
		anim=GetComponentInChildren<Animator>();

    }


    void Movement(){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetBool ("run", true);
			transform.rotation = Quaternion.Euler (0, 180, 0);
			transform.Translate (Vector2.left * speedX * Time.deltaTime, Space.World);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			anim.SetBool ("run", true);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.Translate (-Vector2.left * speedX * Time.deltaTime, Space.World);
		}
		else {
			anim.SetBool ("run", false);
		}
        /*horizontalDiretion = Input.GetAxis(HORIZONTAL);
        playerRigidbody2D.AddForce(new Vector3(xForce * horizontalDiretion, 0));*/


    }

	
	// Update is called once per frame
	void Update () {
        Movement();
       // Contorlspeed();
        TryJump();
		if (grounded) {
			anim.SetBool ("isjump", false);
		} else {
			anim.SetBool("isjump",true); 
		}
       // speedX = playerRigidbody2D.velocity.x;
	  //動畫用
		/*if(Input.(KeyCode.LeftArrow)&& Input.GetKeyUp(KeyCode.RightArrow)){
			anim.SetBool ("run", false);
		}*/

    }
}

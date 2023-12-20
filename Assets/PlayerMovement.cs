using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 15f;
    [SerializeField]Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start(){
        rb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector3(rb.velocity.x, movementSpeed, rb.velocity.z);
        }
        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene( ).buildIndex + 0);
        }
    }
    
    bool IsGrounded(){
        return Physics.CheckSphere(groundCheck.position, .1f, ground );
    }

}

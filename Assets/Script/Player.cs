using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform groundChecktransform;

    public LayerMask playerMask;

    private bool jumpwaspressed;

    private float horizontalInput;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetKeyDown(KeyCode.Space)){
            jumpwaspressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
         rigidbody.velocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().velocity.y, 0);
         
        if(Physics.OverlapSphere(groundChecktransform.position, 0.01f, playerMask).Length == 0)
        {
            return;
        }
        if(jumpwaspressed)
        {
            rigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);

             jumpwaspressed = false;
        }

       
    }
}

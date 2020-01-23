using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject myHand;
    
    Vector3 ballPos;
    Collider ballCol;
    Rigidbody ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.transform.position;
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void grabBall()
    {
            //ballCol.isTrigger = true;
            ball.transform.SetParent(myHand.transform);
            ball.transform.localPosition = new Vector3(0.06f, -1.01f, 1.47f);
            ballRb.useGravity = false;
            ballRb.constraints = RigidbodyConstraints.FreezeAll;
            ballRb.velocity = Vector3.zero;
        
    }

    public void throwBall()
    {
        //this.GetComponent<PlayerGrab>().enabled = false;
        ball.transform.SetParent(null);
        ballRb.useGravity = true;
        ballRb.AddForce(myHand.transform.forward * 1500);
        ballRb.constraints = RigidbodyConstraints.None;
        //ball.transform.localPosition = ballPos;
    }
}

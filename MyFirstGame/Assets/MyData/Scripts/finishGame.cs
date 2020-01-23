using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finishGame : MonoBehaviour
{

    public GameObject ball;
    public GameObject textPoint;
    Rigidbody ballRb;
    

    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
    }

    int puntos = 0;
    void OnTriggerEnter()
    {
        if (puntos == 3)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            puntos++;
            ballRb.velocity = Vector3.zero;
            ball.transform.localPosition = new Vector3(3.49f, 2.67f, -10.6f);
            
            textPoint.GetComponent<TextMesh>().text = "Puntos : " + puntos.ToString();
        }
        
        
    }
}

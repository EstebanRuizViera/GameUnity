using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime;
    public GameObject player;
    bool gvrStatus;
    float gvrTimer;
    public Camera camera;
    private int distanceOfRay = 400;
    private RaycastHit hit;
    

    bool hand = false;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out hit, distanceOfRay))
        {

            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("Teleport"))
            {
                hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("ball"))
            {
                if (!hand)
                {
                    hit.transform.gameObject.GetComponent<PlayerGrab>().grabBall();
                    hand = true;
                    gvrStatus = false;
                    gvrTimer = 0;
                    imgGaze.fillAmount = 0;
                }
                
            }
            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("wall"))
            {
                if (hand)
                {
                    Debug.Log("Llego");
                    hit.transform.gameObject.GetComponent<PlayerGrab>().throwBall();
                    hand = false;
                    gvrStatus = false;
                    gvrTimer = 0;
                    imgGaze.fillAmount = 0;
                }
            }

        }
    }

    public void GVROn()
    {
        gvrStatus = true;
        Debug.Log("Llego");
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}

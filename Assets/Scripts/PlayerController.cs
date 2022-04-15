using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody rbPlayer;
    GameObject focalPoint;
    Renderer rendererPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        rendererPlayer = GetComponent<Renderer>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbPlayer.AddForce(focalPoint.transform.forward * magnitude, ForceMode.Impulse);

        Debug.Log("forwardInput" + forwardInput);
        Debug.Log("magnitude" + magnitude);

        if(forwardInput > 0)
        {
            rendererPlayer.material.color = new Color(0.1f - forwardInput, 0.1f, 0.1f - forwardInput);
        }
        else
        {

            rendererPlayer.material.color = new Color(0.1f + forwardInput, 0.1f, 0.1f + forwardInput);
        }
    }
}

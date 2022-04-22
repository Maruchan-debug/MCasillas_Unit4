using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody rbPlayer;
    GameObject focalPoint;
    Renderer rendererPlayer;
    public float powerUpSpeed = 10.0f;
    public GameObject powerUpInd;

    bool hasPowerUp = false;

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
        rbPlayer.AddForce(focalPoint.transform.forward * magnitude, ForceMode.Force);

        Debug.Log("forwardInput" + forwardInput);
        Debug.Log("magnitude" + magnitude);

        if (forwardInput > 0)
        {
            rendererPlayer.material.color = new Color(0.1f - forwardInput, 0.1f, 0.1f - forwardInput);
        }
        else
        {
            rendererPlayer.material.color = new Color(0.1f + forwardInput, 0.1f, 0.1f + forwardInput);
        }

        powerUpInd.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            powerUpInd.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player has collided wiht" + collision.gameObject + "With PowerUp set to" + hasPowerUp);
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided wiht" + collision.gameObject + "With PowerUp set to" + hasPowerUp);
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDir = collision.gameObject.transform.position - transform.position;

            rbEnemy.AddForce(awayDir * powerUpSpeed, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpInd.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRb;
    public float forceAmount = 150;
    public float turnForceAmount = 300f;
    public int xRange = 20;
    public bool isControllable = true;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI levelCompleteText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControllable)
        {
            if (player.transform.position.x < -xRange)
            {
                player.transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (player.transform.position.x > xRange)
            {
                player.transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.W))
            {
                playerRb.AddForce(Vector3.forward * forceAmount * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerRb.AddForce(Vector3.right * turnForceAmount * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerRb.AddForce(Vector3.left * turnForceAmount * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerRb.AddForce(Vector3.back * forceAmount * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Finish")
        {
            isControllable = false;
            Debug.Log("We finished !");
            levelCompleteText.gameObject.SetActive(true);
            Invoke("LoadNextLevel", 3);
        }

        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("We hit enemy");
            gameOverText.gameObject.SetActive(true);
            isControllable = false;
            transform.position = new Vector3(0, 0, 0);
            Invoke("Restart", 3);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

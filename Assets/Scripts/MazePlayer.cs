using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazePlayer : MonoBehaviour
{
    public int keys = 0;
    public float speed = 4.0f;
    
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime , 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1, 1, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * Time.deltaTime , 0, 0);
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            
        }
        }
        if(collision.gameObject.tag == "Key")
        {
            keys++;
            Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
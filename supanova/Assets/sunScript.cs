using UnityEngine;
using System.Collections;

public class sunScript : MonoBehaviour
{
    public gameManager gameManager;
    public GameObject me;
    public float mySpeed;
    public bool direction;
	// Use this for initialization
	void Start ()
    {
        direction = true;
        me = this.gameObject;
        mySpeed = gameManager.sunSpeed;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(direction)
	        me.transform.Translate(Vector2.right *Time.smoothDeltaTime * mySpeed);
        else
            me.transform.Translate(Vector2.left * Time.smoothDeltaTime * mySpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      //  if (collision.tag == "Player")
           // Application.Quit();
    }
}

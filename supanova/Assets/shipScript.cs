using UnityEngine;
using System.Collections;

public class shipScript : MonoBehaviour
{
    public gameManager gameManager;
    public sunScript sunScript;
    private GameObject me;
    private float mySpeed;
   

    public float effectTimer = 0f;
    public bool largeRockOn = false;
    public bool smallRockOn = false;
    public bool bigBoostOn = false;
    public bool smallBoostOn = false;

    public bool isAlive = true;

	// Use this for initialization
	void Start ()
    {
        mySpeed = gameManager.shipSpeed;
        me = this.gameObject;
        me.GetComponent<Collider2D>().isTrigger = true;
        me.GetComponent<Collider2D>().enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            me.transform.position = (new Vector2(me.transform.position.x, Mathf.Clamp(mousePos.y, -4.5f, 4.5f) * mySpeed));
        }

        if (bigBoostOn)
        {
           // mySpeed = gameManager.shipSpeed * 2.5f;
            sunScript.direction = false;
            effectTimer -= Time.deltaTime;
           // me.GetComponent<Collider2D>().isTrigger = false;
            me.GetComponent<Collider2D>().enabled = false;
            sunScript.mySpeed = gameManager.sunSpeed * 1.5f;
        }

        else if (largeRockOn)
        {
            effectTimer -= Time.deltaTime;
         //   me.GetComponent<Collider2D>().isTrigger = false;
          //  me.GetComponent<Collider2D>().enabled = false;
            sunScript.mySpeed = gameManager.sunSpeed * 6;
        }           

        else if (smallBoostOn)
        {
          //  mySpeed = gameManager.shipSpeed * 2;
            sunScript.direction = false;
            effectTimer -= Time.deltaTime;
           // me.GetComponent<Collider2D>().isTrigger = false;
            me.GetComponent<Collider2D>().enabled = false;
            sunScript.mySpeed = gameManager.sunSpeed * 1.5f;
        }

        else if (smallRockOn)
        {
            effectTimer -= Time.deltaTime;
           // me.GetComponent<Collider2D>().isTrigger = false;
           // me.GetComponent<Collider2D>().enabled = false;
            sunScript.mySpeed = gameManager.sunSpeed * 3f;
        }

        else if (largeRockOn == false && smallRockOn == false && bigBoostOn == false && smallBoostOn == false)      
        {
            mySpeed = gameManager.shipSpeed;
            sunScript.direction = true;
            me.GetComponent<Collider2D>().isTrigger = true;
            me.GetComponent<Collider2D>().enabled = true;
            sunScript.mySpeed = gameManager.sunSpeed;
        }


        if (effectTimer <= 0)
        {
            largeRockOn = false;
            smallRockOn = false;
            bigBoostOn = false;
            smallBoostOn = false;
        }
            

    }

    public void largeRockEffect()
    {
        if (!largeRockOn)
        {
            // Debug.Log("Ouch");
            largeRockOn = true;
            effectTimer = 1f;
            // sunScript.mySpeed = sunScript.mySpeed * 2;
        }
    }

    public void smallRockEffect()
    {
        if (!smallRockOn)
        {
            smallRockOn = true;
            effectTimer = 1f;
        }
    }
    public void bigBoostEffect()
    {
        if (!bigBoostOn)
        {
            bigBoostOn = true;
            effectTimer = 3f;
        }
    }

    public void smallBoostEffect ()
    {
        if (!smallBoostOn)
        {
            smallBoostOn = true;
            effectTimer = 1.75f;
        }
    }

    void OnMouseDrag()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sun")
        {
            Debug.Log("Player Died");
            isAlive = false;

        }
    }

}

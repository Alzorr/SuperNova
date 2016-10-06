using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class distanceTracker : MonoBehaviour
{
    public Text tooFar;
    public Transform myPos;
    public Transform sunPerPos;
    public float distance;

    public GameObject GameOverPanel;
    public shipScript playerShip;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        distance = Vector2.Distance(myPos.position, sunPerPos.position);

        if (sunPerPos.position.x <= myPos.position.x)
        {
            tooFar.text = distance.ToString();
        }
        if (sunPerPos.position.x >= myPos.position.x)
        {
            tooFar.text = null;
        }

        if (!playerShip.isAlive)
        {
            GameOverPanel.SetActive(true);
        }
    }
}

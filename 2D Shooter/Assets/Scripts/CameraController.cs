using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Shooting shooting;
    public bool ads = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ads = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            ads = false;
        }
        if (ads)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            {
                transform.position = new Vector3(player.transform.position.x + shooting.InHand.GetComponent<WeaponStats>().adsdistance, player.transform.position.y, transform.position.y);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x - shooting.InHand.GetComponent<WeaponStats>().adsdistance, player.transform.position.y, transform.position.y);
            }
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.y);
        }
    }
}

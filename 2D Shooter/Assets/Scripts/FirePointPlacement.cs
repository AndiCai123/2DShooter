using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointPlacement : MonoBehaviour
{
    private float positionRatio = 0f;
    public GameObject origin;
    private float mousePosX = 0f;
    private float mousePosY = 0f;
    public float barrelLength = 0f;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        positionRatio = Mathf.Sqrt(Mathf.Pow((mousePosX - origin.transform.position.x), 2) + Mathf.Pow((mousePosY - origin.transform.position.y), 2)) / barrelLength;
        this.transform.position = new Vector2(origin.transform.position.x + ((mousePosX - origin.transform.position.x) / positionRatio), origin.transform.position.y + ((mousePosY - origin.transform.position.y) / positionRatio));
    }
}

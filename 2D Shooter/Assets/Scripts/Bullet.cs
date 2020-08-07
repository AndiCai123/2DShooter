using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D bulletRb;
    public GameObject bulletImpact;
    public GameObject headImpact;
    public GameObject bodyImpact;
    public Shooting shooting;
    void Start()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(Input.mousePosition.x > 340)
        {
            angle += shooting.totalRecoil * 2 + Random.Range(shooting.spreadDown, shooting.spreadUp);
        }
        if (Input.mousePosition.x < 340) ;
        {
            angle -= shooting.totalRecoil + Random.Range(shooting.spreadDown, shooting.spreadUp);
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(Vector3.left * 1);
        bulletRb.velocity = transform.right * shooting.speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "head")
        {
            Debug.Log("head");
            Instantiate(headImpact, transform.position, transform.rotation);
        }
        else if(collision.gameObject.tag == "Body")
        {
            Debug.Log("body");
            Instantiate(bodyImpact, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(bulletImpact, transform.position, transform.rotation);
        }

        DestroyObject(gameObject);
    }
}

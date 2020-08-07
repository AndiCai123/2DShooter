using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private bool m_FacingRight = true;

    void Update()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x && !m_FacingRight)
        {
            Flip();
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x && m_FacingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

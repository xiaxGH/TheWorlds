using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldactive : MonoBehaviour
{
    Vector2 m_moveLimit = new Vector2(4.0f, 4);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.localPosition = ClampPosition(transform.localPosition);
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(10f, 10, 10);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(10f, 10, 10);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(10f, 10, 10);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(10f, 10, 10);
        }
    }
    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector4
           (
            Mathf.Clamp(position.x, -m_moveLimit.x, m_moveLimit.x),
            -7f,
            Mathf.Clamp(position.y, -m_moveLimit.y, m_moveLimit.y),
            7f
        );
    }
}

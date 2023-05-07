using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //User ������
    public Transform userTransform;

    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        //User �������� ������ �´�
        transform.position = userTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(userTransform != null)
        {
            //ȭ���� X���� �ִ����� �ּ����� �����ʰ� ����
            float clampedX = Mathf.Clamp(userTransform.position.x, minX, maxX);
            //ȭ���� Y���� �ִ����� �۵����� �����ʰ� ����
            float clampedY = Mathf.Clamp(userTransform.position.y, minY, maxY);

            //ī�޶� clampedX, clampedY �������� speed �ӵ��� �ε巴�� �̵�
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
    }
}

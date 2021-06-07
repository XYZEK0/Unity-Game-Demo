using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMovement : MonoBehaviour
{
    [SerializeField] float posY;

    bool isOnTop = false;
    public float speed = 0.1f;
    public float topDistance;
    private void Start()
    {
        posY = transform.position.y;

    }
    private void Update()
    {
        if ((posY > transform.position.y - topDistance) && !isOnTop)
        {
            isOnTop = false;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (posY < transform.position.y)
        {
            isOnTop = true;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else isOnTop = !isOnTop;

        
    }
}

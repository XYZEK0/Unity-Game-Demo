using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofFloorScript : MonoBehaviour
{
    public float colldierDisablingTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.S))
        {
            if(Input.GetKey(KeyCode.Space))
            {
                GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(EnableCollider(colldierDisablingTime));
            }
        }
    }
    private IEnumerator EnableCollider(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}

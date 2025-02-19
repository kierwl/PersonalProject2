using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideableController : MonoBehaviour
{
    public float speed = 5f;
    private bool isRiding = false;

    void Update()
    {
        if (!isRiding) return;

        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }

    public void SetRiding(bool riding)
    {
        isRiding = riding;
    }
}

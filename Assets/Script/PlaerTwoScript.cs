using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerTwoScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float offset;
    [SerializeField] private float speed = 50f;
    private float moveInputx;
    private float moveInputy;
    private bool facengRight = true;
    private bool facengLeft = true;
    //void Update()
    //{
    //    Vector3 difference = Camera.main.ScreenToViewportPoint(Input.mousePosition)- transform.position;
    //    float rotZ = Mathf.Atan2(difference.y, difference.x)* Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    //}
    private void FixedUpdate()
    {

        PlayerMoving();
        Vector3 difference = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        //PlayerRotation();
    }


    private void Flip()
    {
        facengRight = !facengRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void PlayerRotation()
    {
        if (facengRight == false && moveInputx > 0)
            Flip();
        if (facengRight == true && moveInputx < 0)
            Flip();

    }
    private void PlayerMoving()

    {
        moveInputx = Input.GetAxis("Horizontal");
        moveInputy = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(speed * moveInputx, speed * moveInputy);

    }
}

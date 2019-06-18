using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPopcorn : MonoBehaviour
{
    public GameObject popcorn;
    public float speed = 500f;
    public float arc = 15;

    public bool isShooting = false;

    // Update is called once per frame
    void Update()
    {
        // If you click or touch, do it
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (!isShooting)
            {
                isShooting = true;
                StartCoroutine(ShootOne());
            }
        }
    }

    public IEnumerator ShootOne()
    {
        // Make popcorn at camera's position
        GameObject newPopcorn = Instantiate(popcorn, transform.position, Quaternion.identity) as GameObject;
        // Shoot popcorn at your face!
        Rigidbody popcornRigidBody = newPopcorn.GetComponent<Rigidbody>();
        Vector3 direction = Vector3.forward * speed;
        direction.y += arc;
        popcornRigidBody.AddForce(direction);
        isShooting = false;
        yield return null;
    }
}

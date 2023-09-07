using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float destroyImpactMagnitude = 5;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<BirdController>())
            Destroy(gameObject);

        if (collision.relativeVelocity.magnitude > destroyImpactMagnitude)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

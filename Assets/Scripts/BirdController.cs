using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    [SerializeField] float maxDragDistance = 3;
    [SerializeField] float launchPower = 350;
    LineRenderer lineRenderer;
    Vector3 startingPosition;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        startingPosition = transform.position;
        lineRenderer.enabled = false;
    }

    void OnMouseUp()
    {
        Vector3 directionAndMagnitude = startingPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionAndMagnitude * launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        lineRenderer.enabled = false;
    }

    void OnMouseDrag()
    {
        Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = 0;
        if (Vector2.Distance(destination, startingPosition) > maxDragDistance)
            destination = Vector3.MoveTowards(startingPosition, destination, maxDragDistance);
        transform.position = destination;
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer.enabled = true;
    }

    void Update()
    {
        if (FindAnyObjectByType<EnemyController>(FindObjectsInactive.Exclude) == null)
        {
            int levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke(nameof(ReloadLevel), 5);
    }

    void ReloadLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
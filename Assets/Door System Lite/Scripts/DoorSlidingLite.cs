// DoorRotationLite.cs
// Created by Alexander Ameye
// Version 3.0.0

using System.Collections;
using UnityEngine;

[HelpURL("https://alexdoorsystem.github.io/liteversion/")]
public class DoorSlidingLite : MonoBehaviour, IInteract
{
    public Transform doorTransform;
    public float raiseHeight = 3f;
    public float speed = 3f;
    public Vector3 _closedPosition;

    // Use this for initialization
    void Start()
    {
        _closedPosition = transform.position;
    }

    public IEnumerator Slide()
    {
      // StopCoroutine("MoveDoor");

        Vector3 endpos =    doorTransform.position;
        StartCoroutine("MoveDoor", endpos);
        yield return null;


    }

    void close(Collider other)
    {
        StopCoroutine("MoveDoor");
        StartCoroutine("MoveDoor", _closedPosition);
    }
   

        public IEnumerator MoveDoor(Vector3 endPos)
    {

        float t = 0f;
        Vector3 startPos = transform.position;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Slerp(startPos, endPos, t);
           // GetComponent<BoxCollider>().enabled = false;
            yield return null;
        }
    }

    public void Execute(RaycastHit hit) {
        StartCoroutine(hit.collider.GetComponent<DoorSlidingLite>().Slide());

    }
}


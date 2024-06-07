using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collsion! @ {collision.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name} !");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 look = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
        //    Debug.Log($"RayCast @ {hit.collider.gameObject.name} !");

        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        //foreach (RaycastHit hitt in hits)
        //{
        //    Debug.Log($"RayCastAll @ {hitt.collider.gameObject.name} !");
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = mousePos - Camera.main.transform.position;
            //dir = dir.normalized;
            // same ray

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);
            // Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

            RaycastHit hit;

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            //int mask = (1 << 8) | (1 << 9);

            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            // if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }
    }
}

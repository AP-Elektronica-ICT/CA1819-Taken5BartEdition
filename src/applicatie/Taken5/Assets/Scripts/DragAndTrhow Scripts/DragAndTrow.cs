using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Broncode https://www.youtube.com/watch?v=XH942mANiv4
public class DragAndTrow : MonoBehaviour {

    bool dragging = false;
    float distance;
    public float ThrowSpeed;
    public float ArchSpeed;
    public float speed;
    Vector3 startVector = new Vector3(0, 0, 0);
    Quaternion startRotation = new Quaternion(0,0,0,0);

    // Use this for initialization
    public void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Debug.Log("mouse down");
	}
    public void OnMouseUp()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity += this.transform.forward * ThrowSpeed;
        this.GetComponent<Rigidbody>().velocity += this.transform.up * ArchSpeed;
        dragging = false;
        Debug.Log("mouse up");

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {

            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().velocity = startVector;
            this.GetComponent<Rigidbody>().freezeRotation =true;
            dragging = false;
            Debug.Log("respanw");

        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (dragging)
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 raypoint = ray.GetPoint(distance);
            transform.position = Vector3.Lerp(this.transform.position, raypoint, speed * Time.deltaTime);
	    }
    }
}

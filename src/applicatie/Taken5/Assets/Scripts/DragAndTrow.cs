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

	// Use this for initialization
	void onMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;    
	}
    public void OnMouseUp()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity += this.transform.forward * ThrowSpeed;
        this.GetComponent<Rigidbody>().velocity += this.transform.up * ArchSpeed;
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 raypoint = ray.GetPoint(distance);
            transform.position = Vector3.Lerp(this.transform.position, raypoint, speed * Time.deltaTime);
	    }
    }
}

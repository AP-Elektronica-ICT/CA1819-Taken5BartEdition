using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndTrhrowManager : MonoBehaviour {
    public Vector3 StartPosition;
    Quaternion StartRotation = new Quaternion(0, 0, 0, 0);

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "CatchObject")
        {
      
            StartCoroutine("CatchObject", other.gameObject);

        }
        if (other.gameObject.tag == "Respawn")
        {

            Debug.Log("nu respawne");
            transform.SetPositionAndRotation(StartPosition, StartRotation);

        }
    }
        
    IEnumerator CatchObject(GameObject CatchObject)
    {
        transform.Translate(Vector3.up, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(CatchObject.gameObject);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Player").transform.LookAt(this.transform);
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Camera>().fieldOfView = 8.2f;

    }

}
    
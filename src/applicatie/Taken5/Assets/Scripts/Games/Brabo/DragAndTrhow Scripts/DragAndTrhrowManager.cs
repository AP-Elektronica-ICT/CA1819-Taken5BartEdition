using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndTrhrowManager : MonoBehaviour {
    public Vector3 StartPosition;
    Quaternion StartRotation = new Quaternion(0, 0, 0, 0);
    int count = 11;
    LevelLoader levelLoader;
    APICaller api;
    bool triggerd = true;
    void Start()
    {
        levelLoader = gameObject.AddComponent<LevelLoader>();
        api = gameObject.AddComponent<APICaller>();


    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "CatchObject")
        {
            if (triggerd)
            {
                triggerd = false;
                StartCoroutine("CatchObject", other.gameObject);

            }

        }
        if (other.gameObject.tag == "Respawn")
        {
            count--;
            Debug.Log("respawn");
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
        //GameObject.FindGameObjectWithTag("Player").transform.LookAt(this.transform);
        //GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Camera>().fieldOfView = 8.2f;
        if (count == 0)
        {
            count = 1;
        }

        levelLoader.ChangeGameModeEndOfGame(api, "grotemarkt", count);

    }

}
   
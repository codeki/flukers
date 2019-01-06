using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePylons : MonoBehaviour
{

    private GameObject[] pylons;
    private GameObject pylon_parent1a;
    private GameObject pylon_parent2a;
    private GameObject pylon_parent1b;
    private GameObject pylon_parent2b;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} collided with {this.gameObject.name}!");
        //pylons = GameObject.FindGameObjectsWithTag("PylonTag");
        pylon_parent1a = GameObject.Find("ImageTarget - Roads/AllRoads1/RoadSet1/Pylons1");
        pylon_parent2a = GameObject.Find("ImageTarget - Roads/AllRoads1/RoadSet2/Pylons2");
        pylon_parent1b = GameObject.Find("ImageTarget - Roads/AllRoads2/RoadSet1/Pylons1");
        pylon_parent2b = GameObject.Find("ImageTarget - Roads/AllRoads2/RoadSet2/Pylons2");

        if (collision.gameObject.name == "Car3" && !GlobalVars.rotate_now)
        {
            if (null != pylon_parent1a)
            {
                Debug.Log($"ENABLING {pylon_parent1a.transform.childCount} pylons in RoadSet1");
                foreach (Transform p in pylon_parent1a.transform)
                {
                    p.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
            }
            if (null != pylon_parent2a)
            {
                Debug.Log($"ENABLING {pylon_parent2a.transform.childCount} pylons in RoadSet2");
                foreach (Transform p in pylon_parent2a.transform)
                {
                    p.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
            }
            if (null != pylon_parent1b)
            {
                Debug.Log($"ENABLING {pylon_parent1b.transform.childCount} pylons in RoadSet1");
                foreach (Transform p in pylon_parent1b.transform)
                {
                    p.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
            }
            if (null != pylon_parent2b)
            {
                Debug.Log($"ENABLING {pylon_parent2b.transform.childCount} pylons in RoadSet2");
                foreach (Transform p in pylon_parent2b.transform)
                {
                    p.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlock1 : MonoBehaviour
{
    private GameObject all_roads1;
    private GameObject all_roads2;
    private GameObject road_set1;
    private GameObject road_set2;
    private GameObject all_blocks1;
    private GameObject all_blocks2;
    private GameObject block1;
    private GameObject block2;
    private GameObject my_car;
    private float roty;
    private float car_roty;
    private GameObject pylon_parent1;
    private GameObject pylon_parent2;
    private GameObject sensor_parent1;
    private GameObject sensor_parent2;
    private GameObject sensor_parentb1;
    private GameObject sensor_parentb2;
    private bool my_rotate;

    // Start is called before the first frame update
    void Start()
    {
        //find GameObjects
        all_roads1 = GameObject.Find("/ImageTarget - Roads/AllRoads1");
        road_set1 = GameObject.Find("/ImageTarget - Roads/AllRoads1/RoadSet1");
        road_set2 = GameObject.Find("/ImageTarget - Roads/AllRoads1/RoadSet2");
        all_blocks1 = GameObject.Find("/ImageTarget - Blocks/AllBlocks1");
        block1 = GameObject.Find("/ImageTarget - Blocks/AllBlocks1/Block1");
        block2 = GameObject.Find("/ImageTarget - Blocks/AllBlocks1/Block2");
        all_roads2 = GameObject.Find("/ImageTarget - Roads/AllRoads2");
        all_blocks2 = GameObject.Find("/ImageTarget - Blocks/AllBlocks2");
        my_car = GameObject.Find("/ImageTarget - Car/Car3");

        //set visibility states
        road_set1.SetActive(true);
        block1.SetActive(true);
        road_set2.SetActive(false);
        block2.SetActive(false);

        //set rotation parameters
        my_rotate = false;
        roty = 0;
        car_roty = 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (my_rotate)
        {
            //define rotation steps per frame
            Debug.Log($"ROTATION in progress: {roty}");
            roty += Time.deltaTime * 25;
            car_roty += Time.deltaTime * 25;
            all_roads2.transform.localRotation = Quaternion.Euler(0, roty, 0);
            all_blocks2.transform.localRotation = Quaternion.Euler(0, roty, 0);
            my_car.transform.localRotation = Quaternion.Euler(0, car_roty, 0);

            //at the end of rotation...
            if (roty > 178.0f)
            {
                //set precisely to final rotations
                all_roads1.transform.localRotation = Quaternion.Euler(0, 180.0f, 0);
                all_blocks1.transform.localRotation = Quaternion.Euler(0, 180.0f, 0);
                all_roads2.transform.localRotation = Quaternion.Euler(0, 180.0f, 0);
                all_blocks2.transform.localRotation = Quaternion.Euler(0, 180.0f, 0);
                my_car.transform.localRotation = Quaternion.Euler(0, 0, 0);

                //update visibility states
                Debug.Log($"ENABLING {sensor_parent1.transform.childCount} sensors in RoadSet1");
                foreach (Transform s in sensor_parent1.transform)
                {
                    s.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                Debug.Log($"ENABLING {sensor_parent2.transform.childCount} sensors in RoadSet2");
                foreach (Transform s in sensor_parent2.transform)
                {
                    s.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                Debug.Log($"ENABLING {sensor_parentb1.transform.childCount} sensors in Block1");
                foreach (Transform s in sensor_parentb1.transform)
                {
                    s.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                Debug.Log($"ENABLING {sensor_parentb2.transform.childCount} sensors in Block2");
                foreach (Transform s in sensor_parentb2.transform)
                {
                    s.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                //foreach (GameObject s in sensors)
                //{
                //    s.GetComponent<BoxCollider>().enabled = true;
                //}
                road_set1.SetActive(false);
                block1.SetActive(false);

                //reset rotation parameters
                GlobalVars.rotate_now = false;
                my_rotate = false;
                roty = 0;
                car_roty = 180.0f;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log($"{col.gameObject.name} collided with {this.gameObject.name}!");

        if (col.gameObject.name == "Car3" && !GlobalVars.rotate_now)
        {
            //detect
            Debug.Log($"ROTATE on {this.gameObject.name}!");
            GlobalVars.rotate_now = true;
            my_rotate = true;

            //position new block, set local pivot
            //road_set1 = GameObject.Find("/ImageTarget - Roads/AllRoads1/RoadSet1");
            //road_set2 = GameObject.Find("/ImageTarget - Roads/AllRoads1/RoadSet2");
            //block1 = GameObject.Find("/ImageTarget - Blocks/AllBlocks1/Block1");
            //block2 = GameObject.Find("/ImageTarget - Blocks/AllBlocks1/Block2");

            road_set2.transform.position = road_set1.transform.position;
            block2.transform.position = block1.transform.position;
            road_set2.transform.localPosition += new Vector3(4, 0, -4);
            block2.transform.localPosition += new Vector3(4, 0, -4);
            all_roads2.transform.localPosition = new Vector3(0, 0, 0);
            all_blocks2.transform.localPosition = new Vector3(0.689f, 0, 0);

            switch (this.gameObject.name)
            {
                case "NE1":
                    road_set2.transform.localPosition += new Vector3(4, 0, -4);
                    block2.transform.localPosition += new Vector3(4, 0, -4);
                    all_roads2.transform.localPosition += new Vector3(2, 0, -2);
                    all_blocks2.transform.localPosition += new Vector3(2, 0, -2);
                    break;
                case "NW1":
                    road_set2.transform.localPosition += new Vector3(4, 0, 4);
                    block2.transform.localPosition += new Vector3(4, 0, 4);
                    all_roads2.transform.localPosition += new Vector3(2, 0, 2);
                    all_blocks2.transform.localPosition += new Vector3(2, 0, 2);
                    break;
                case "SE1":
                    road_set2.transform.localPosition += new Vector3(-4, 0, -4);
                    block2.transform.localPosition += new Vector3(-4, 0, -4);
                    all_roads2.transform.localPosition += new Vector3(-2, 0, -2);
                    all_blocks2.transform.localPosition += new Vector3(-2, 0, -2);
                    break;
                case "SW1":
                    road_set2.transform.localPosition += new Vector3(-4, 0, 4);
                    block2.transform.localPosition += new Vector3(-4, 0, 4);
                    all_roads2.transform.localPosition += new Vector3(-2, 0, 2);
                    all_blocks2.transform.localPosition += new Vector3(-2, 0, 2);
                    break;

            }

            //set new parent group for proper roataion pivot
            road_set1.transform.parent = all_roads2.transform;
            road_set2.transform.parent = all_roads2.transform;
            block1.transform.parent = all_blocks2.transform;
            block2.transform.parent = all_blocks2.transform;

            //show new block and road set
            road_set2.SetActive(true);
            block2.SetActive(true);

            //hide all pylons and sensors during rotation
            //foreach (GameObject p in pylons)
            //{
            //    p.GetComponent<BoxCollider>().enabled = false;
            //}
            //Debug.Log($"DISABLING {pylons.Length} pylons");
            //foreach (GameObject s in sensors)
            //{
            //    s.GetComponent<BoxCollider>().enabled = false;
            //}
            pylon_parent1 = GameObject.Find("ImageTarget - Roads/AllRoads2/RoadSet1/Pylons1");
            pylon_parent2 = GameObject.Find("ImageTarget - Roads/AllRoads2/RoadSet2/Pylons2");
            sensor_parent1 = GameObject.Find("ImageTarget - Roads/AllRoads2/RoadSet1/Sensors1");
            sensor_parent2 = GameObject.Find("ImageTarget - Roads/AllRoads2/RoadSet2/Sensors2");
            sensor_parentb1 = GameObject.Find("ImageTarget - Blocks/AllBlocks2/Block1/Sensorsb1");
            sensor_parentb2 = GameObject.Find("ImageTarget - Blocks/AllBlocks2/Block2/Sensorsb2");
            Debug.Log($"DISABLING {pylon_parent1.transform.childCount} pylons in RoadSet1");
            foreach (Transform p in pylon_parent1.transform)
            {
                p.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            Debug.Log($"DISABLING {pylon_parent2.transform.childCount} pylons in RoadSet2");
            foreach (Transform p in pylon_parent2.transform)
            {
                p.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            Debug.Log($"DISABLING {sensor_parent1.transform.childCount} sensors in RoadSet1");
            foreach (Transform s in sensor_parent1.transform)
            {
                s.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            Debug.Log($"DISABLING {sensor_parent2.transform.childCount} sensors in RoadSet2");
            foreach (Transform s in sensor_parent2.transform)
            {
                s.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            Debug.Log($"DISABLING {sensor_parentb1.transform.childCount} sensors in Block1");
            foreach (Transform s in sensor_parentb1.transform)
            {
                s.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            Debug.Log($"DISABLING {sensor_parentb2.transform.childCount} sensors in Block2");
            foreach (Transform s in sensor_parentb2.transform)
            {
                s.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            //foreach (BoxCollider p in pylon_parent1.GetComponentsInChildren<BoxCollider>())
            //{
            //    p.enabled = false;
            //}
            //Debug.Log($"DISABLING {pylon_parent2.transform.childCount} pylons in RoadSet2");
            //foreach (BoxCollider p in pylon_parent2.GetComponentsInChildren<BoxCollider>())
            //{
            //    p.enabled = false;
            //}
            //perform rotation
            car_roty = my_car.transform.localRotation.eulerAngles.y;
        }
        else
        {
            Debug.Log("SKIP this collision");
        }
    }
}

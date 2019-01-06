using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParked : MonoBehaviour
{
    private GameObject Light_system;
    private GameObject interior_light;
    private Light ilight;

    private GameObject car_exterior;
    private GameObject L_car_door;
    private GameObject L_handles;
    private GameObject L_handle2;
    private GameObject L_handle3;
    private Animation ldoor;
    private Animation ldoorh2;
    private Animation ldoorh3;
    private GameObject R_car_door;
    private GameObject R_handles;
    private GameObject R_handle2;
    private GameObject R_handle3;
    private Animation rdoor;
    private Animation rdoorh2;
    private Animation rdoorh3;

    // Start is called before the first frame update
    void Start()
    {
        Light_system = gameObject.transform.Find("Light_system").gameObject;
        interior_light = Light_system.transform.Find("interior_light").gameObject;
        ilight = interior_light.GetComponent<Light>();  // We get "light" component from our gameobject
        ilight.enabled = false;  // Light always disabled, when scene start

        car_exterior = gameObject.transform.Find("car_exterior").gameObject;
        L_car_door = car_exterior.transform.Find("L_car_door").gameObject;
        L_handles = L_car_door.transform.Find("L_handles").gameObject;
        L_handle2 = L_handles.transform.Find("L_handle2").gameObject;
        L_handle3 = L_handles.transform.Find("L_handle3").gameObject;
        ldoor = L_car_door.GetComponent<Animation>();
        ldoorh2 = L_handle2.GetComponent<Animation>();
        ldoorh3 = L_handle3.GetComponent<Animation>();
        R_car_door = car_exterior.transform.Find("R_car_door").gameObject;
        R_handles = R_car_door.transform.Find("R_handles").gameObject;
        R_handle2 = R_handles.transform.Find("R_handle2").gameObject;
        R_handle3 = R_handles.transform.Find("R_handle3").gameObject;
        rdoor = R_car_door.GetComponent<Animation>();
        rdoorh2 = R_handle2.GetComponent<Animation>();
        rdoorh3 = R_handle3.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Parked-Driveway-PP":
                Debug.Log("Car entering PP's driveway");
                ilight.enabled = true;
                if (ldoor.isPlaying) return;
                ldoorh2["L_door_handle_2"].speed = 1;
                ldoorh2.Play("L_door_handle_2");
                var ldoorh2_close = ldoorh2.PlayQueued("L_door_handle_2");
                ldoorh2_close.speed = -1;
                ldoorh2_close.time = ldoorh2_close.length;

                ldoorh3["L_door_handle"].speed = 1;
                ldoorh3.Play("L_door_handle");
                var ldoorh3_close = ldoorh3.PlayQueued("L_door_handle");
                ldoorh3_close.speed = -1;
                ldoorh3_close.time = ldoorh3_close.length;

                ldoor["L_door_open"].speed = 1;
                ldoor.Play("L_door_open");
                var ldoor_close = ldoor.PlayQueued("L_door_open");
                ldoor_close.speed = -1;
                ldoor_close.time = ldoor_close.length;
                break;
            case "Parked-Driveway-L":
                Debug.Log("Car entering L's driveway");
                ilight.enabled = true;
                if (rdoor.isPlaying) return;
                rdoorh2["R_door_handle"].speed = 1;
                rdoorh2.Play("R_door_handle");
                var rdoorh2_close = rdoorh2.PlayQueued("R_door_handle");
                rdoorh2_close.speed = -1;
                rdoorh2_close.time = rdoorh2_close.length;

                rdoorh3["R_door_handle_2"].speed = 1;
                rdoorh3.Play("R_door_handle_2");
                var rdoorh3_close = rdoorh3.PlayQueued("R_door_handle_2");
                rdoorh3_close.speed = -1;
                rdoorh3_close.time = rdoorh3_close.length;

                rdoor["R_door_open"].speed = 1;
                rdoor.Play("R_door_open");
                var rdoor_close = rdoor.PlayQueued("R_door_open");
                rdoor_close.speed = -1;
                rdoor_close.time = rdoor_close.length;
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Parked-Driveway-PP":
                Debug.Log("Car exiting PP's driveway");
                ilight.enabled = false;
                break;

            case "Parked-Driveway-L":
                Debug.Log("Car exiting L's driveway");
                ilight.enabled = false;
                break;
        }
    }
}

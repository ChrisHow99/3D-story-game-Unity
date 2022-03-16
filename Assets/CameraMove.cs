using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Vector3 T;
    public GameObject Cam;
    void Start()
    {
        Cam.transform.position = T;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

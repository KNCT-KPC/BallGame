using UnityEngine;
using System.Collections;

public class GameControrr : MonoBehaviour {

    float SPEED = 5.0f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");
        Vector3 vec = Vector3.right * xValue * SPEED+ Vector3.forward * zValue * SPEED;
        if ( (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            vec /= Mathf.Sqrt(2);
        }
        
        GetComponent<Rigidbody>().AddForce(vec);
    }
}

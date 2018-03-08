using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
    Vector3 startPosition;
    float movePower = 80.0f;
    bool grounded = false;
    float lastGroundedTime;
    public GUIText gameClearText;
    bool gameClear = false;


    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        lastGroundedTime = Time.time;
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
        lastGroundedTime = Time.time;
        GetComponent<Rigidbody>().freezeRotation = false;
    }
    void ResetGame()
    {
        transform.position = startPosition;
        transform.eulerAngles = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    IEnumerator WaitAndReloadScene()
    {
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel(Application.loadedLevel);
    }

    void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().Sleep();
        gameClear = true;
        gameClearText.gameObject.SetActive(true);
        Application.Quit();
        //        StartCoroutine(WaitAndReloadScene());
    }

    // Update is called once per frame
    void Update () {
        if (gameClear) return;
        if (grounded)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * movePower;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * movePower;
            GetComponent<Rigidbody>().AddForce(x, 0, z);
        }
        if (Time.time - lastGroundedTime > 2.0f)
        {
            lastGroundedTime = Time.time;
            ResetGame();
        }
        float rayDistance = 20.0f;
        Debug.DrawRay(transform.position, -Vector3.up * rayDistance, Color.red);
        if (Physics.Raycast(transform.position, -Vector3.up, rayDistance))
        {
            lastGroundedTime = Time.time;
        }
    }
}

using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public Transform target;
    Vector3 relativePosition;

    // Use this for initialization
    void Start () {
        relativePosition = transform.position - target.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position + relativePosition;

        transform.LookAt(target.transform.position);  // カメラをtargetの方向へ向かせるように設定する
    }
}

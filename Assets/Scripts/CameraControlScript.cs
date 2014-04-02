using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour
{
    [SerializeField]
    Camera _cam;
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            _cam.transform.Translate(0, 0, -Vector3.forward.z * 5);
            //Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 1, 1);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            _cam.transform.Translate(0, 0, Vector3.forward.z * 5);
            //Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - 1, 6);
        }
    }
}

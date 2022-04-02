using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxValueX;
    [SerializeField] float minValueX;
    [SerializeField] float maxValueY;
    [SerializeField] float minValueY;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, minValueX, maxValueX),
            Mathf.Clamp(target.position.y, minValueY, maxValueY),
            this.transform.position.z
        );
    }
}

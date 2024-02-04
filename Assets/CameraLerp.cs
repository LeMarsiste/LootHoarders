using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraLerp : MonoBehaviour
{
    public Transform targetPosition;
    public Transform targetRotation;
    public float moveSpeed = 2f;
    public float rotationSpeed = 2f;
    public float movementDelay = 5f;

    float deltaTime = 0f;
    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > movementDelay)
            MoveCamera();
    }

    //Basically Just Lerping the Camera to the target position so we can enable the UI after that
    private void MoveCamera()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);

        Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetRotation.rotation, rotationSpeed * Time.deltaTime);

        transform.position = newPosition;
        transform.rotation = newRotation;

        if (transform.rotation == targetRotation.rotation)
        {
            //We don't want random Updates runnin now do we?
            Debug.Log("<color=red> Show UI After This Section </color>");
            enabled = false;
        }
    }
}

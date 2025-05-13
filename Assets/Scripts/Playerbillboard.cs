using UnityEngine;

public class PlayerBillboard : MonoBehaviour
{
    private Transform cameraTransform;
    public float rotationSpeed = 5f;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector3 targetPosition = cameraTransform.position;
        targetPosition.y = transform.position.y; 


        Vector3 direction = targetPosition - transform.position;

        
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction); 
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

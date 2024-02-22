using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 distance;
    [SerializeField] private Transform playerTransform;
    //[SerializeField] float smoothTime;
    //Vector3 curVelo;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = playerTransform.position + offset;
        transform.position = targetPos;
        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref curVelo, smoothTime, Mathf.Infinity, Time.deltaTime) ;
    }
}
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform target; 
    public Transform topBorder;
    public Transform bottomBorder;
    public Transform leftBorder;
    public Transform rightBorder;

    private float cameraHalfWidth;
    private float cameraHalfHeight;

    private void Start()
    {
        Camera camera = Camera.main;
        cameraHalfHeight = camera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * camera.aspect;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            float minX = leftBorder.position.x + cameraHalfWidth;
            float maxX = rightBorder.position.x - cameraHalfWidth;
            float minY = bottomBorder.position.y + cameraHalfHeight;
            float maxY = topBorder.position.y - cameraHalfHeight;

            float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(target.position.y, minY, maxY);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}

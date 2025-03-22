using UnityEngine;
using Cinemachine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public CinemachineVirtualCamera virtualCamera;

    public float minZoom = 40f; // Minimum FOV (when players are close)
    public float maxZoom = 60f; // Maximum FOV (when players are far)
    public float zoomSpeed = 5f;
    public float maxDistance = 10f; // Maximum distance before max zoom out

    private void LateUpdate()
    {
        if (player1 == null || player2 == null || virtualCamera == null) return;

        // Set position to the midpoint between players
        transform.position = (player1.position + player2.position) / 2;

        // Calculate distance between players
        float distance = Vector3.Distance(player1.position, player2.position);

        // Map distance to FOV range using Lerp
        float targetFOV = Mathf.Lerp(minZoom, maxZoom, distance / maxDistance);

        // Smoothly adjust the camera FOV
        CinemachineComponentBase componentBase = virtualCamera.GetCinemachineComponent<CinemachineComponentBase>();
        if (componentBase is CinemachineFramingTransposer framingTransposer)
        {
            framingTransposer.m_CameraDistance = Mathf.Lerp(framingTransposer.m_CameraDistance, targetFOV, Time.deltaTime * zoomSpeed);
        }
        else
        {
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
        }
    }
}

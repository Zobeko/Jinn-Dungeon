using UnityEngine;

public class BackgroundFollowsCamera : MonoBehaviour
{

    [SerializeField] private GameObject mainCamera;

    private Vector3 v = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3.SmoothDamp(transform.position, mainCamera.transform.position, ref v, 0f);
    }
}

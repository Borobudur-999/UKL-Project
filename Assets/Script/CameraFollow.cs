using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _player;
    public float _smooth;

    void LateUpdate()
    {
        Vector3 _targetPos = new Vector3(transform.position.x, _player.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, _targetPos, _smooth * Time.deltaTime);
    }
}

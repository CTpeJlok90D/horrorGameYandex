using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _maxAngle;
    [SerializeField] private LookZone _zone;

	public Vector2 Look => (PlayerDataContainer.Instance.IsMobileDevise ? _zone.Delta : InputSingletone.Instance.PlayerMovement.Look.ReadValue<Vector2>()) * PlayerDataContainer.Instance.MouseSensivity.Value;

	protected void Update()
    {
        RotateCharacter(Look.x);
        RotateCamera(Look.y);
    }

    public void RotateCharacter(float offcet)
    {
        Vector3 rotateOffcet = new Vector3(0, offcet, 0);
		_playerMovement.transform.Rotate(rotateOffcet);
    }

    public void RotateCamera(float offcet)
    {
        float newRotateAnge = _camera.eulerAngles.x - offcet;
        if (newRotateAnge > 180 && newRotateAnge < 360 - _maxAngle)
        {
            newRotateAnge = 360 - _maxAngle;
        }
        if (newRotateAnge < 180 && newRotateAnge > _maxAngle)
        {
            newRotateAnge = _maxAngle;
        }

		_camera.transform.eulerAngles = new Vector3(newRotateAnge, _camera.eulerAngles.y, _camera.eulerAngles.z);
	}
}
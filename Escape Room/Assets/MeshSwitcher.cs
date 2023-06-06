using UnityEditor;
using UnityEngine;

public class MeshSwitcher : MonoBehaviour
{

}

#if UNITY_EDITOR

[CustomEditor(typeof(MeshSwitcher))]
class MeshSwitcherEditor : Editor
{
	private new MeshSwitcher target => (serializedObject.targetObject as MeshSwitcher);

	public override void OnInspectorGUI()
	{
		if (GUILayout.Button("ShowAllMeshes"))
		{
			SetMeshActive(true, target.transform);
		}
		if (GUILayout.Button("HideAllMeshes"))
		{
			SetMeshActive(false, target.transform);
		}
	}

	private void SetMeshActive(bool value, Transform parent)
	{
		if (parent.TryGetComponent(out MeshRenderer parentRenderer))
		{
			parentRenderer.enabled = value;
		}
		foreach (Transform transform in parent)
		{
			Debug.Log(transform.name);
			if (transform.TryGetComponent(out MeshRenderer renderer))
			{
				renderer.enabled = value;
			}
			foreach (Transform child in transform)
			{
				SetMeshActive(value, child);
			}
		}
	}
}

#endif
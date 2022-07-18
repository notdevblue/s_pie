#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using AI;

[CustomEditor(typeof(Detect))]
[CanEditMultipleObjects]
public class ChangeColliderRadius : Editor
{
   private CircleCollider2D _collider;
   private Detect _detect;
   private SerializedProperty _radius;

   private void OnEnable()
   {
      _detect   = (target as MonoBehaviour).GetComponent<Detect>();
      _collider = (target as MonoBehaviour).GetComponent<CircleCollider2D>();
      _radius   = serializedObject.FindProperty(nameof(_detect.radius));
   }

   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();
      GUILayout.Label("\n감지 거리");
      serializedObject.Update();
      _radius.floatValue = EditorGUILayout.FloatField(nameof(_detect.radius), _radius.floatValue);
      serializedObject.ApplyModifiedProperties();
      _collider.radius = _radius.floatValue;
   }
}
#endif
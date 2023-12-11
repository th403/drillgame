#if UNITY_EDITOR
 using UnityEngine;
 using UnityEditor;
 using System.Reflection;
 [SerializeField]
 public class SaveTransform
 {
     //�Q�ƌ^��ۑ�����ƃC���X�^���XID�݂̂��ۑ�����A�Đ��O�̏�Ԃɖ߂�̂Œl�^��ۑ�����
     [SerializeField] private Vector3 position;
     [SerializeField] private Quaternion rotation;
     [SerializeField] private Vector3 scale;
     public Transform GetValue(Transform t)
     {
          t.position = position;
          t.rotation = rotation;
          t.localScale = scale;
          return t;
      }

     public void SetValue(Transform t)
     {    
          position = t.position;
          rotation = t.rotation;
          scale = t.localScale;
     }
 }

 //�Đ����ɕύX���ꂽTransform�̒l���Đ��I����ɔ��f������X�N���v�g
 [CustomEditor(typeof(Transform), true)]
 [CanEditMultipleObjects]
 public class InspectorTransform : Editor
 {
     private Editor editor;
     private Transform myParam;
     private bool set;

     private void OnEnable()
     {    
          Transform transform = target as Transform;
          myParam = transform;
          System.Type t = typeof(UnityEditor.EditorApplication).Assembly.GetType("UnityEditor.TransformInspector");
          editor = Editor.CreateEditor(myParam, t);
      }

      private void OnDisable()
      {
          MethodInfo disableMethod = editor.GetType().GetMethod("OnDisable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
          if (disableMethod != null) disableMethod.Invoke(editor, null);
          myParam = null;
          DestroyImmediate(editor);
      }

      public override void OnInspectorGUI()
      {
          editor.OnInspectorGUI();
          if (EditorApplication.isPlaying || EditorApplication.isPaused)
          {
              if (GUILayout.Button("�Đ����̏�Ԃ�ۑ�"))
              {
                  SaveTransform s = new SaveTransform();                 
                  s.SetValue(myParam);
                  string json = JsonUtility.ToJson(s);            
                  EditorPrefs.SetString("Save Param " + myParam.GetInstanceID().ToString(), json);
                  if (!set)
                  {
                      EditorApplication.playModeStateChanged += OnChangedPlayMode;                 set = true;
                  }
              }
          }
      }

      private void OnChangedPlayMode(PlayModeStateChange state)
      {
          //Unity�̍Đ����I������
          if (state == PlayModeStateChange.EnteredEditMode)
          {
              Transform transform = target as Transform;
              string key = "Save Param " + transform.GetInstanceID().ToString();        
              string json = EditorPrefs.GetString(key);
              SaveTransform t = JsonUtility.FromJson<SaveTransform>(json);
              EditorPrefs.DeleteKey(key);
              transform = t.GetValue(transform);
              EditorUtility.SetDirty(target);        
              EditorApplication.playModeStateChanged -= OnChangedPlayMode;
          }
      }
 }
#endif
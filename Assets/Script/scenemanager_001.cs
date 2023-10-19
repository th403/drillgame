using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager_001 : MonoBehaviour
{
    [SerializeField]
    string targetSceneName;

    public static scenemanager_001 Instance { get; private set; }

    //�g����
    //�@���̃X�N���v�g��add component����

    //�ATarget Scene Name���ɃV�[���J�ڐ�̃V�[����������

    //�B�����̃R�[�h�𑼂̃X�N���v�g���̃V�[���J�ڏ������ɓ����
    //scenemanager_001.Instance.LoadScene();

    //��  if (Input.GetKey(KeyCode.Space))
    //    {
    //        scenemanager_001.Instance.LoadScene();
    //    }

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
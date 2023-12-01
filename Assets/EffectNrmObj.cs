using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectNrmObj : MonoBehaviour
{
    public GameObject Effect;
    public string targetTag = "Driller"; // �^�[�Q�b�g�̃^�O��ϐ��Ŏw��

    // Start is called before the first frame update
    void Start()
    {
        // �����s��Ȃ�
    }

    // Update is called once per frame
    void Update()
    {
        // �����s��Ȃ�
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �^�[�Q�b�g�̃^�O����v���AEffect���ݒ肳��Ă���ꍇ
        if (collision.collider.CompareTag(targetTag) && Effect)
        {
            // �R���W�����̖@���x�N�g�����擾���A���̕����ɃG�t�F�N�g�𐶐�
            Vector3 collisionNormal = collision.contacts[0].normal;
            Quaternion rotation = Quaternion.LookRotation(collisionNormal);

            Instantiate(Effect, collision.contacts[0].point, rotation);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;  //AssetDatabase���g�����߂ɒǉ�
using System.IO;  //StreamWriter�Ȃǂ��g�����߂ɒǉ�
using System.Linq;  //Select���g�����߂ɒǉ�

public class SaveData_001 : MonoBehaviour
{
    //�ۑ���
    string datapath;
    void Awake()
    {
        //�ۑ���̌v�Z������
        //�����Assets�������w��. /�ȍ~�Ƀt�@�C����
        datapath = Application.dataPath + "/Sumi/ScoreData.json";
    }

    // Start is called before the first frame update
    void Start()
    {
        //player�f�[�^���擾
        ScoreData scoredata = new ScoreData();

        //JSON�t�@�C��������΃��[�h, �Ȃ���Ώ������֐���
        if (FindJsonfile())
        {
            scoredata = loadData();
        }
        else
        {
            Initialize(scoredata);
        }

    }

    //�Z�[�u���邽�߂̊֐�
    public void saveData(ScoreData scoredata)
    {
        StreamWriter writer;

        //player�f�[�^��JSON�ɕϊ�
        string jsonstr = JsonUtility.ToJson(scoredata);

        //JSON�t�@�C���ɏ�������
        writer = new StreamWriter(datapath, false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    //JSON�t�@�C����ǂݍ���, ���[�h���邽�߂̊֐�
    public ScoreData loadData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(datapath);
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<ScoreData>(datastr);
    }

    //JSON�t�@�C�����Ȃ��ꍇ�ɌĂяo���������֐�
    //�����l���Z�[�u��, JSON�t�@�C���𐶐�����
    public void Initialize(ScoreData scoredata)
    {
        //�X�e�[�W�P
        scoredata.Stage1_1stPayment = 1;
        scoredata.Stage1_1stLank = "-";

        scoredata.Stage1_2ndPayment = 0;
        scoredata.Stage1_2ndLank = "-";

        scoredata.Stage1_3rdPayment = 0;
        scoredata.Stage1_3rdLank = "-";

        //�X�e�[�W�Q
        scoredata.Stage2_1stPayment = 0;
        scoredata.Stage2_1stLank = "-";

        scoredata.Stage2_2ndPayment = 0;
        scoredata.Stage2_2ndLank = "-";

        scoredata.Stage2_3rdPayment = 0;
        scoredata.Stage2_3rdLank = "-";

        //�X�e�[�W�R
        scoredata.Stage3_1stPayment = 0;
        scoredata.Stage3_1stLank = "-";

        scoredata.Stage3_2ndPayment = 0;
        scoredata.Stage3_2ndLank = "-";

        scoredata.Stage3_3rdPayment = 0;
        scoredata.Stage3_3rdLank = "-";

        saveData(scoredata);
    }

    //JSON�t�@�C���̗L���𔻒肷�邽�߂̊֐�
    public bool FindJsonfile()
    {
#if UNITY_EDITOR
        string[] assets = AssetDatabase.FindAssets(datapath);
        Debug.Log(assets.Length);
        if (assets.Length != 0)
        {
            string[] paths = assets.Select(guid => AssetDatabase.GUIDToAssetPath(guid)).ToArray();
            Debug.Log($"��������:\n{string.Join("\n", paths)}");
            return true;
        }
        else
        {
            Debug.Log("Json�t�@�C�����Ȃ�����");
            return false;
        }
#endif 
        return false;
    }

    //Player�̃f�[�^�ƂȂ�N���X�̒�`
    [System.Serializable]
    public class ScoreData
    {
        //�X�e�[�W�P
        public int Stage1_1stPayment;
        public string Stage1_1stLank;

        public int Stage1_2ndPayment;
        public string Stage1_2ndLank;

        public int Stage1_3rdPayment;
        public string Stage1_3rdLank;

        //�X�e�[�W�Q
        public int Stage2_1stPayment;
        public string Stage2_1stLank;

        public int Stage2_2ndPayment;
        public string Stage2_2ndLank;

        public int Stage2_3rdPayment;
        public string Stage2_3rdLank;

        //�X�e�[�W�R
        public int Stage3_1stPayment;
        public string Stage3_1stLank;

        public int Stage3_2ndPayment;
        public string Stage3_2ndLank;

        public int Stage3_3rdPayment;
        public string Stage3_3rdLank;
    }
}

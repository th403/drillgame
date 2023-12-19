using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;  //AssetDatabaseを使うために追加
using System.IO;  //StreamWriterなどを使うために追加
using System.Linq;  //Selectを使うために追加

public class SaveData_001 : MonoBehaviour
{
    //保存先
    string datapath;
    void Awake()
    {
        //保存先の計算をする
        //これはAssets直下を指定. /以降にファイル名
        datapath = Application.dataPath + "/Sumi/ScoreData.json";
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerデータを取得
        ScoreData scoredata = new ScoreData();

        //JSONファイルがあればロード, なければ初期化関数へ
        if (FindJsonfile())
        {
            scoredata = loadData();
        }
        else
        {
            Initialize(scoredata);
        }

    }

    //セーブするための関数
    public void saveData(ScoreData scoredata)
    {
        StreamWriter writer;

        //playerデータをJSONに変換
        string jsonstr = JsonUtility.ToJson(scoredata);

        //JSONファイルに書き込み
        writer = new StreamWriter(datapath, false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    //JSONファイルを読み込み, ロードするための関数
    public ScoreData loadData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(datapath);
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<ScoreData>(datastr);
    }

    //JSONファイルがない場合に呼び出す初期化関数
    //初期値をセーブし, JSONファイルを生成する
    public void Initialize(ScoreData scoredata)
    {
        //ステージ１
        scoredata.Stage1_1stPayment = 1;
        scoredata.Stage1_1stLank = "-";

        scoredata.Stage1_2ndPayment = 0;
        scoredata.Stage1_2ndLank = "-";

        scoredata.Stage1_3rdPayment = 0;
        scoredata.Stage1_3rdLank = "-";

        //ステージ２
        scoredata.Stage2_1stPayment = 0;
        scoredata.Stage2_1stLank = "-";

        scoredata.Stage2_2ndPayment = 0;
        scoredata.Stage2_2ndLank = "-";

        scoredata.Stage2_3rdPayment = 0;
        scoredata.Stage2_3rdLank = "-";

        //ステージ３
        scoredata.Stage3_1stPayment = 0;
        scoredata.Stage3_1stLank = "-";

        scoredata.Stage3_2ndPayment = 0;
        scoredata.Stage3_2ndLank = "-";

        scoredata.Stage3_3rdPayment = 0;
        scoredata.Stage3_3rdLank = "-";

        saveData(scoredata);
    }

    //JSONファイルの有無を判定するための関数
    public bool FindJsonfile()
    {
#if UNITY_EDITOR
        string[] assets = AssetDatabase.FindAssets(datapath);
        Debug.Log(assets.Length);
        if (assets.Length != 0)
        {
            string[] paths = assets.Select(guid => AssetDatabase.GUIDToAssetPath(guid)).ToArray();
            Debug.Log($"検索結果:\n{string.Join("\n", paths)}");
            return true;
        }
        else
        {
            Debug.Log("Jsonファイルがなかった");
            return false;
        }
#endif 
        return false;
    }

    //Playerのデータとなるクラスの定義
    [System.Serializable]
    public class ScoreData
    {
        //ステージ１
        public int Stage1_1stPayment;
        public string Stage1_1stLank;

        public int Stage1_2ndPayment;
        public string Stage1_2ndLank;

        public int Stage1_3rdPayment;
        public string Stage1_3rdLank;

        //ステージ２
        public int Stage2_1stPayment;
        public string Stage2_1stLank;

        public int Stage2_2ndPayment;
        public string Stage2_2ndLank;

        public int Stage2_3rdPayment;
        public string Stage2_3rdLank;

        //ステージ３
        public int Stage3_1stPayment;
        public string Stage3_1stLank;

        public int Stage3_2ndPayment;
        public string Stage3_2ndLank;

        public int Stage3_3rdPayment;
        public string Stage3_3rdLank;
    }
}

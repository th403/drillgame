using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearZone : MonoBehaviour
{
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerCtrl2.Instance.PlayerGetLava();
            SceneManager.LoadScene(NextScene);
        }
    }



}

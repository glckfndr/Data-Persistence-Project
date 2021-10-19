using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;


    public Text ScoreText;
    public GameObject GameOverText;

   // [SerializeField]
   // private InputField _logInputField;
    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

  //  private List<Person> _persons;
    private object _fileName = "/savefile.json";
    public static MainManager Instance;
  //  private Person _currentPerson;
    private bool isBuild = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
       // LoadScore();
    }


    // Start is called before the first frame update
    private void Start()
    {
       // _persons = new List<Person>();
        //if (_persons != null)
            CreateBricks();
        //Debug.Log(_currentPerson);

    }

    private void CreateBricks()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

    }

    private void Update()
    {
        //if (!isBuild && _currentPerson != null)
        //{
        //    isBuild = true;
        //    CreateBricks();

        //}
        //if (_currentPerson == null)
        //{
        //    _logInputField.gameObject.SetActive(true);

        //}
         if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void GetLogin(string login)
    {
        //if (login != null)
        //{
        //    _currentPerson = new Person(_logInputField.text, 0);
        //    _logInputField.gameObject.SetActive(false);
        //    // if (_currentPerson != null)
        //    //   CreateBricks();
        //    SceneManager.LoadScene(1);


        //}

    }

    //[Serializable]
    //private class SaveData
    //{



    //}

    //[Serializable]
    //private class Person
    //{
    //    private string _login;
    //    private int _score;

    //    public Person(string login, int score)
    //    {
    //        _login = login;
    //        _score = score;
    //    }
    //}

    //public void SaveScore()
    //{
    //    string jsong = JsonUtility.ToJson(_persons);
    //    File.WriteAllText(Application.persistentDataPath + _fileName, jsong);
    //}

    //public void LoadScore()
    //{
    //    string path = Application.persistentDataPath + _fileName;
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        _persons = JsonUtility.FromJson<List<Person>>(json);


    //    }
    //}




}

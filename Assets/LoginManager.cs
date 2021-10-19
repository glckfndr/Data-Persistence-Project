using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InputField _loginField;
    private List<Gamer> _gamers;
    private Gamer _currentGamer = null;
    public LoginManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    
    private void Start()
    {
        LoadGamers();
        if (_currentGamer == null)
        {
            _loginField.gameObject.SetActive(true);
        }
    }

    private void LoadGamers()
    {
     //   throw new NotImplementedException();
    }

    public void SetGamer()
    {
        if (_loginField.text != null)
        {
            foreach (var gamer in _gamers)
            {
                if (gamer.Name == _loginField.text)
                {
                    _currentGamer = gamer;
                    return;
                }

                _currentGamer = new Gamer(_loginField.text);
                _gamers.Add(_currentGamer);
                SceneManager.LoadScene(1);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }

    [Serializable]
    public class Gamer
    {
        public Gamer(string name)
        {
            Name = name;
            Score = 0;
        }
        public readonly string Name;
        public int Score;

    }
}

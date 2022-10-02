using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject dieFlash;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;

    public bool isDead { get; set; } = false;

    private int _score;
    public int score
    {
        get { return _score; }
    }
    private float _speed = 2f;

    public float speed
    {
        get { return _speed; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Assert(instance != null);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            dieFlash.SetActive(true);
            gameOverUI.SetActive(true);
            return;
        }

        scoreText.text = "score : " + score;
    }

    public void addScore() { _score++; }

    public void addSpeed() { _speed *= 1.01f; }
}

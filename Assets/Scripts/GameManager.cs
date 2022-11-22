using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController.Color color;
    public static GameManager instance;

    public bool GameStart { get; set; } = false;
    public bool IsDead { get; set; } = false;
    private int Score { get; set; } = 0;
    [field: SerializeField]
    public float Speed { get; private set; } = 2f;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject dieFlash;
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject pannel;

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
        if (IsDead)
        {
            return;
        }

        scoreText.text = "score : " + Score;
    }

    public void AddScore() { Score++; }

    public void AddSpeed() { Speed *= 1.01f; }

    public void Die()
    {
        dieFlash.SetActive(true);
        gameOverUI.SetActive(true);
    }

    public void CharacterSelect(PlayerController.Color color)
    {
        player.SetActive(true);
        playerController.SetColor(color);
        pannel.SetActive(false);
        GameStart = true;
    }
}

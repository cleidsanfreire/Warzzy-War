using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private Image heartHorizBar;
    [SerializeField] private TextMeshProUGUI textCoin;
    [SerializeField] private TextMeshProUGUI textApple;
    [SerializeField] private TextMeshProUGUI textPineapple;
    [SerializeField] private TextMeshProUGUI textKeys;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        textCoin.text = 0.ToString();
        textApple.text = 0.ToString();
        textPineapple.text = 0.ToString();
        textKeys.text = 0.ToString();
        heartHorizBar.fillAmount = 1f;


        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            playerController = playerObject.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        textCoin.text = playerController.totalCoinPoints.ToString();
        textApple.text = playerController.TotalApplePoints.ToString();
        textPineapple.text = playerController.TotalPineapplesPoints.ToString();
        textKeys.text = playerController.totalKeyPoints.ToString();

        heartHorizBar.fillAmount = playerController.CurrentlifePlayer / playerController.LifePlayer;

    }
}

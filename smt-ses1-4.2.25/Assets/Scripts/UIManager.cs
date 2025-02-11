using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool DebuggingTool = true;
    public static UIManager instance;
    public Image healthBar;
    public Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Output line to debug log as game cannot quit in engine preview
            if (DebuggingTool == true)
            {
                Debug.Log("The game will Quit.");
            }
            Application.Quit();
        }

    }

    //custom health update function
    public void UpdateHealth(PlayerHealth health)
    {
        healthBar.fillAmount = health.playerCurrentHealth / health.playerMaxHealth;
        if (health.playerCurrentHealth > 0)
        {
            healthText.text = "Health" + health.playerCurrentHealth;
        }
        else
        {
            healthText.text = "You Died";
        }

    }
}

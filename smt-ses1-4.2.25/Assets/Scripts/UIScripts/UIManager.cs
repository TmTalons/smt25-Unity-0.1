using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class UIManager : MonoBehaviour
{
    public bool DebuggingTool = true;
    public static UIManager instance;
    public Image healthBar;
    public Text healthText;
    public Image reloadBar;
    public Text equippedGun;
    public Image chargeBar;

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

    public void UpdateReloadBar(GunFunctionality reload)
    {
        reloadBar.fillAmount = reload.reloadTimeR/reload.reloadT;
        if (reload.reloadTimeR == reload.reloadT)
        {
            reloadBar.fillAmount = 0;
        }
    }

    public void UpdateChargeBar(GunFunctionality chargeAmount)
    {
        chargeBar.fillAmount = chargeAmount.charge / chargeAmount.maxCharge;
        
    }
}

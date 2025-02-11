using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool DebuggingTool = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}

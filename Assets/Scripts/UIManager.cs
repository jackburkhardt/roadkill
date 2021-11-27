using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private Text gameText;
    [SerializeField] private Text buttonText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCanvas(bool val, bool win)
    {
        if (win)
        {
            buttonText.text = "PLAY AGAIN?";
            gameText.text = "DUCKS SAVED!";
        }
        Canvas.enabled = val;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        var thisScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(thisScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonHandler : MonoBehaviour
{
   public void LoadStartScene()
    {
        SceneManager.LoadScene("start");
    }
}

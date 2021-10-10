using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] public Button button;

    [SerializeField] public int sceneSelection;

    private void Start()
    {
        button.onClick.AddListener(() =>
            {
                SetButtonInteractAble(false);
                SceneManager.LoadScene(sceneSelection);
            });
    }

    private void SetButtonInteractAble(bool interactable)
    {
        button.interactable = interactable;
    }


}

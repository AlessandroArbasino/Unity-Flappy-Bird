using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    void Start()
    {
        button.onClick.AddListener(delegate { BackTomainMenuMethod(); });
    }

    private void BackTomainMenuMethod()
    {
        transform.parent.gameObject.SetActive(false);
    }
}

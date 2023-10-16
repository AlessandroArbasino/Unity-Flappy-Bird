using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AcivatePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    private Button button;
    // Start is called before the first frame update
    private void Awake()
    {
        button= GetComponent<Button>();
    }
    void Start()
    {
        button.onClick.AddListener(delegate { SetPanelActive(); });
      
    }

    void SetPanelActive()
    {
        panel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveViewGiver : MonoBehaviour
{

    [SerializeField]
    private GameObject _view_pane;

    private GameObject _view_pane_instance;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == null || _view_pane_instance != null)
        {
            return;
        }

        _view_pane_instance = Instantiate(_view_pane, Camera.main.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() == null || _view_pane_instance == null)
        {
            return;
        }

        Destroy(_view_pane_instance);
        _view_pane_instance = null;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WSMGameStudio;

public class Demo : MonoBehaviour
{
    public Chest _chestScript;
    public Toggle _showKeyAnimation;
    public Dropdown _keyDropDown;
    public List<GameObject> _keysPrefabs;
    public List<GameObject> _cameras;

    public void OnOpen_Click()
    {
        _showKeyAnimation.interactable = false;
        _keyDropDown.interactable = false;
        _chestScript.Open();
    }

    public void OnClose_Click()
    {
        _showKeyAnimation.interactable = true;
        _keyDropDown.interactable = true;
        _chestScript.Close();
    }

    public void OnAnimationDropDown_ValueChanged(int newValue)
    {
        _chestScript._openingDegrees = (Enums.OpeningDegrees)newValue;
    }

    public void OnShowKeyAnimation_ValueChanged(bool newValue)
    {
        _chestScript._showKeyAnimation = newValue;
    }

    public void OnKeyDropDown_ValueChanged(int newValue)
    {
        _chestScript._keyPrefab = _keysPrefabs[newValue];
        _chestScript.UpdateKey();
    }

    public void OnCameraDropDown_ValueChanged(int newValue)
    {
        for (int i = 0; i < _cameras.Count; i++)
        {
            if (i == newValue)
                _cameras[i].SetActive(true);
            else
                _cameras[i].SetActive(false);
        }
    }
}

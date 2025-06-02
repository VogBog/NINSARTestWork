using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UI
{
    [SerializeField] private Button _persistentBtn;
    [SerializeField] private Button _resourcesBtn;
    [SerializeField] private TMP_Text _positionText;

    private Map _map;
    private FileReader _fileReader;

    public void Initialize(Map map, FileReader fileReader)
    {
        _map = map;
        _fileReader = fileReader;
        
        _persistentBtn.onClick.AddListener(OnPersistentBtnClicked);
        _resourcesBtn.onClick.AddListener(OnResourcesBtnClicked);
        _map.AreaChanged += _ => OnAreaChanged();
    }

    private void OnPersistentBtnClicked()
    {
        _map.SetNumbers(_fileReader.ReadFromPersistentFile());
    }

    private void OnResourcesBtnClicked()
    {
        _map.SetNumbers(_fileReader.ReadFromResourcesFile());
    }

    private void OnAreaChanged()
    {
        _positionText.text = _map.Center.ToString();
    }
}
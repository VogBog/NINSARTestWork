using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ReadFileView
{
    [SerializeField] private Button _persistentBtn;
    [SerializeField] private Button _resourcesBtn;

    private Map _map;
    private FileReader _fileReader;

    public void Initialize(Map map, FileReader fileReader)
    {
        _map = map;
        _fileReader = fileReader;
        _persistentBtn.onClick.AddListener(OnPersistentBtnClicked);
        _resourcesBtn.onClick.AddListener(OnResourcesBtnClicked);
    }

    private void OnPersistentBtnClicked()
    {
        _map.SetNumbers(_fileReader.ReadFromPersistentFile());
    }

    private void OnResourcesBtnClicked()
    {
        _map.SetNumbers(_fileReader.ReadFromResourcesFile());
    }
}
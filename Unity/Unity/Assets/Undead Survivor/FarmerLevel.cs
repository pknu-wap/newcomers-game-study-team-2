using UnityEngine;

public class FarmerLevel : MonoBehaviour
{
    [SerializeField] private GameObject LevelUpPanel;
    private int _currentExp;
    private int _level = 1;
    private int _maxExp = 50;

    public void AddExp(int exp)
    {
        _currentExp += exp;
        while (_currentExp >= _maxExp)
        {
            _currentExp -= _maxExp;
            _level++;
            _maxExp = _level * 50;
            LevelUpPanel.SetActive(true);
            TimeController.PauseGame();
        }
        Debug.Log("레벨: " + _level + " 경험치: " + _currentExp);
        

    }
    public void LevelUp(int index)
    {
        LevelUpPanel.SetActive(false);
        TimeController.ResumeGame();
    }
}
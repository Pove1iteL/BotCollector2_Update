using UnityEngine;
using UnityEngine.Events;

public class BaseBuilerSystem : MonoBehaviour
{
    [SerializeField] private Base _basePrefab;

    public event UnityAction NewBaseBuilded;

    private Base _base;

    public void CreateBase(Transform placePosition)
    {
        Base newBase = Instantiate(_basePrefab, placePosition.position, Quaternion.identity);
        _base = newBase;
        Debug.Log(_base.name);
        _base.StartWithBot(false);

        NewBaseBuilded?.Invoke();
    }

    public void SetBaseChildren(BotMover bot)
    {
        _base.AddBot(bot);
        bot.transform.SetParent(_base.transform);
        bot.Init(_base.GetComponentInChildren<ResourceCollector>().transform, _base, _base.transform.position);
        bot.RemoveTargetFlag();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class BuildBaseSystem : MonoBehaviour
{
    [SerializeField] private Base _basePrefab;

    private Base _base;

    public event UnityAction NewBase;

    public void CreateBase(Transform placePosition)
    {
        Base newBase = Instantiate(_basePrefab, placePosition.position, Quaternion.identity);
        _base = newBase;
        Debug.Log(_base.name);
        _base.StartWithBot(false);

        NewBase?.Invoke();
    }

    public void SetBaseChildren(BotMover bot)
    {
        _base.AddBot(bot);
        bot.transform.SetParent(_base.transform);
        bot.Init(_base.GetComponentInChildren<CollectionResource>().transform, _base, _base.transform.position);
        bot.RemoveTargetFlag();
    }

}

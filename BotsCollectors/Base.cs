using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private DetectedResource _detectedResource;
    [SerializeField] private BotMover _botMoverPref;
    [SerializeField] private CollectionResource _collectionResource;
    [SerializeField] private Transform _spavnPoint;
    [SerializeField] private Transform _basket;
    [SerializeField] private bool _isHaveBot = false;

    [SerializeField] private BaseControllerFlag _controllerFlag;
    [SerializeField] private BuildBaseSystem _buildBase;

    private readonly List<BotMover> _bots = new List<BotMover>();
    private int _maxBotsCount = 5;
    private int _botPrice = 3;
    private int _basePrice = 5;

    public Transform Flag { get; private set; }


    private void Start()
    {
        StartWithBot(_isHaveBot);
    }

    public void AddBot(BotMover bot)
    {
        _bots.Add(bot);
    }

    public void StartWithBot(bool IsHaweBot)
    {
        if (IsHaweBot)
        {
            CreateBot();
        }
    }

    public bool TryGetResource(out Resource resource)
    {
        if (_detectedResource.TryGetResource(out resource))
        {
            return true;
        }

        return false;
    }

    private void Update()
    {
        if (_controllerFlag.IsFlagPlaced)
        {
            if (_collectionResource.QuantityResources >= _basePrice)
            {
                Flag = _controllerFlag.Flag.transform;
                _bots[0].SetTargetFlag();

                if (_bots[0].transform.position == Flag.position)
                {
                    ChangeBase();
                }
            }
        }
        else
        {
            BuyNewBot();
        }
    }

    private void ChangeBase()
    {
        _collectionResource.TakeQuantityResource(_basePrice);

        _buildBase.CreateBase(Flag);

        _controllerFlag.RemoveFlag();
        _controllerFlag.Flag.gameObject.SetActive(false);

        _buildBase.SetBaseChildren(_bots[0]);
        _bots.Remove(_bots[0]);        
    }

    private void CreateBot()
    {
        BotMover bot = Instantiate(_botMoverPref, _spavnPoint);
        _bots.Add(bot);

        bot.Init(_basket, this, _spavnPoint.position);
    }

    private void BuyNewBot()
    {
        if (_collectionResource.QuantityResources >= _botPrice && _bots.Count < _maxBotsCount)
        {
            CreateBot();
            _collectionResource.TakeQuantityResource(_botPrice);
        }
    }


}
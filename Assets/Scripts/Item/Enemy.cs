using System;
using DG.Tweening;
using Managers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AnimalManager _animalManager;
    private GameObject _item;
    private int _itemId;
    private Obstacle _obstacle;
    private bool _didTrigger;

    private void Awake()
    {
        _obstacle = GetComponent<Obstacle>();
    }

    public void SetItem(GameObject item)
    {
        _item = item;
    }

    public void SetItemId(int itemId)
    {
        _itemId = itemId;
    }

    public void SetAnimalManager(AnimalManager animalManager)
    {
        _animalManager = animalManager;
    }

    public GameObject GetItem()
    {
        return _item;
    }

    public void MoveTowards()
    {
        var goTo = new Vector3(transform.position.x, transform.position.y, -1.25f);
        transform.DOLocalMove(goTo, 4f).OnComplete(OnComplete);
        _item.transform.gameObject.SetActive(false);
    }

    private void OnComplete()
    {
        if (!_didTrigger)
        {
            FindObjectOfType<UIManager>().OnLose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            var item = other.GetComponent<Item>();

            if (item)
            {
                if (item.Rank == _itemId)
                {
                    item.gameObject.SetActive(false);
                    _obstacle.ManualLerp();
                    _didTrigger = true;
                    
                    _animalManager.OnEnemyDefeat();
                }
            }
        }
    }
}
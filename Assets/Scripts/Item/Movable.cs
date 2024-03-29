using System;
using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Camera Camera { get; set; }
    public CellManager CellManager { get; set; }
    
    private Vector3 _mOffset;
    private float _mZCoord;
    private Vector3 _positionBeforeDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        var currentPos = transform.position;
        _mZCoord = Camera.WorldToScreenPoint(currentPos).z;
        
        _mOffset = currentPos - GetMouseAsWorldPoint(eventData.position);
        CellManager.OnItemPick(currentPos);
        _positionBeforeDrag = currentPos;
    }
    
    private Vector3 GetMouseAsWorldPoint(Vector3 mousePoint)
    {
        mousePoint.z = _mZCoord;
        
        return Camera.ScreenToWorldPoint(mousePoint);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var goTo = GetMouseAsWorldPoint(eventData.position) + _mOffset;
        goTo = new Vector3(goTo.x, _positionBeforeDrag.y, goTo.z);
        transform.DOMove(goTo, 0.1f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CellManager.OnItemDrop(transform, transform.position, _positionBeforeDrag);
    }
}
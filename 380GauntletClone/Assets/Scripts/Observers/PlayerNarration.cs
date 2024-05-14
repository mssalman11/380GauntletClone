using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarration : MonoBehaviour, IObserver
{
    [SerializeField]
    PlayerSubject _playerSubject;

    [SerializeField]
    GameObject _gotKeyUIElement;

    [SerializeField]
    GameObject _gotFoodUIElement;

    [SerializeField]
    GameObject _gotTreasureUIElement;

    [SerializeField]
    GameObject _gotHitUIElement;

    public void OnNotify(PlayerActions action)
    {
        if (action == PlayerActions.gotKey)
        {
            Debug.Log("Key Picked Up");
            _gotKeyUIElement.SetActive(true);
        }

        if (action == PlayerActions.gotTreasure)
        {
            Debug.Log("Key Picked Up");
            _gotTreasureUIElement.SetActive(true);
        }

        if (action == PlayerActions.gotHit)
        {
            Debug.Log("Key Picked Up");
            _gotHitUIElement.SetActive(true);
        }

        if (action == PlayerActions.gotFood)
        {
            Debug.Log("Key Picked Up");
            _gotFoodUIElement.SetActive(true);
        }

    }

    private void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }
}

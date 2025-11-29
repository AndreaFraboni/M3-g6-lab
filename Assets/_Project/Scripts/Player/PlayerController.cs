using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 6.0f;

    private Mover2D _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Debug.Log($"INPUT H: {h}, V: {v}");


        Vector2 input = new Vector2(h, v);

        _mover.SetSpeed(_speed);
        _mover.SetAndNormalizeInput(input);
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}

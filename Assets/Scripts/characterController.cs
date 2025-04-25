using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float walkSpeed = 5.0f;       // Normal yürüyüş hızı
    public float runSpeed = 10.0f;       // Space tuşuna basıldığında koşma hızı
    public float currentSpeed;           // Anlık hız

    private Animator _animator;
    private Rigidbody2D r2d;
    [SerializeField] private GameObject _camera;  // Kamera referansı

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentSpeed = walkSpeed;  // Başlangıçta yürüme hızı
    }

    void Update()
    {
        // Space tuşuna basıldığında koşma moduna geç
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = runSpeed;  // Koşma modu
        }
        else
        {
            currentSpeed = walkSpeed;  // Normal yürüme modu
        }

        // Animator ile hız bilgisini güncelle
        _animator.SetFloat("speed", Mathf.Abs(r2d.velocity.x));

        // Kamera karakteri takip eder
        if (_camera != null)
        {
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}



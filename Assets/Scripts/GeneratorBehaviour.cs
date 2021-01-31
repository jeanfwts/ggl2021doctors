using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBehaviour : Kindlable
{
    [SerializeField] float rechargingDelay;

    //private static Color LIGHT_BLUE = new Color(61, 98, 188);
    //private static Color LIGHT_YELLOW = new Color(179, 231, 99);

    private Animator _generatorAnimator;
    private float _rechargingRemainingTime = 0f;
    private bool _turnOff = true;
    private GameObject _player;
     

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _generatorAnimator = GetComponent<Animator>();
        initKindlable();
    }

    private void Update()
    {
        if(_rechargingRemainingTime > 0f)
        {
            _rechargingRemainingTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D collider = collision.GetComponent<Collider2D>();
        if (collider.tag == "projectile")
        {
             _generatorAnimator.SetTrigger("LitUp");
            if (_turnOff)
            {
                _turnOff = false;
                Kindle();
            }
        }

        if (collider.tag == "Player")
        {
            GameLevelManager.INSTANCE.checkPointPos = transform.position;
            _generatorAnimator.SetTrigger("LitUp");
            if (_turnOff)
            {
                _turnOff = false;
                Kindle();
            }
            if (_rechargingRemainingTime <= 0f)
            {
                CharracterAction charAction = _player.GetComponent<CharracterAction>();
                _rechargingRemainingTime = rechargingDelay;
                _generatorAnimator.SetTrigger("Charge");
                charAction.refill();
            }
            
        }
    }
}

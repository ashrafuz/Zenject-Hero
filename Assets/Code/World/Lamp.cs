﻿using UnityEngine;
using Zenject;

namespace Code
{
    public class Lamp : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
//        private LightsOutSignal _lightsOutSignal;

//        [Inject]
//        public void Construct(LightsOutSignal lightsOutSignal)
//        {
//            _lightsOutSignal = lightsOutSignal;
//        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<PlayerFacade>())
            {
                _signalBus.Fire(new LightsOutSignal());
            }
        }
    }
}
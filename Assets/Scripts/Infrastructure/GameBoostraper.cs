﻿using UnityEngine;

namespace Infrastructure
{
    public class GameBoostraper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            
            DontDestroyOnLoad(this);
        }
    }
}
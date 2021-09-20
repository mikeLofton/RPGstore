using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RPGstore
{
    struct Item
    {
        public string Name;
        public int Cost;
    }

    class Game
    {
        private Player _player;
        private Shop _shop;     
        private bool _gameOver = false;
        private int _currentScene = 0;

        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Update();
            }

            End();
        }

        private void Start()
        {
            
        }

        private void Update()
        {

        }

        private void End()
        {
            Console.WriteLine("Have a nice day! :)");
            Console.ReadKey(true);
        }

        private void InitializeItems()
        {

        }

        private int GetInput(string description, params string[] options)
        {

        }
    }
}

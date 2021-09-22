﻿using System;
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
            string choice = "";
            int inputRecieved = -1;

            while (inputRecieved == -1)
            {
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.Write("> ");

                choice = Console.ReadLine();

                if (int.TryParse(choice, out inputRecieved))
                {
                    inputRecieved--;
                    if (inputRecieved < 0 || inputRecieved >= options.Length)
                    {
                        inputRecieved = -1;
                        //Display error message
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    inputRecieved = -1;
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey(true);
                }

                Console.Clear();
            }

            return inputRecieved;
        }
        
    }
}

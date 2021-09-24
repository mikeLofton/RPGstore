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
        private Item _sword;
        private Item _shield;
        private Item _healthPotion;
        private Item[] _shopInventory;
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
            _player = new Player();
            InitializeItems();
            _shop = new Shop(_shopInventory);
        }

        private void Update()
        {
            DisplayCurrentScene();
            Console.Clear();
        }

        private void End()
        {
            Console.WriteLine("Have a nice day! :)");
            Console.ReadKey(true);
        }

        private void InitializeItems()
        {
            //Shop Items 
            _sword = new Item { Name = "Shiny Sword", Cost = 500 };
            _shield = new Item { Name = "Big Shield", Cost = 100 };
            _healthPotion = new Item { Name = "Health Potion", Cost = 15 };

            //Initialize Array
            _shopInventory = new Item[] { _sword, _shield, _healthPotion };
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

        private void Save()
        {

        }

        private bool Load()
        {
            return true;
        }

        private void DisplayCurrentScene()
        {
            switch (_currentScene)
            {
                case 0:
                    DisplayOpeningMenu();
                    break;

                case 1:
                    DisplayShopMenu();
                    break;

                default:
                    Console.WriteLine("Invalid scene index");
                    break;
            }
        }

        private void DisplayOpeningMenu()
        {
            int choice = GetInput("Welcome to My Shop. What're ya here for?", "Start Shopping", "Load Inventory");

            if (choice == 0)
            {
                _currentScene = 1;
            }
            else if (choice == 1) 
            { 
                if (Load())
                {
                    Console.WriteLine("Load Successful");
                    Console.ReadKey(true);
                    Console.Clear();
                    _currentScene = 1;
                }
                else
                {
                    Console.WriteLine("Load Failed");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }

        private string[] GetShopMenuOptions()
        {
            string[] itemsForSale = new string[_shopInventory.Length];
            string[] menuOptions = new string[_shopInventory.Length];

            for (int i = 0; i < _shopInventory.Length; i++)
            {
                itemsForSale[i] = _shopInventory[i].Name;
            }
        
            return itemsForSale;
        }

        private void DisplayShopMenu()
        {
            Console.WriteLine("Your gold: " + _player.Gold);
            Console.WriteLine("Your Inventory: " + "\n");

            int choice = GetInput("What're ya buying", _sword.Name, _shield.Name, _healthPotion.Name, "Save", "Quit");

            if (choice == 0)
            {
                _shop.Sell(_player, 0);
            }
            else if (choice == 1)
            {
                _shop.Sell(_player, 1);
            }
           
        }
      
    }
}

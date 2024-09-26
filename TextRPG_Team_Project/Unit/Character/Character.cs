using System;
using TextRPG_Team_Project;
namespace TextRPG_Team_Project
{

    public class Character : IUnit
    {

        public string Name { get; }
        public int Level { get; }
        public int Health { get; }
        public int Attack { get; }
        public int Defense { get; }
        public bool IsDead { get; }

       
        public void TakeDamage(int damage)
        {
            

        }

        

        public Character()
        {

            



        }



     




    }
   
    
    



}
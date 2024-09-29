using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project
{
    public class Mage : Character // 마법사 클래스
    {
        
        public Mage(String _name, int _level, int _health, int _attack, int _defense, int _mp) : base(_name, _level, _health, _attack, _defense , _mp)
        {
            Job = "마법사";
           

        }

       
    
      

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TextRPG_Team_Project
{
    public class Skill
    {
        public float DamageMulti { get; private set; }

        public string Description { get; private set; }

        public string Name { get; private set; }

        public int ManaCost { get; private set; }  

        public int SkillType { get; private set; }

        public Skill(string name, float damageMulti, string description,int manaCost, int skillType)
        {
            Name = name;
            DamageMulti = damageMulti;
            Description = description;
            ManaCost = manaCost;
            SkillType = skillType; 
        }

        public int GetSkillType()
        {

            return SkillType;
        }




    }
}

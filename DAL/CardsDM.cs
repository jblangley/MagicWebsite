using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CardsDM
    {
        public int ID { get; set; }
        public string PictureURL { get; set; }
        public string Name { get; set; }
        public int CMC { get; set; }
        public string CardColor { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public string Cardtype { get; set; }
        public string Subtype { get; set; }
        public string Ability { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string Flavortext { get; set; }

        public CardsDM() { }
    }
}

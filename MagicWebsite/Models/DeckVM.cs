using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicWebsite.Models
{
    public class DeckVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CardCount { get; set; }

        public DeckVM() { }
    }
}
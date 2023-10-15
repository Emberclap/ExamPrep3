﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }
        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }
        public bool RemoveCloth(string color) => Clothes.Remove(Clothes.FirstOrDefault(x => x.Color == color));

        public Cloth GetSmallestCloth()
        {
            Cloth smallestBySize = Clothes.MinBy(x => x.Size);
            return smallestBySize;
        }
        public Cloth GetCloth(string color)
        {
            return Clothes.FirstOrDefault(x => x.Color == color);
        }
        public int GetClothCount()
        {
            return Clothes.Count;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");
            foreach (var cloth in Clothes.OrderBy(x => x.Size))
            {
                sb.AppendLine(cloth.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class SpecialCard : Card
    {
        //Atributos
        private string buffType;

        //Propiedades
        public string BuffType
        {
            get
            {
                return this.buffType;
            }
            set
            {
                this.buffType = value;
            }
        }
        //Constructor
        public SpecialCard(string name, string type, string effect)
        {
            Name = name;
            Type = type;
            Effect = effect;
            BuffType = null;
        }

        //Propiedades
        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public override string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        public override string Effect
        {
            get
            {
                return this.effect;
            }
            set
            {
                this.effect = value;
            }
        }
    }
}

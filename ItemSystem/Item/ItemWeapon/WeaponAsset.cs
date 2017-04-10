﻿using UnityEngine;
using System.Collections;

namespace Systems.ItemSystem
{
    [System.Serializable]
    public class WeaponAsset : ItemAsset
    {
        [SerializeField]
        private int _durability;
        [SerializeField]
        private bool _equipable;
        [SerializeField]
        private WeaponType _wType;
        [SerializeField]
        private int _attackRange;
        [SerializeField]
        private int _power;
        [SerializeField]
        private float _force;

        private int _currentDurablity;

        #region GETTERS AND SETTERS
        public int Durability
        {
            get
            {
                return _durability;
            }

            set
            {
                _durability = value;
            }
        }

        public int CurrentDurablity
        {
            get
            {
                return _currentDurablity;
            }

            set
            {
                _currentDurablity = value;
            }
        }

        public bool Equipable
        {
            get
            {
                return _equipable;
            }

            set
            {
                _equipable = value;
            }
        }

        public WeaponType WType
        {
            get
            {
                return _wType;
            }

            set
            {
                _wType = value;
            }
        }

        public int AttackRange
        {
            get
            {
                return _attackRange;
            }

            set
            {
                _attackRange = value;
            }
        }

        public float Force
        {
            get
            {
                return _force;
            }
            set
            {
                _force = value;
            }
        }

        public int Power
        {
            get
            {
                return _power;
            }

            set
            {
                _power = value;
            }
        }
        #endregion

        public WeaponAsset() : base (){
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.Power = 0;
        }

        public WeaponAsset(int id) : base (id)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.Power = 0;
        }


        public WeaponAsset(int id, string name) : base (id, name)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.Power = 0;
        }

        public WeaponAsset(int id, string name, float weight, string description, bool stackable, int stackSize, Sprite icon, int level, int cost) : base(id, name, weight, description, stackable, stackSize, icon, level, cost)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.Power = 0;
        }

        public WeaponAsset(int id, string name, float weight, string description, bool stackable, int stackSize, Sprite icon, int level, int cost, int durability, bool equipable, WeaponType wType, int attackRange, int power, float force) : base(id, name, weight, description, stackable, stackSize, icon, level, cost)
        {
            this.Durability = durability;
            this.Equipable = equipable;
            this.IType = ItemType.Weapon;
            this.WType = wType;
            this.AttackRange = attackRange;
            this.Power = power;
            this.Force = force;
        }
    }
}
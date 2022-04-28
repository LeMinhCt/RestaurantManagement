﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Staff
    {
        private int iD;
        private string name;
        private string gender;
        private DateTime birthday;
        private string address;
        private string phoneNumber;
        private double salary;
        private string image;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }

        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Image { get => image; set => image = value; }
        public double Salary { get => salary; set => salary = value; }
        public string Gender { get => gender; set => gender = value; }

        public Staff(int iD, string name, string gender, DateTime birthday, string address, string phoneNumber, double salary, string image)
        {
            this.iD = iD;
            this.name = name;
            this.gender = gender;
            this.birthday = birthday;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.salary = salary;
            this.image = image;
        }

        public Staff(string name, string gender, DateTime birthday, string address, string phoneNumber)
        {
            this.name = name;
            this.gender = gender;
            this.birthday = birthday;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public Staff()
        {
        }
    }
}
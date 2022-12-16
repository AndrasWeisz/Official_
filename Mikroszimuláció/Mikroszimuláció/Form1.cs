using Mikroszimuláció.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroszimuláció
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();


        public Form1()
        {
            InitializeComponent();

            people = GetPeople(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }
        
        public  List<Person> GetPeople(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    people.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender),line[1]),
                        NbrOfChildren = byte.Parse(line[2])

                    }
                        );
                }
            }
            return people;
        }

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    BirthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren2 = int.Parse(line[1]),
                        ProbOfBirth = double.Parse(line[2])

                    }
                        );
                }
            }
            return BirthProbabilities;
        }

        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    DeathProbabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        ProbOfDeath = double.Parse(line[2])

                    }
                        );
                }
            }
            return DeathProbabilities;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

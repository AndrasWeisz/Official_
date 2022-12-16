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

        Random rng = new Random(1234);


        public Form1()
        {
            InitializeComponent();

            people = GetPeople(@"C:\Users\weisz\AppData\Local\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Users\weisz\AppData\Local\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Users\weisz\AppData\Local\Temp\halál.csv");

            for (int year = 2005; year <= 2024; year++)
            {
                for (int i = 0; i < people.Count; i++)
                {

                }
                int NmrOfMales = (from p in people where p.Gender == Gender.Male && p.IsAlive select p).Count();
                int NmbrOfFemales = (from p in people where p.Gender == Gender.Female && p.IsAlive select p).Count();
                Console.WriteLine(String.Format("Év: {0} Fiúk: {1} Lányok: {2}", year, NmrOfMales, NmbrOfFemales));
            }
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

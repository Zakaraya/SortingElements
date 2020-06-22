using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace SortingElements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> ListElements = new List<int>(9000000);
        Dictionary<int, int> DictionaryElements = new Dictionary<int, int>(9000000);
        int[] ArrayElements = new int[9000000];

        public List<int> CreateList()
        {
            for (int i = 0; i < 9000000; i++)
            {
                ListElements.Add(i);
            }
            return ListElements;
        }

        //в списке в листе использовать contains
        //в массиве array и его метод indexof
        //в словаре через containskey 
        public Dictionary<int, int> CreateDictionary()
        {
            Dictionary<int, int> newdictionary = new Dictionary<int, int>(9000000);
            for (int i = 0; i < 9000000; i++)
            {
                newdictionary.Add(i, i + 1);
            }
            return DictionaryElements;
        }

        public int[] CreateMas()
        {
            for (int i = 0; i < 9000000; i++)
            {
                ArrayElements[i] = i;
            }
            return ArrayElements;
        }

        public double SearchInList(List<int> List, int El)
        {
            Stopwatch Time = new Stopwatch();
            Time.Start();
            List.Contains(El);
            Time.Stop();
            return Time.Elapsed.TotalMilliseconds;
        }

        public double SearchInDict(Dictionary<int, int> Dictionary, int El)
        {
            Stopwatch Time = new Stopwatch();
            Time.Start();
            Dictionary.ContainsKey(El);
            Time.Stop();
            return Time.Elapsed.TotalMilliseconds;
        }
        public double SearchInMas(int[] Mas, int El)
        {
            Stopwatch Time = new Stopwatch();
            Time.Start();
            Array.IndexOf(Mas, El);
            Time.Stop();
            return Time.Elapsed.TotalMilliseconds;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListOutput.Items.Clear();
            Random random = new Random();
            int Element = random.Next(0, 9000000);
            for (int i = 0; i < 90000; i++)
            {
                Element = i;
            }
            List<int> List = CreateList();
            //  Dictionary<int, int> Dictionary = CreateDictionary();
            int[] Array = CreateMas();
            Chart.Series[0].Points.Clear();
            ListOutput.Items.Insert(0, "List - " + SearchInList(List, Element).ToString());
            ListOutput.Items.Insert(1, "Dictionary - " + SearchInDict(DictionaryElements, Element).ToString());
            ListOutput.Items.Insert(2, "Array - " + SearchInMas(Array, Element).ToString());
            Chart.Series[0].Points.AddXY("List", SearchInList(List, Element).ToString());
            Chart.Series[0].Points.AddXY("Dictionary", SearchInDict(DictionaryElements, Element).ToString());
            Chart.Series[0].Points.AddXY("Array", SearchInMas(Array, Element).ToString());
        }
    }
}




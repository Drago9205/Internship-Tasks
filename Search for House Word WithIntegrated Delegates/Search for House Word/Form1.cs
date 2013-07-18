using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Search_for_House_Word
{
    public partial class searchForHouse : Form
    {
        public searchForHouse()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //searchHouseButton.Click += new EventHandler(searchHouseButton_Click);
            //SearchButtonClickedEvent += new SearchButtonClickHandler(OnSearchButtonClick);
            searchHouseButton.Click += new EventHandler(searchHouseButton_Click);
        }

        void searchHouseButton_Click(object sender, EventArgs e)
        {
            OnSearchButtonClick(inputBox.Text);
            //SearchButtonClickedEvent(inputBox.Text);
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                inputBox.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        
        static int counter = 0;
        //public delegate void SearchButtonClickHandler(EventArgs e);
        //public event SearchButtonClickHandler SearchButtonClickedEvent;
        private void OnSearchButtonClick(string text)
        {
            
            string[] inputSplit;
            if (searchHouseButton != null)
            {
                inputSplit = text.ToLower().Split(' ', ',', '\n', '.', '!', '?', ':', ';');
                resultStatusLabel.Text = "house appeared on: ";
                for (int i = 0; i < inputSplit.Length; i++)
                {
                    if(inputSplit[i].Equals("house"))
                    {
                        resultStatusLabel.Text += ("  " + (i+1));
                        counter++;
                    }
                }
                howManyHouses.Text = "the word house appeared " + counter + " times";
                counter = 0;
            }
        }
    }
}

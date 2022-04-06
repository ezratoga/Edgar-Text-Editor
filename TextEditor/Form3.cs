using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form3 : Form
    {
        Form1 f1;
        int countButton1;
        int button1ClickedReal;
        public bool isClosed;
        public Form3(Form1 frm1)
        {
            InitializeComponent();
            this.f1=frm1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int indexOfText = f1.richTextBox1.Text.ToLower().IndexOf(textBox1.Text.ToLower());
            int countText = 0;
            List<int> collectOfText = new List<int>();
            collectOfText.Add(indexOfText);

            if (textBox1.Text.Length <= 0)
                MessageBox.Show("Fill the 'Find' field to find word");

            while (indexOfText != -1 && textBox1.Text.Length > 0)
            {
                countText++;
                indexOfText = f1.richTextBox1.Text.ToLower().IndexOf(textBox1.Text.ToLower(), indexOfText + 1);
                collectOfText.Add(indexOfText);
            }


            countButton1++;
            button1ClickedReal++;
            if (countButton1 > countText)
            {
                countButton1 = countButton1 - countButton1 + 1;
            }

            if (countButton1 == 1)
            {
                if(collectOfText[countButton1 - 1] == -1)
                {
                    MessageBox.Show("Word is not found");
                } 
                else
                {
                    f1.richTextBox1.SelectionStart = collectOfText[countButton1 - 1];
                    f1.richTextBox1.SelectionLength = textBox1.Text.Length;
                    f1.richTextBox1.SelectionBackColor = Color.LightBlue;
                }
                //f1.richTextBox1.Select(collectOfText[countButton1 - 1], textBox1.Text.Length);
                //f1.richTextBox1.Find(textBox1.Text, collectOfText[countButton1 - 1], collectOfText[countButton1 - 1] + textBox1.Text.Length, RichTextBoxFinds.None);
            }
            else if (countButton1 > 1)
            {
                if (collectOfText[countButton1 - 1] == -1)
                {
                    MessageBox.Show("Word is not found");
                }
                else
                {
                    f1.richTextBox1.SelectionStart = 0;
                    f1.richTextBox1.SelectAll();
                    f1.richTextBox1.SelectionBackColor = Color.Transparent;
                    f1.richTextBox1.SelectionStart = collectOfText[countButton1 - 1];
                    f1.richTextBox1.SelectionLength = textBox1.Text.Length;
                    f1.richTextBox1.SelectionBackColor = Color.LightBlue;
                }
                //f1.richTextBox1.Find(textBox1.Text, collectOfText[countButton1 - 1], collectOfText[countButton1 - 1] + textBox1.Text.Length, RichTextBoxFinds.None);
            }
            else if (countButton1 == 1 && button1ClickedReal > countButton1)
            {
                if (collectOfText[countButton1 - 1] == -1)
                {
                    MessageBox.Show("Word is not found");
                }
                else
                {
                    f1.richTextBox1.SelectionStart = 0;
                    f1.richTextBox1.SelectAll();
                    f1.richTextBox1.SelectionBackColor = Color.Transparent;
                    f1.richTextBox1.SelectionStart = collectOfText[countButton1 - 1];
                    f1.richTextBox1.SelectionLength = textBox1.Text.Length;
                    f1.richTextBox1.SelectionBackColor = Color.LightBlue;
                }
                //f1.richTextBox1.Find(textBox1.Text, collectOfText[countButton1 - 1], collectOfText[countButton1 - 1] + textBox1.Text.Length, RichTextBoxFinds.None);
            }
            /*if (f1.openedFileName != "")
            {
                FileStream FileHandle1 = new FileStream(f1.openedFileName, FileMode.OpenOrCreate);
                string collection1 = f1.richTextBox1.Text;
                byte[] collection2 = Encoding.ASCII.GetBytes(collection1);
                byte[] collectionToFind = Encoding.ASCII.GetBytes(textBox1.Text);
                int integerContainChar;

                while ((integerContainChar = FileHandle1.ReadByte()) != 1)
                    label3.Text = integerContainChar.ToString();
            }*/
            label3.Text = indexOfText.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                f1.richTextBox1.Text = f1.richTextBox1.Text.Replace(textBox1.Text, textBox2.Text);
            else
                MessageBox.Show("Enter the empty field");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (countButton1 == 0)
                countButton1 = 1;
            int indexOfText = f1.richTextBox1.Text.ToLower().IndexOf(textBox1.Text.ToLower());
            int countText = 0;
            List<int> collectOfText = new List<int>();
            collectOfText.Add(indexOfText);

            while (indexOfText != -1 && textBox1.Text.Length > 0)
            {
                countText++;
                indexOfText = f1.richTextBox1.Text.ToLower().IndexOf(textBox1.Text.ToLower(), indexOfText + 1);
                collectOfText.Add(indexOfText);
            }

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                f1.richTextBox1.Text = f1.richTextBox1.Text.Remove(collectOfText[countButton1 - 1], textBox1.Text.Length).Insert(collectOfText[countButton1 - 1], textBox2.Text);
            else
                MessageBox.Show("Please fill the empty field!");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            isClosed = true;
        }
    }
}

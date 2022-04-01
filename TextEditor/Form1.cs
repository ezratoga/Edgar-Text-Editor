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
    public partial class Form1 : Form
    {
        Form1 module1;
        public Form1()
        {
            InitializeComponent();
        }

        public string openedFileName = "";
        public string savedFileName = "";
        public string savedAsFileName = "";
        public string textBefore = "";
        public string textBeforeReplace = "";
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialognew = MessageBox.Show("Do you want to save it before?", "New", MessageBoxButtons.YesNo);

            if (dialognew == DialogResult.Yes)
            {
                SaveFileDialog sfdial = new SaveFileDialog();
                sfdial.Filter = "Text Files (.txt)|*.txt;*.text|HTML Files (.html)|*.html|Hypertext Files (.hypertext)|*.hypertext|All Files (.*)|*";
                sfdial.Title = "Save a file";

                if (sfdial.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter serialf = new StreamWriter(sfdial.FileName);
                    serialf.Write(richTextBox1.Text);
                    serialf.Close();
                }
            }

            else if (dialognew == DialogResult.No)
            {
                richTextBox1.Text = richTextBox1.Text;
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt;*.text|HTML Files (.html)|*.html|Hypertext Files (.hypertext)|*.hypertext|All Files (.*)|*";
            ofd.Title = "Open a file";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader les = new StreamReader(ofd.FileName);
                richTextBox1.Text = les.ReadToEnd();
                les.Close();
                openedFileName = ofd.FileName;
                textBefore = richTextBox1.Text;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openedFileName == "")
            {
                SaveFileDialog sfdial = new SaveFileDialog();
                sfdial.Filter = "Text Files (.txt)|*.txt;*.text|HTML Files (.html)|*.html|Hypertext Files (.hypertext)|*.hypertext|All Files (.*)|*";
                sfdial.Title = "Save a file";

                if (sfdial.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter serialf = new StreamWriter(sfdial.FileName);
                    if (richTextBox1.Text.Contains("<hypertext>") && sfdial.FileName.Contains(".html"))
                    {
                        richTextBox1.Text = richTextBox1.Text.Replace("<hypertext>", "<html>");
                        richTextBox1.Text = richTextBox1.Text.Replace("</hypertext>", "</html>");
                        richTextBox1.Text = richTextBox1.Text.Replace("<metadata>", "<meta");
                        richTextBox1.Text = richTextBox1.Text.Replace("</metadata>", ">");
                        richTextBox1.Text = richTextBox1.Text.Replace("<content>", "<body>");
                        richTextBox1.Text = richTextBox1.Text.Replace("</content>", "</body>");
                        richTextBox1.Text = richTextBox1.Text.Replace("<paragraph>", "<p>");
                        richTextBox1.Text = richTextBox1.Text.Replace("</paragraph>", "</p>");
                    }
                    serialf.Write(richTextBox1.Text);
                    serialf.Close();
                    openedFileName = sfdial.FileName;
                }
            }

            else if (openedFileName != "")
            {
                StreamWriter serialf = new StreamWriter(openedFileName);
                if (richTextBox1.Text.Contains("<hypertext>") && openedFileName.Contains(".html"))
                {
                    richTextBox1.Text = richTextBox1.Text.Replace("<hypertext>", "<html>");
                    richTextBox1.Text = richTextBox1.Text.Replace("</hypertext>", "</html>");
                    richTextBox1.Text = richTextBox1.Text.Replace("<metadata>", "<meta");
                    richTextBox1.Text = richTextBox1.Text.Replace("</metadata>", ">");
                    richTextBox1.Text = richTextBox1.Text.Replace("<content>", "<body>");
                    richTextBox1.Text = richTextBox1.Text.Replace("</content>", "</body>");
                    richTextBox1.Text = richTextBox1.Text.Replace("<paragraph>", "<p>");
                    richTextBox1.Text = richTextBox1.Text.Replace("</paragraph>", "</p>");
                }
                serialf.Write(richTextBox1.Text);
                serialf.Close();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBeforeReplace.Length > 0)
                richTextBox1.Text = textBeforeReplace;
            else
                richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                form2.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog;

            if (openedFileName != "" && textBefore != richTextBox1.Text)
            {
                dialog = MessageBox.Show("Do you want to save it before Close?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    StreamWriter serialf = new StreamWriter(openedFileName);
                    serialf.Write(richTextBox1.Text);
                    serialf.Close();
                }
            }
            else
            {
                dialog = MessageBox.Show("Do you want to close it?", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            /*if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }*/

            

        }

        public void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.ShowDialog();
            if (form3.isClosed == true)
            {
                richTextBox1.SelectionBackColor = Color.Transparent;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdial = new SaveFileDialog();
            sfdial.Filter = "Text Files (.txt)|*.txt;*.text|HTML Files (.html)|*.html|Hypertext Files (.hypertext)|*.hypertext|All Files (.*)|*";
            sfdial.Title = "Save As a file";

            if (sfdial.ShowDialog() == DialogResult.OK)
            {
                StreamWriter serialf = new StreamWriter(sfdial.FileName);
                if (richTextBox1.Text.Contains("<hypertext>") && sfdial.FileName.Contains(".html"))
                {
                    richTextBox1.Text = richTextBox1.Text.Replace("<hypertext>", "<html>");
                    richTextBox1.Text = richTextBox1.Text.Replace("</hypertext>", "</html>");
                    richTextBox1.Text = richTextBox1.Text.Replace("<metadata>", "<meta");
                    richTextBox1.Text = richTextBox1.Text.Replace("</metadata>", ">");
                    richTextBox1.Text = richTextBox1.Text.Replace("<content>", "<body>");
                    richTextBox1.Text = richTextBox1.Text.Replace("</content>", "</body>");
                    richTextBox1.Text = richTextBox1.Text.Replace("<paragraph>", "<p>");
                    richTextBox1.Text = richTextBox1.Text.Replace("</paragraph>", "</p>");
                }
                serialf.Write(richTextBox1.Text);
                serialf.Close();
                openedFileName = sfdial.FileName;
            }
        }

        private void findOrReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBeforeReplace = richTextBox1.Text;

            Form3 form3 = new Form3(this);
            form3.ShowDialog();
            if (form3.isClosed == true)
            {
                richTextBox1.SelectionBackColor = Color.Transparent;
            }
        }
    }
}

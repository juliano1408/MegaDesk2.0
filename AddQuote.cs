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

namespace MegaDesk_Stratton
{
    public partial class AddQuote : Form
    {
        
        private DeskQuote _newQuote;
        private Desk _newDesk;

        public AddQuote(Desk d, DeskQuote q)
        {
            _newDesk = d;
            _newQuote = q;
            
            InitializeComponent();
        }
        public void createDeskQuote()
        {
            
            _newQuote.SetDate(DateTime.Now);
            dateLbl.Text = DateTime.Now.ToString("dd MMMM yyyy");
            
            _newQuote.SetCustName(custNameInput.Text);
            _newDesk.SetWidth(int.Parse(deskWidthInput.Text));
            _newDesk.SetDepth(int.Parse(deskDepthInput.Text));
            _newDesk.SetArea(_newDesk.GetWidth(), _newDesk.GetDepth());
            _newDesk.SetDrawerCount(drawersUpDown.Value);
           
            var surfaceMat = desktopMatComboBox.Text;

            var rushTime = rushComboBox.Text;
           
            _newQuote.SetDesk(_newDesk);
            _newQuote.setQuote();

                     
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = (MainMenu)Tag;
            viewMainMenu.Show();
            this.Close();

        }

        private void submitQuoteBtn_Click(object sender, EventArgs e)
        {
            createDeskQuote();
            var viewDisplayQuote = new DisplayQuote(_newQuote);
            viewDisplayQuote.Tag = this;
            viewDisplayQuote.Show(this);
            saveToTxtJson(_newQuote);
            Hide();

        }

        private void saveToTxtJson(DeskQuote deskquote)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            string customName = deskquote.GetCustName();
            string width = deskquote.GetDesk().GetWidth().ToString();
            string depth = deskquote.GetDesk().GetDepth().ToString();
            string numberDrawers = deskquote.GetDesk().GetDrawerCount().ToString();
            string material = deskquote.GetDesk().GetDesktopMaterial().ToString();
            string orderOptions = deskquote.GetRush().ToString();

            string json = @"{'customName':" + customName + ", " +
                            "'width': " + width + ", " +
                            "'depth': " + depth + ", " +
                            "'numberDrawers': " + numberDrawers + ", " +
                            "'material': " + material + ", " +
                            "'orderOptions': " + orderOptions + "}";

            string pathFile = projectDirectory + "\\quotes.txt";

            if (!File.Exists(pathFile))
            {
                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine(json);
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(pathFile, true);
                sw.WriteLine(json);
                sw.Dispose();
            }

        }

        private void deskWidthInput_Validating(object sender, CancelEventArgs e)
        {

            if (deskWidthInput.Text != null && deskWidthInput.Text != string.Empty)
            {
                
                for (int ch = 0; ch < deskWidthInput.Text.Length; ch++)
                {
                    if (!Char.IsDigit(deskWidthInput.Text[ch]) && (!Char.IsControl(deskWidthInput.Text[ch])))
                    {
                        e.Cancel= true;
                        deskWidthInput.Select(0, deskWidthInput.Text.Length);
                        deskWidthInput.Focus();

                        errorProvider2.SetError(deskWidthInput, "Enter valid number");
                    }
                    else
                    {
                        errorProvider2.SetError(deskWidthInput, "");
                        if (!ValidWidth(deskWidthInput.Text))
                        {

                            e.Cancel = true;
                            errorProvider2.SetError(deskWidthInput, $"Width must be greater than or equal to {_newDesk.GetMINWIDTH()} and less than or equal to {_newDesk.GetMAXWIDTH()}");
                        }
                        else
                        {
                            errorProvider2.SetError(deskWidthInput, String.Empty);
                        }

                        
                    }
                }
                }
            else
            {
                e.Cancel = true;
                errorProvider2.SetError(deskWidthInput, "Enter valid number");
            }
          
}
        public bool ValidWidth(string widthInput)
        {
            
                if (_newDesk.ValidatedWidth(int.Parse(widthInput)))
                { return true; }
                else
                { return false; }
            

         }

        private void custNameInput_Validating(object sender, CancelEventArgs e)
        {
            if (custNameInput.Text == string.Empty)
                
            {
                e.Cancel = true;
                errorProvider1.SetError(custNameInput, "Name is required."); }
            else
            {
                errorProvider1.SetError(custNameInput, string.Empty);
            }
        }

        private void deskDepthInput_Validating(object sender, CancelEventArgs e)
        {
            if(deskDepthInput.Text != null && deskDepthInput.Text != string.Empty)
            {
                if (!ValidDepth(deskDepthInput.Text))
                {
                    e.Cancel = true;
                    errorProvider3.SetError(deskDepthInput, $"Depth must be greater than or equal to {_newDesk.GetMINDEPTH()} and less than or equal to {_newDesk.GetMAXDEPTH() }");
                }
                else
                {
                    errorProvider3.SetError(deskDepthInput, string.Empty);
                }
            }
            else
            {
                e.Cancel = true;
                errorProvider3.SetError(deskDepthInput, "Enter a valid number.");
            }
        }
        public bool ValidDepth(string depthInput)
        { if (_newDesk.ValidatedDepth(int.Parse(depthInput)))
            { return true; }
            else return false;
        }
        
        
        private bool depthNotNumber = false;

        private void deskDepthInput_KeyDown(object sender, KeyEventArgs e)
        {
            depthNotNumber = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        depthNotNumber = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                depthNotNumber = true;
            }
        }

        private void deskDepthInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (depthNotNumber) e.Handled = true;
        }

        private void desktopMatComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedMaterial = this.desktopMatComboBox.SelectedItem.ToString();
            selectedMaterial.Trim();
            _newDesk.SetDesktopMaterial(selectedMaterial);
        }
 
        private void rushComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedRush = this.rushComboBox.SelectedItem.ToString();
            selectedRush.Trim();
            try
            {
                _newQuote.SetRush(int.Parse(selectedRush));
            }
            catch (Exception exc) 
            {   
                _newQuote.SetRush(0);
            }
        }

    }
    
}

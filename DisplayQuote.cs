using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Stratton
{
    public partial class DisplayQuote : Form

    {
        private DeskQuote _deskQuote;

        public DisplayQuote(DeskQuote dq)
        {
            _deskQuote = dq;

            InitializeComponent();
        }

        private void displayClose_Click(object sender, EventArgs e)
        {

        }

        private void displayQuoteMenuBtn_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = new MainMenu();
            viewMainMenu.Show();
            this.Close();
        }


        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            displayCustNameBox.Text =  _deskQuote.GetCustName();
            displayQuoteDrawerCntBox.Text = _deskQuote.GetDesk().GetDrawerCount().ToString();
            displayQuoteRushBox.Text = _deskQuote.GetRush().ToString();
            displayQuoteRushCostBox.Text = _deskQuote.CalcRushCost().ToString();
            displayQuoteRushBox.Text = _deskQuote.GetRush().ToString();
            displayQuoteWidthBox.Text = _deskQuote.GetDesk().GetWidth().ToString();
            displayQuoteDepthBox.Text = _deskQuote.GetDesk().GetDepth().ToString();
            displayQuoteAreaBox.Text = _deskQuote.GetDesk().GetArea().ToString();
            displayQuoteAreaCostBox.Text = _deskQuote.AreaTotalCost().ToString();
            displayQuoteDateBox.Text = _deskQuote.GetDate().ToString();
            displayQuoteDrawerCostBox.Text = _deskQuote.CalcDrawerCost().ToString();
            displayQuoteMatBox.Text = _deskQuote.GetDesk().GetDesktopMaterial().ToString();
            displayQuoteMatCostBox.Text = _deskQuote.CalcSurfaceCost().ToString();
            displayQuoteTotalCostBox.Text = _deskQuote.GetQuote().ToString();

        }

    }
}

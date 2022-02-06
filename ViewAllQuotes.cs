using Newtonsoft.Json;
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

namespace MegaDesk_Stratton
{
    public partial class ViewAllQuotes : Form
    {
        
        public ViewAllQuotes()
        {
            InitializeComponent();
            materialComboBox.DataSource = new List<string>()
            {
                "All", "laminate", "oak", "pine", "rosewood", "veneer"
            };
        }

        private void allQuotesClose_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = (MainMenu)Tag;
            viewMainMenu.Show();
            this.Close();
        }

        private List<DeskQuote> getQuotesFromJson()
        {
            List<DeskQuote> quotes = new List<DeskQuote>();

            //JSON file path
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string filePath = projectDirectory + "\\quotes.txt";

            //Read File
            string content = File.ReadAllText(filePath, Encoding.UTF8);

            //Parse JSON
            var jsonReader = new JsonTextReader(new StringReader(content))
            {
                SupportMultipleContent = true
            };

            var jsonSerializer = new JsonSerializer();

            while (jsonReader.Read())
            {
                DeskQuote quote = jsonSerializer.Deserialize<DeskQuote>(jsonReader);
                quotes.Add(quote);
            }
            return quotes;
        }

     

        private void materialComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string material = ((string)materialComboBox.SelectedItem).ToString();
            Console.WriteLine(material);

            quotesListView.Items.Clear();

            List<DeskQuote> quotes = getQuotesFromJson();

            foreach (DeskQuote quote in quotes)
            {
                if(quote.GetDesk().GetMaterial() == material || material == "All")
                {
                    String[] row = { quote.GetCustName(),
                    quote.GetRush().ToString(),
                    quote.GetDesk().GetWidth().ToString(),
                    quote.GetDesk().GetDepth().ToString(),
                    quote.GetDesk().GetMaterial(),
                    quote.GetDesk().GetDrawerCount().ToString()
                    };
                    var quoteListItem = new ListViewItem(row);
                    quotesListView.Items.Add(quoteListItem);
                }
                
            }


        }
    }
}

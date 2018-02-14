using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace Molecular_Mass_Calculator
{
    public partial class MolecularMass : Form
    {
        // List to hold all atoms w/ (atomic-number, atomic-weight, element, and symbol)
        private List<Atoms> atoms = new List<Atoms>();

        // Dictionary to hold user input - parsed by <key: symbol, value: element count>
        private Dictionary<string, int> UserAtomCount = new Dictionary<string, int>();

        // Data source for data grid view
        private BindingSource bSource = new BindingSource();

        public MolecularMass()
        {
            InitializeComponent();
        }

        // Initialization on form load 
        private void MolecularMass_Load(object sender, EventArgs e)
        {
            // Read in data from XML file
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load("PeriodicTable.xml");
            }
            catch (Exception error)
            {
                Console.WriteLine("Can not read file: " + error.Message);
            }

            // Get all "fields" nodes from document
            XmlNodeList elementList = doc.GetElementsByTagName("fields");

            // Variables to hold atomic number, weight, chemical symbol, and element name
            int num;
            double mass;
            string symbol, name;

            // Parse out data from xml fields tag and add it to list of atoms
            foreach (XmlNode atom in elementList)
            {
                try
                {
                    // Assign xml data to appropriate variable
                    num = Convert.ToInt32(atom["atomic-number"].InnerXml);
                    name = atom["element"].InnerXml;
                    mass = Convert.ToDouble(atom["atomic-weight"].InnerXml);
                    symbol = atom["symbol"].InnerXml;

                    atoms.Add(new Atoms(num, name, symbol, mass));
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error parsing xml data: " + error.Message);
                }
            }

            UI_TB_Formula.Select();

            //  Set binding source to display all elements by atomic number and link to data grid view 
            DisplayAllByAtomicNumber();
            UI_DGV_Data.DataSource = bSource;
        }

        // Event handler to sort by name
        private void UI_BTN_Name_Click(object sender, EventArgs e)
        {
            // Check if user has entered any data into text box
            if (UI_TB_Formula.Text.Trim().Length > 0)
                DisplayUserFormulaByElements();
            else
                DisplayAllElementsByName();
        }

        // Event handler to sort by atomic number
        private void UI_BTN_Number_Click(object sender, EventArgs e)
        {
            if (UI_TB_Formula.Text.Length > 0)
                DisplayUserByAtomicNumber();
            else
                DisplayAllByAtomicNumber();
        }

        // Event handler to filter for single character symbol atoms
        private void UI_BTN_SingleSymbol_Click(object sender, EventArgs e)
        {
            bSource.DataSource = from a in atoms
                                 where a.Symbol.Length == 1
                                 orderby a.AtomicNumber
                                 select new
                                 {
                                     a.AtomicNumber,
                                     a.Element,
                                     a.Symbol,
                                     a.MolarMass
                                 };

            UI_TB_Mass.BackColor = Color.White;
            UI_TB_Mass.Text = "";
        }

        // Event handler for user textbox change
        private void UI_TB_Formula_TextChanged(object sender, EventArgs e)
        {
            UI_TB_Mass.BackColor = Color.White;

            // Display default if user textbox is empty
            if (UI_TB_Formula.Text.Trim().Length == 0)
            {
                DisplayAllByAtomicNumber();
                UI_TB_Mass.Text = "";
                return;
            }

            // Clear previous user dictionary and check validity of input
            UserAtomCount.Clear();

            if (IsValid())
            {

                // Create data source with total molecular mass via join of atomic symbol and dictionary symbol count
                var getSum = from a in atoms
                             join symbols in UserAtomCount on a.Symbol equals symbols.Key
                             orderby a.AtomicNumber
                             select new
                             {
                                 a.Element,
                                 Count = UserAtomCount[symbols.Key],
                                 a.MolarMass,
                                 Total = a.MolarMass * UserAtomCount[symbols.Key]
                             };
                bSource.DataSource = getSum;

                UI_TB_Mass.Text = getSum.Sum(o => o.Total).ToString("f4") + " g/mol";
            }
        }

        // Support Method to display user info sorted by element name
        private void DisplayUserFormulaByElements()
        {
            // Reset user dictionary and check validity of user input
            UserAtomCount.Clear();

            if (IsValid())
            {
                var getSum = from a in atoms
                             join symbols in UserAtomCount on a.Symbol equals symbols.Key
                             orderby a.Element
                             select new
                             {
                                 a.Element,
                                 Count = UserAtomCount[symbols.Key],
                                 a.MolarMass,
                                 Total = a.MolarMass * UserAtomCount[symbols.Key]
                             };

                bSource.DataSource = getSum;

                UI_TB_Mass.Text = getSum.Sum(o => o.Total).ToString("f4") + " g/mol";
            }
        }

        // Support Method for all elements sorted by element name
        private void DisplayAllElementsByName()
        {
            bSource.DataSource = from a in atoms
                                 orderby a.Element
                                 select new
                                 {
                                     a.AtomicNumber,
                                     a.Element,
                                     a.Symbol,
                                     a.MolarMass
                                 };
        }

        // Support Method to display user input sorted by atomic number 
        private void DisplayUserByAtomicNumber()
        {
            // Clear previous dictionary contents of user input
            UserAtomCount.Clear();

            // Check validity of user input - set binding if valid
            if (IsValid())
            {
                var getSum = from a in atoms
                             join symbols in UserAtomCount on a.Symbol equals symbols.Key
                             orderby a.AtomicNumber
                             select new
                             {
                                 a.Element,
                                 Count = UserAtomCount[symbols.Key],
                                 a.MolarMass,
                                 Total = a.MolarMass * UserAtomCount[symbols.Key]
                             };

                bSource.DataSource = getSum;

                // update total in mass text box
                UI_TB_Mass.Text = getSum.Sum(o => o.Total).ToString("f4") + " g/mol";
            }
        }

        // Support Method to display all elements by atomic number
        private void DisplayAllByAtomicNumber()
        {
            bSource.DataSource = from a in atoms
                                 orderby a.AtomicNumber
                                 select new
                                 {
                                     a.AtomicNumber,
                                     a.Element,
                                     a.Symbol,
                                     a.MolarMass
                                 };
        }

        // Support method to validate user input
        private bool IsValid()
        {
            // Reset back color to white
            UI_TB_Mass.BackColor = Color.White;

            // Regular expression grouped by (Possible Symbol)(Element Count)
            Regex regex = new Regex(@"([A-Z][a-z]?[a-z]?)(\d*)");

            string regExCreatedString = "";

            // Parse user input via regular expression to create dictionary
            foreach (Match m in regex.Matches(UI_TB_Formula.Text.Trim()))
            {
                regExCreatedString += m.Value;

                int count = 1;

                // Check if the possible symbol has multiple atoms
                if (m.Groups[2].Value != "")
                {
                    try
                    {
                        count = Convert.ToInt32(m.Groups[2].Value);
                    }
                    catch (Exception error)
                    {
                        UI_TB_Mass.BackColor = Color.Red;
                        UI_TB_Mass.Text = "Atom count too high!";
                        Console.WriteLine("Can not conver to atom count to a valid number: " + error.Message);
                        return false;
                    }
                }

                // Create dictionary of user input (key: Possible Symbol, value: atom count)
                if (!UserAtomCount.ContainsKey(m.Groups[1].Value))
                    UserAtomCount.Add(m.Groups[1].Value, count);
                else
                    UserAtomCount[m.Groups[1].Value] += count;
            }

            // User input has an invalid format
            if (!regExCreatedString.Equals(UI_TB_Formula.Text.Trim()))
            {
                UI_TB_Mass.BackColor = Color.Red;
                UI_TB_Mass.Text = "Invalid formula!";
                return false;
            }

            // Get a list of all valid symbols from loaded in XML file of all elements
            List<string> validSymbols = new List<string>();
            atoms.ForEach(o => validSymbols.Add(o.Symbol));

            // Validate each possible atomic symbol - exit if any user symbol is invalid
            foreach (KeyValuePair<string, int> kvp in UserAtomCount)
            {
                if (!validSymbols.Contains(kvp.Key))
                {
                    UI_TB_Mass.BackColor = Color.Yellow;
                    UI_TB_Mass.Text = "Element not found!";
                    return false;
                }
            }

            // Passes all conditions
            UI_TB_Mass.BackColor = Color.Lime;
            return true;
        }
    }
}

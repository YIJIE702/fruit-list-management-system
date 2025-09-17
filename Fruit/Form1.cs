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

namespace Fruit
{
    public partial class frmFruit : Form
    {
        public frmFruit()
        {
            InitializeComponent();
        }

        private void frmFruit_Load(object sender, EventArgs e)
        {
            LoadTextFile();
        }

        private void RefreshSorting()
        {
            List<string> termsList = new List<string>();

            for (int i = 0; i <= lstFruit.Items.Count - 1; i++)
            {
                termsList.Add(lstFruit.Items[i].ToString());
            }

            string[] arr = termsList.ToArray();

            Array.Sort(arr);

            // reverse array 
            //Array.Reverse(arr); 

            lstFruit.Items.Clear();

            foreach (string strFruit in arr)
            {
                lstFruit.Items.Add(strFruit);
            } 

        }

        private void LoadTextFile()
        {
            string saveLocation = Application.StartupPath;
            if (File.Exists(saveLocation + "\\test_file.txt"))
            {
                string inputLine = "";
                int i = 0;
                StreamReader myReader = new StreamReader(saveLocation + "\\test_file.txt", Encoding.Default);
                inputLine = myReader.ReadLine();
                lstFruit.Items.Clear();
                while (inputLine != null)
                {
                    lstFruit.Items.Add(inputLine);           
                    i++;
                    inputLine = null;
                    inputLine = myReader.ReadLine();
                }
                myReader.Close(); // Close the steamreader.
                myReader.Dispose(); // Release all resources used by the System.Text.IO.TextReader object.    
                RefreshSorting();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFruit.Text.Trim() == "")
            {
                MessageBox.Show("Fruit is empty. Please check.", "Empty textbox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFruit.Focus();
                return;
            }
            if (btnAdd.Text == "SAVE")
            {
                int selectedIndex = int.Parse(userSelected.Text);
                selectedIndex -= 1;
                if (selectedIndex <= 0)
                {
                    selectedIndex = 0;
                }
                lstFruit.Items.Insert(selectedIndex + 1, txtFruit.Text.Trim());
                lstFruit.Items.RemoveAt(selectedIndex);
                lstFruit.SelectedIndex = selectedIndex;
                RefreshSorting();
                Save();
                txtFruit.Text = "";
                btnAdd.Text = "Add";
                btnDelete.Text = "Delete";
                btnEdit.Enabled = true;
                btnClearAll.Enabled = true;
                btnSave.Enabled = true;
                lstFruit.Enabled = true;
            }
            else // Mean Add Items
            {
                lstFruit.Items.Add(txtFruit.Text.Trim());    
                RefreshSorting();
                Save();
                txtFruit.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstFruit.SelectedIndex != -1)
            {
                txtFruit.Text = lstFruit.Items[lstFruit.SelectedIndex].ToString();
                btnAdd.Text = "SAVE";
                btnDelete.Text = "CANCEL";
                txtFruit.Focus();
                btnEdit.Enabled = false;
                btnClearAll.Enabled = false;
                btnSave.Enabled = false;
                lstFruit.Enabled = false;
            }         
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "CANCEL")
            {
                btnAdd.Text = "Add";
                btnDelete.Text = "Delete";
                txtFruit.Text = "";
                txtFruit.Focus();
                btnEdit.Enabled = true;
                btnClearAll.Enabled = true;
                btnSave.Enabled = true;
                lstFruit.Enabled = true;
            }
            else
            {
                if (lstFruit.SelectedIndex != -1)
                {
                    lstFruit.Items.RemoveAt(lstFruit.SelectedIndex);
                    Save();
                }
            }
           
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (lstFruit.Items.Count == 0)
            {
                MessageBox.Show("There is no fruit list to be clear!", "No batch command", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (lstFruit.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show("Remove all fruits from the list?", "Confirm Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lstFruit.Items.Clear();
                    txtFruit.Text = "";
                    txtFruit.Focus();
                    Save();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (lstFruit.Items.Count == 0)
            {
                MessageBox.Show("There is no fruit found to be save.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RefreshSorting();
                string saveLocation = Application.StartupPath;
                StreamWriter sw = new StreamWriter(saveLocation + "\\test_file.txt");
                for (int i = 0; i <= lstFruit.Items.Count - 1; i++)
                {
                    sw.WriteLine(lstFruit.Items[i].ToString());
                }
                sw.Close();
            }
        }

        private void lstFruit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCurrentSelection = lstFruit.SelectedIndex;
            intCurrentSelection += 1;
            userSelected.Text = intCurrentSelection.ToString();
        }

    }
}

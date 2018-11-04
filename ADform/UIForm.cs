﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scavenger
{   
    //Implement Interface IUIForm
    public partial class UIForm : Form, IUIForm
    {   //Create Delegate for Event Handler
        public delegate void SubmitButtonClickedEventHandler(object source, EventArgs args);
        public delegate void SearchButtonClickedEventHandler(object source, EventArgs args);
        //Create Event
        public event SubmitButtonClickedEventHandler TButtonClicked;
        public event SearchButtonClickedEventHandler SearchButtonClicked;

        public UIForm()
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            Color black = Color.FromArgb(25, 25, 25);
            public override Color MenuItemSelected
            {
                get { return black; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return black; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return black; }
            }

           /* public override Color ButtonSelectedBorder
            {
                get { return black; }
            }
            public override Color ButtonSelectedGradientBegin
            {
                get { return black; }
            }
            public override Color ButtonSelectedGradientEnd
            {
                get { return black; }
            }*/
           /* public override Color MenuItemBorder
            {
                get { return black; }
            }*/
            public override Color MenuItemPressedGradientBegin
            {
                get { return black; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return black; }
            }
        }

        //Handles Submit button clicked
        private void TButton_Click(object sender, EventArgs e)
        {
            //domainName = domainTField.Text;
            //dValue.Text = "You entered:" + domainField;
            
            OnTButtonClicked();
            
        }
      
        //Submits text when enter is detected on text box
        private void domainTField_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //domainName = domainTField.Text;
                dValue.Text = "You entered:" + domainField;

                //e.Handled = true;
                e.SuppressKeyPress = true;
            }
            
        }

        //Notifies subscribers that Submit button was clicked
        protected virtual void OnTButtonClicked()
        {
            //Fire the event - notifying all subscribers
            if (TButtonClicked != null)
                TButtonClicked(this, null);
        }

   
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(domainField) != false)
            {
                dValue.Show();
            }
            else
            {
                dValue.Hide();
                OnSearchButtonClicked();
            }
        }

        protected virtual void OnSearchButtonClicked()
        {
            if(SearchButtonClicked != null)
            {
                SearchButtonClicked(this, null);
                SearchButtonClicked(this, null);
            }
        }


        //Sets/Gets the large text box
        public string OUTextBox
        {
            get { return displayOus.Text; }
            set { displayOus.Text = value; }
        }

        //Sets/Gets the domain field text box
        public string domainField
        {
            get { return domainTField.Text; }
            set { domainTField.Text = value; }
        }

        public string userField
        {
            get { return userTField.Text; }
            set { userTField.Text = value; }

        }

        public Label ldapLabel
        {
            get { return ldapStatus; }
            set { ldapStatus = value; }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("test");
            }*/
            saveFileDialog1.ShowDialog();
        }
    }
}

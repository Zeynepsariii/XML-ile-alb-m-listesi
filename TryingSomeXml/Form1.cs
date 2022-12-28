using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TryingSomeXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
           DataSet dataSet = new DataSet();
            dataSet.Tables.Clear();
            dataSet.ReadXml("XMLFile1.xml");
            dataGridView1.DataSource = dataSet.Tables[0];
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XDocument xDocument = new XDocument();
            XDocument x = XDocument.Load(@"XMLFile1.xml");
            x.Element("CATALOG").Add(
                new XElement("CD",
                new XElement("TITLE", textBox1.Text),     
                new XElement("ARTIST", textBox2.Text),
                new XElement("COUNTRY", textBox3.Text),
                new XElement("YEAR", textBox4.Text)
                ));
            x.Save(@"XMLFile1.xml");
            DataSet dataSet = new DataSet();
            dataSet.Tables.Clear();
            dataSet.ReadXml("XMLFile1.xml");
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"XMLFile1.xml");
            x.Root.Elements().Where(a => a.Element("TITLE").Value == textBox1.Text).Remove();
            x.Save(@"XMLFile1.xml");
            DataSet dataSet = new DataSet();
            dataSet.Tables.Clear();
            dataSet.ReadXml("XMLFile1.xml");
            dataGridView1.DataSource = dataSet.Tables[0];

        }

        
    }
}

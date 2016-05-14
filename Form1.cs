using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;

namespace xml_case_convert
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.ShowDialog();
    }

    private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      Match m;
      this.Activate();
      this.listBox2.Items.Clear();
      m = Regex.Match(openFileDialog1.FileName, @".*[\\]");
      this.listBox2.Tag = m.Value; 
      foreach (string fn in openFileDialog1.FileNames)
      {
        m = Regex.Match(fn, @"[^\\]*$");
        this.listBox2.Items.Add(m.Value); 
      }
      this.listBox2.Refresh();
    }

    private void processXml(string btn)
    {
      XmlDocument xml;
      XmlNodeList nds;
      foreach (string fn in listBox2.SelectedItems)
      {
        xml = new XmlDocument();
        xml.Load(listBox2.Tag + fn);
        nds = xml.GetElementsByTagName(this.textBox1.Text);
        foreach (XmlNode nd in nds)
        {
          if (btn == "C > c")
          {
            nd.InnerText = nd.InnerText.ToLower();
            // check if there exists N'... unicode string + $VARIABLES$
            nd.InnerText = nd.InnerText.Replace("n'", "N'");
            foreach (Match m in Regex.Matches(nd.InnerText,@"[$%][a-z]*[$%]"))
            {
              nd.InnerText = nd.InnerText.Replace(m.Value, m.Value.Replace("$","%").ToUpper());
            }
          }
          else if (btn == "c > C")
            nd.InnerText = nd.InnerText.ToUpper();
        }
        if (!System.IO.Directory.Exists(listBox2.Tag + "xcn")) System.IO.Directory.CreateDirectory(listBox2.Tag + "xcn");
        xml.Save(listBox2.Tag + "xcn\\" + fn);
        this.listBox1.Items.Add(fn);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      // upper to lower inside all elements with defined name
      processXml(((Button)sender).Text);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      // lower to upper inside all elements with defined name
      processXml(((Button)sender).Text);
    }
  }
}

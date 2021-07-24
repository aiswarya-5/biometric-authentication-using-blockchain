using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;

namespace BlockchainWithFingerprint
{
    public partial class Notary_ViewBlock : Form
    {
        public Notary_ViewBlock()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Notary_ViewBlock_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fileReader = new StreamReader(Application.StartupPath + "//bchain.json"))
            {
                txtInput.Text = fileReader.ReadToEnd();
                Deserialize();
            }
        }
        private void Deserialize()
        {
            
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                Dictionary<string, object> dic = js.Deserialize<Dictionary<string, object>>(txtInput.Text);

                TreeNode rootNode = new TreeNode("Root");
                
            }
            catch (ArgumentException argE)
            {
                // MessageBox.Show("JSON data is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

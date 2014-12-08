using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TrabalhoCache
{
    public partial class CacheForm : Form
    {
        #region Constructors

        public CacheForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Attributes and Properties

        private string _filePath;

        private CacheMemory _cacheMemory;

        private bool hasFileSelected
        {
            get
            {
                return !string.IsNullOrEmpty(_filePath);
            }
        }

        #endregion

        #region Private Methods

        //Realiza a leitura dos endereços do arquivo de entrada e realiza a leitura ou escrita na cache.
        private void ReadAdresses()
        {
            string[] lines = File.ReadAllLines(_filePath);

            int sizeLine = Convert.ToInt32(this.txtLineSize.Text);
            int rowsNumber = Convert.ToInt32(this.txtNumeroLinhas.Text);
            int associativity = Convert.ToInt32(this.txtLinhasConjunto.Text);

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line) || line.Length != 10)
                    continue;

                Address adress = CacheMemoryHelper.BuildAddress(sizeLine, rowsNumber, associativity, line.Substring(0, 8));

                if (line.Substring(9, 1).Equals("R"))
                    _cacheMemory.ReadAddress(adress);
                else
                    _cacheMemory.WriteAddress(adress);
            }
        }

        //Configura a cache com as configurações de entrada.
        private void SetCacheConfiguration()
        {
            int sizeLine = Convert.ToInt32(this.txtLineSize.Text);
            int rowsNumber = Convert.ToInt32(this.txtNumeroLinhas.Text);
            int associativity = Convert.ToInt32(this.txtLinhasConjunto.Text);
            WritePolicy policy = this.cbxWrittenPolicy.SelectedItem.Equals(WritePolicy.WriteThrough.ToString()) ? WritePolicy.WriteThrough : WritePolicy.WriteBack;
            int acessTime = Convert.ToInt32(this.txtTimeCache.Text);
            MainMemory.AccessTime = Convert.ToInt32(this.txtTimeMP.Text);

            _cacheMemory.SetCache(sizeLine, rowsNumber, associativity, policy, acessTime);
        }

        //Verifica se os campos estão preenchidos
        private bool CanCreateReport()
        {
            return !(!hasFileSelected || string.IsNullOrEmpty(this.txtLineSize.Text) || string.IsNullOrEmpty(this.txtLinhasConjunto.Text) ||
                string.IsNullOrEmpty(this.txtNumeroLinhas.Text) || string.IsNullOrEmpty(this.txtTimeCache.Text) || string.IsNullOrEmpty(this.txtTimeMP.Text));

        }

        #endregion

        #region Signed Events

        //Solicita ao usuário para selecionar o arquivo de entrada.
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            _filePath = openFileDialog.FileName;
            this.txtFilePath.Text = _filePath;
        }

        //Cria os items do combobox onde é informado a politica de escrita.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbxWrittenPolicy.Items.Add("WriteBack");
            this.cbxWrittenPolicy.Items.Add("WriteThrough");

            this.cbxWrittenPolicy.SelectedIndex = 0;

            foreach (Control control in tableLayoutPanel1.Controls)
                if ((control is TextBox))
                {
                    var textbox = (control as TextBox);
                    textbox.KeyPress += textBox_KeyPress;
                    if (textbox.Tag != null)
                        textbox.Leave += textBox_Leave;
                }
        }

        //Gera o relatório.
        private void bntReport_Click(object sender, EventArgs e)
        {
            if (!this.CanCreateReport())
            {
                MessageBox.Show("Algumas informações não foram preenchidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _cacheMemory = new CacheMemory();
            MainMemory.Reads = 0;
            MainMemory.Writes = 0;

            this.SetCacheConfiguration();
            this.ReadAdresses();

            string sizeRow = this.txtLineSize.Text;
            string rowsNumber = this.txtNumeroLinhas.Text;
            string associativity = this.txtLinhasConjunto.Text;
            string policy = this.cbxWrittenPolicy.SelectedItem.ToString();

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".txt";
            saveDialog.FileName = string.Concat(sizeRow, "bytes", "_", rowsNumber, "linhas", "_", "Associatividade", associativity, "_", policy);
            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ReportManager.CreateReport(saveDialog.FileName, _cacheMemory, Path.GetFileName(_filePath)))
                {
                    if (MessageBox.Show("Relatório gerado com sucesso, deseja abrir?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        Process.Start("notepad.exe", saveDialog.FileName);
                }
                else
                    MessageBox.Show("Erro ao gerar o relatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
                return;

            int value = Convert.ToInt32((sender as TextBox).Text);
            if (!((value & (value - 1)) == 0))
            {
                MessageBox.Show("O número informado não é potencia de 2.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (sender as TextBox).Focus();
            }
        }

        #endregion
    }
}

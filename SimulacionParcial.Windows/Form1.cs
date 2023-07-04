namespace SimulacionParcial.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private void InicializarControles()
        {
            txtAltura.Clear();
            txtRadio.Clear();
            txtRadio.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var radio = double.Parse(txtRadio.Text);
                var altura = double.Parse(txtAltura.Text);
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, radio, altura);
                AgregarFila(r);
                MessageBox.Show("Registro agregado",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                InicializarControles();
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvConos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, double radio, double altura)
        {
            double generatriz= CalcularGeneratriz(radio, altura);
            r.Cells[colRadio.Index].Value=radio;
            r.Cells[colAltura.Index].Value = altura;
            r.Cells[colGeneratriz.Index].Value = generatriz;
            r.Cells[colArea.Index].Value=CalcularArea(radio, generatriz);
            r.Cells[colVolumen.Index].Value = CalcularVolumen(radio, altura);

        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvConos);
            return r;
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            errorProvider1.Clear();
            return esValido;
        }
        private double CalcularVolumen(double radio, double altura)
        {
            return (Math.PI * Math.Pow(radio, 2) * altura) / 3;
        }

        private double CalcularArea(double radio, double generatriz)
        {
            return Math.PI * radio * (radio + generatriz);
        }

        private double CalcularGeneratriz(double radio, double altura)
        {

            return Math.Sqrt(Math.Pow(radio, 2) + Math.Pow(altura, 2));
        }

    }
}
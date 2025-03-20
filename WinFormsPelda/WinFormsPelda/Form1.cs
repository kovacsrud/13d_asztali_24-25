namespace WinFormsPelda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gomb_Click(object sender, EventArgs e)
        {
            try
            {
                var szam1 = Convert.ToInt32(textBoxSzam1.Text);
                var szam2 = Convert.ToInt32(textBoxSzam2.Text);
                var eredmeny = szam1 / szam2;

                labelEredmeny.Text = eredmeny.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("A sz�m 2 �rt�ke nem lehet nulla!");
            }
            catch (FormatException) {
                MessageBox.Show("A mez�kbe sz�mot kell �rni");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

     
    }
}

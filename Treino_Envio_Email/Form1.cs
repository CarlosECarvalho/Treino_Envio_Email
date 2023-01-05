using System.Net;
using System.Net.Mail;

namespace Treino_Envio_Email
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            btnEnviar.Enabled = false;
            try
            {
                var emailDestinartario = txtDest.Text;
                var emailAssunto = txtAssunto.Text;
                var emailCorpo = txtCorpo.Text;

                MailMessage mailMessage = new();

                mailMessage.From = new MailAddress("emailenvio@gmail.com");
                mailMessage.To.Add(emailDestinartario);
                mailMessage.Subject = emailAssunto;
                mailMessage.Body = emailCorpo;
            
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials= false;
            smtp.EnableSsl=true;
            smtp.Credentials = new NetworkCredential("emailenvio@gmail.com", "senhateste");

            smtp.Send(mailMessage);

            MessageBox.Show("Email Enviado!");

            txtAssunto.Text = string.Empty;
            txtDest.Text = string.Empty;
            txtCorpo.Text = string.Empty;
            btnEnviar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha ao enviar");

                txtAssunto.Text = string.Empty;
                txtDest.Text = string.Empty;
                txtCorpo.Text = string.Empty;
                btnEnviar.Enabled = true;

            }

        }
    }
}
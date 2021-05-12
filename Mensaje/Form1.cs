using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mensaje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
        System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
            mmsg.To.Add(txtPara.Text);
            mmsg.Subject = txtAsunto.Text;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Bcc.Add(txtBcc.Text);
            

            mmsg.Body = txtMensaje.Text;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;

            if (txtAdjunto.Text != (""))
            {
                System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(txtAdjunto.Text);
                mmsg.Attachments.Add(archivo);
            }

            //GMAIL
            //mmsg.From = new System.Net.Mail.MailAddress("juanppatii11@gmail.com");

            //HOTMAIL
            mmsg.From = new System.Net.Mail.MailAddress("JPablopb_14@hotmail.com");

            //Correo Cliente

            //GMAIL
            //cliente.Credentials = new System.Net.NetworkCredential("juanppatii11@gmail.com", "contraseñacorrreo");

            //HOTMAIL
            cliente.Credentials = new System.Net.NetworkCredential("JPablopb_14@hotmail.com", "contraseñacorreo");

            cliente.Port = 587;
            cliente.EnableSsl = true;

            //GMAIL
            //cliente.Host = "smtp.gmail.com"; //mail.dominio.com
            
            //HOTMAIL
            cliente.Host = "smtp.live.com";

            try
            {
                cliente.Send(mmsg);
                MessageBox.Show("Mensaje Enviado");
            }
            catch(Exception)
            {
                MessageBox.Show("Error al Enviar");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Adjuntar = new OpenFileDialog();
            Adjuntar.ShowDialog();
            if(Adjuntar.FileName != (""))
            {
                txtAdjunto.Text = Adjuntar.FileName;
            }
        }
    }
}

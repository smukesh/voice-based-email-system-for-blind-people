using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using S22.Imap;


namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        SpeechRecognitionEngine recengine = new SpeechRecognitionEngine();
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();
        public Form2()
        {
            InitializeComponent();
            Synthesizer.SpeakAsync("we are in compose page" );
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "compose", "close" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recengine.LoadGrammarAsync(grammar);
            recengine.SetInputToDefaultAudioDevice();
            recengine.RecognizeAsync(RecognizeMode.Multiple);
            recengine.SpeechRecognized += Recengine_SpeechRecognized;
        }

        private void Recengine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "compose":
                    try
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("voicesample1email@gmail.com", "p1voicesample");
                        MailMessage msg = new MailMessage();
                        msg.To.Add(richTextBox1.Text);
                        msg.From = new MailAddress("voicesample1email@gmail.com");
                        msg.Subject = richTextBox2.Text;
                        msg.Body = richTextBox3.Text;
                        client.Send(msg);
                        Synthesizer.SpeakAsync("successfully send the mail");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "close":
                    recengine.RecognizeAsyncStop();
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Hide();
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

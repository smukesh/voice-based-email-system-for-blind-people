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
using System.Net;
using System.Net.Mail;
using S22.Imap;


namespace WindowsFormsApp7
{
    public partial class Form3 : Form
    {
        SpeechRecognitionEngine Recengine = new SpeechRecognitionEngine();
        SpeechSynthesizer SYnthesizer = new SpeechSynthesizer();
        static Form3 f;
        public Form3()
        {
            InitializeComponent();
            SYnthesizer.SpeakAsync("weare in inbox page" 
                );
            
            f = this;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "inbox", "close" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            Recengine.LoadGrammarAsync(grammar);
            Recengine.SetInputToDefaultAudioDevice();
            Recengine.RecognizeAsync(RecognizeMode.Multiple);
            Recengine.SpeechRecognized += Recengine_SpeechRecognized;
        }

        private void Recengine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "inbox":
                    StartReceiving();
                    break;
                case "close":

                    Recengine.RecognizeAsyncStop();
                    Form4 f1 = new Form4();
                    f1.Show();
                    this.Hide();
                    break;
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void StartReceiving()
        {
            Task.Run(() =>
            {
                using (ImapClient client = new ImapClient("imap.gmail.com", 993, textBox1.Text, textBox2.Text,AuthMethod.Login,true))

                {
                    if (client.Supports("IDLE") == false)
                    {
                        MessageBox.Show("server does not support IMAP IDLE");
                        return;
                    }
                    client.NewMessage += new EventHandler<IdleMessageEventArgs>(onNewMessage);
                    while (true) ;

                }
            }
                );
        }
        static void onNewMessage(object sender, IdleMessageEventArgs e)
        {
            SpeechSynthesizer SYNthesizer = new SpeechSynthesizer();
            SYNthesizer.SpeakAsync("new message recevied");
            MessageBox.Show("new message received");
            
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
            f.Invoke((MethodInvoker)delegate
            {
                f.richTextBox1.AppendText("From:" + m.From + "\n" +
                                           "Subject:" + m.Subject + "\n" +
                                           "Body:" + m.Body + "\n"
                    );
            });
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

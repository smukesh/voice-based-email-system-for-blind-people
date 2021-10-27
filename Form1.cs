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
using System.Data.SqlClient;
namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
       
        public Form1()
        {
            InitializeComponent();
            synthesizer.SpeakAsync("welcome we are in the login page" );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "login","close"});
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)

            {
 
                case "login":

                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mukesh\Documents\data.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*)  From login where username ='" + textBox1.Text +"' and password ='" + textBox2.Text +"'",Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Form4 f4 = new Form4();
                        recEngine.RecognizeAsyncStop();
                        f4.Show();
                        this.Hide();
                    }
                    else
                    {
                        synthesizer.SpeakAsync("please enter the correct details ");
                    }
                    break;
                case "close":
                    recEngine.RecognizeAsyncStop();
                    this.Close();
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

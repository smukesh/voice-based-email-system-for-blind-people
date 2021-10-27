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

namespace WindowsFormsApp7
{
    public partial class Form4 : Form
    {
        SpeechRecognitionEngine recEnginE = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizeR = new SpeechSynthesizer();
        public Form4()
        {
            InitializeComponent();
            synthesizeR.SpeakAsync("welcome we are in the home page");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { " hello", "new", "inbox","close" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEnginE.LoadGrammarAsync(grammar);
            recEnginE.SetInputToDefaultAudioDevice();
            recEnginE.RecognizeAsync(RecognizeMode.Multiple);
            recEnginE.SpeechRecognized += RecEngine_SpeechRecognized;

        }
        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)

            {
                case "hello":
                    synthesizeR.SpeakAsync("hi master how can i help you");
                    break;
                case "new":
                    Form2 f2 = new Form2();
                    recEnginE.RecognizeAsyncStop();
                    f2.Show();
                    this.Hide();
                    break;
                case "inbox":
                    Form3 f3 = new Form3();
                    recEnginE.RecognizeAsyncStop();
                    f3.Show();
                    this.Hide();
                    break;
                case "close":
                    recEnginE.RecognizeAsyncStop();
                    this.Close();
                    break;
            }
        }
    }
}

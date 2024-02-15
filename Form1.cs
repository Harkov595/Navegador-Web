using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Navegador_Web 
{
    public partial class Navegador_Web : Form
    {
        private readonly string str_ruta;

        public Navegador_Web()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
            webView21.NavigationStarting += EnsureHttps;
            InitializeAsync();

        }
        async void InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.WebMessageReceived += UpdateAddressBar;

            await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");


            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
            Ir.Left = this.ClientSize.Width - Ir.Width;
            comboBox1.Width = Ir.Left - comboBox1.Left;

        }
        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String uri = args.TryGetWebMessageAsString();
            comboBox1.Text = uri;
            webView21.CoreWebView2.PostWebMessageAsString(uri);
        }


        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                //webView21.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
            Ir.Left = this.ClientSize.Width - Ir.Width;
            comboBox1.Width = Ir.Left - comboBox1.Left;
        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void Ir_Click(object sender, EventArgs e)
        {
            if (webView21 != null && webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Navigate(comboBox1.Text);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            webView21.CoreWebView2.Navigate("https://www.bing.com/search?q");
        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webView21_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2Guardar_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Directorio en donde se va a iniciar la busqueda
            openFileDialog1.InitialDirectory = "C:\Historial\archivo.txt";
            //Tipos de archivos que se van a buscar, en este caso archivos de texto con extensión .txt
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            //Guardamos en una variable el nombre del archivo que abrimos
            string fileName = openFileDialog1.FileName;

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                richTextBox1.AppendText(reader.ReadLine());
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
    }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica04_formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los TextBox
            string nombres = tbNombre.Text;
            string apellido = tbApellido.Text;
            string edad = tbEdad.Text;
            string estatura = tbEstatura.Text;
            string telefono = tbTelefono.Text;

            //  Obtener el género seleccionado 
            string genero = "";
            if (Masculino.Checked)
            {
                genero = "Hombre";
            }
            else if (Femenino.Checked)
            {
                genero = "Mujer";
            }

            // Crear una cadena de datos 
            string datos = $"Nombres: {nombres}\r\nApellidos: {apellido}\r\nEdad: {edad}\r\nEstatura: {estatura}\r\nTelefono{telefono}";

            // Guardar los datos en un archivo de texto 
            string rutaArchivo = "C:/Users/dan96/OneDrive/3M.txt";
            bool archivoExiste = File.Exists(rutaArchivo);

            if (archivoExiste == false)
            {
                File.WriteAllText(rutaArchivo, datos);
            }
            else
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(rutaArchivo, true))
                {
                    if (archivoExiste)
                    {
                        writer.WriteLine();
                    }
                    writer.WriteLine(datos);
                }
            }
            MessageBox.Show("Datos Guardados con éxito: \n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbNombre.Clear();
            tbApellido.Clear();
            tbEdad.Clear();
            tbEstatura.Clear();
            tbTelefono.Clear();
            Masculino.Checked = false;
            Femenino.Checked = false;
        }
    }
    }
}

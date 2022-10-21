using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MatiasTito_WindowsFinal
{
    public partial class FrmPracticaFinal : Form
    {

        string[] diasLaborales = new string[5] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };
        int[] horasTrabajadas = new int[5];

        public FrmPracticaFinal()
        {
            InitializeComponent();
        }

       
        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            decimal sueldo = decimal.Parse(txtSueldo.Text);
            string puesto = txtPuesto.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            if (validarSueldo(sueldo) == 0)
            {
                MessageBox.Show("El sueldo ingresado es invalido, ingrese otro (debe ser mayor a 0)");
                
            }
            if (validarPuesto(puesto) == 0)
            {
                MessageBox.Show("El puesto no cumple con las validaciones. El mismo debe ser: Soporte Técnico, DBA o Desarrollador.");
            }
            if(validarNombre(nombre) == 0)
            {
                MessageBox.Show("El nombre no cumple con las validaciones. El mismo debe contener mas de 2 caracteres y menos de 50.");
            }
            if (validarNombre(apellido) == 0)
            {
                MessageBox.Show("El apellido no cumple con las validaciones. El mismo debe contener mas de 2 caracteres y menos de 50.");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarNombreYPuesto();
        }

        private void btnIngresarHoras_Click(object sender, EventArgs e)
        {
            cargaHorasTrabajadas();
            mostrarHorasTrabajadas();
            MessageBox.Show("El promedio de horas trabajadas fue de " + calculoPromedioHorasTrabajadas());
            calculoMenosDe4HorasTrabajadas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtPuesto.Clear();
            txtSueldo.Clear();
            txtApellido.Clear();
        }

        #region metodos validar

        private int validarSueldo (decimal sueldo)
        {
            int flag = 0;
            if (sueldo > 0)
            {
                flag = 1;
            }
            return flag;
        }

        private int validarPuesto (string puesto)
        {
            int flag = 0;
            if(string.Compare(puesto.ToLower(),"soporte técnico")==0 || string.Compare(puesto.ToLower(), "dba") == 0 || string.Compare(puesto.ToLower(), "desarrollador") == 0)
            {
                flag = 1;
            }
            return flag;
        }

        private int validarNombre(string nombre)
        {
            int flag = 1;

            if(nombre.Length<2 || nombre.Length > 49)
            {
                flag = 0;
            }

            return flag;
        }

        private int validarApellido(string apellido)
        {
            int flag = 1;

            if (apellido.Length < 2 || apellido.Length > 49)
            {
                flag = 0;
            }

            return flag;
        }

        #endregion

        #region metodos mostrar

        private void mostrarNombreYPuesto()
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string puesto = txtPuesto.Text;
            MessageBox.Show("Nombre Completo: " + nombre + " " + apellido + "\nPuesto: " + puesto);
        }

        private void mostrarHorasTrabajadas()
        {
            MessageBox.Show("El total de horas trabajadas en la semana fue " + calculoHorasTrabajadas());
        }


        #endregion

        #region metodos ABM

        private void cargaHorasTrabajadas()
        {
            for (int i = 0; i < horasTrabajadas.Length; i++)
            {
                horasTrabajadas[i] = int.Parse(Interaction.InputBox("Ingrese las horas trabajadas del dia", diasLaborales[i]));
            }
        }

        #endregion

        #region metodos calculo

        private int calculoHorasTrabajadas()
        {
            int totalHoras = 0;
            foreach (var hora in horasTrabajadas)
            {
                totalHoras += hora;
            }
            return totalHoras;

        }

        private double calculoPromedioHorasTrabajadas()
        {
            double promedioHoras = (double)calculoHorasTrabajadas()/5;
            return promedioHoras;
        }


        private void calculoMenosDe4HorasTrabajadas()
        {
            int cont = 0;
            foreach (var hora in horasTrabajadas)
            {
                if (hora <= 4)
                {
                    MessageBox.Show("El dia " + diasLaborales[cont] + " trabajó menos de 4hs.");
                }
                cont++;
            }
        }

        #endregion

       


    }
}

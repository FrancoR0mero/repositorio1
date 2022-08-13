using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//CURSO – LEGAJO – APELLIDO – NOMBRE: 1w4 114067 Romero Franco

//Cadena de Conexión: "Data Source=138.99.7.66,1433;Initial Catalog=Consultorio;User ID=tup1_consultorio;Password=5@tUp1"

namespace TUP_PI_Recuperatorio_1W4B
{
    public partial class frmPacientes : Form
    {
        accesoDB acceso = new accesoDB();
        List<Paciente> lpacientes = new List<Paciente>();
        public frmPacientes()
        {
            InitializeComponent();
        }

        private void habilitar(bool x)
        {
            txtNombre.Enabled = !x;
            txtNroHC.Enabled = !x;
            cboObraSocial.Enabled = !x;
            dtpFechaNacimiento.Enabled = !x;
            rbtFemenino.Enabled = !x;
            rbtMasculino.Enabled = !x;
            btnGrabar.Enabled = !x;
            btnEditar.Enabled = x;
            btnSalir.Enabled = x;
            chkObraSocial.Enabled = !x;

        }


        private void habilitarcbo(bool x)
        {
            cboObraSocial.Enabled = !x;
        }
        private void limpiar()
        {
            txtNombre.Text = "";
            txtNroHC.Text = "";
            cboObraSocial.SelectedValue = -1;
            dtpFechaNacimiento.Value = DateTime.Today;
            rbtFemenino.Checked = false;
            rbtMasculino.Checked = false;
            chkObraSocial.Checked = false;

        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            limpiar();
            habilitar(true);
            cargarCombo();
            cargarLista();
            cboObraSocial.Text = ("particular");

        }

        private void cboObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                

            
        }

        private void cargarCombo()
        {

            
            DataTable tabla = acceso.consultaDB("SELECT * FROM ObrasSociales");
            cboObraSocial.DataSource = tabla;
            cboObraSocial.DisplayMember = "NombreObraSocial";
            cboObraSocial.ValueMember = "IdObraSocial";
            cboObraSocial.DropDownStyle = ComboBoxStyle.DropDownList;
           
        }


        private void cargarLista()
        {
            lpacientes.Clear();
            lstPacientes.Items.Clear();
            DataTable tabla = acceso.consultaDB("SELECT * FROM Pacientes");
            foreach (DataRow dr in tabla.Rows)
            {
                Paciente p = new Paciente();
                p.Nombre = Convert.ToString(dr["nombre"]);
                p.NumeroHC = Convert.ToInt32(dr["numeroHC"]);
                p.ObraSocial = Convert.ToInt32(dr["ObraSocial"]);
                p.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                p.Sexo = Convert.ToInt32(dr["sexo"]);
                lpacientes.Add(p);
                lstPacientes.Items.Add(p);


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            habilitar(false);
            btnSalir.Enabled = true;
            habilitarcbo(true);


            
        }

        private bool validar()
        {
            bool valido = true;

            if(txtNombre.Text == "")
            {
                MessageBox.Show("debe ingresar un nombre");
                valido = false;
                txtNombre.Focus();
            }
            if (txtNroHC.Text == "")
            {
                MessageBox.Show("debe ingresar un codigo");
                valido =false;
                txtNroHC.Focus();
            }
            if(cboObraSocial.SelectedIndex == -1)
            {
                MessageBox.Show("debe marcar una de las opciones");
                valido=false;
                cboObraSocial.Focus();

            }
            if(dtpFechaNacimiento.Value.Year - DateTime.Now.Year > 21)
            {
                MessageBox.Show("el paciente debe tener menos de 21 años");
                valido = false;
                dtpFechaNacimiento.Focus();
            }
            if(!rbtFemenino.Checked && !rbtMasculino.Checked)
            {
                MessageBox.Show("debe marcar una de las opciones");
                valido = false;



            }

            return valido;

        }


        

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Paciente p = new Paciente();

                p.NumeroHC = Convert.ToInt32(txtNroHC.Text);
                p.ObraSocial = Convert.ToInt32(cboObraSocial.SelectedIndex);
                p.Nombre = txtNombre.Text;
                p.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value);
               if(rbtFemenino.Checked)
                {
                    p.Sexo = 1;
                }
                else
                {
                    p.Sexo = 2;
                }

                string SQL = "UPDATE Pacientes SET nombre = '" + p.Nombre + "'," +
                    "obraSocial =" + p.ObraSocial + "," +
                    "sexo = "+  p.Sexo + ","  +
                    "FechaNacimiento = '" + p.FechaNacimiento + "' WHERE numeroHC =" + p.NumeroHC;
                acceso.OBD(SQL);
                cargarLista();
                MessageBox.Show("el paciente se actualizo exitosamente");

                
            }
            
            habilitar(true);
            

           
          

            
           
           
        }



        private void cargarCampos(int posicion)
        {
            txtNombre.Text = lpacientes[posicion].Nombre;
            txtNroHC.Text = lpacientes[posicion].NumeroHC.ToString();
            cboObraSocial.SelectedValue = lpacientes[posicion].ObraSocial;
            dtpFechaNacimiento.Value = lpacientes[posicion].FechaNacimiento;
            if (lpacientes[posicion].Sexo == 1)
            {
                rbtFemenino.Checked = true;
            }
            else
            {
                rbtMasculino.Checked = true;
            }

        }

        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstPacientes.SelectedIndex);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("esta seguro de que desea salir?", "SALIR", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)== DialogResult.Yes)
            {
                Close();
            }
        }

        private void chkObraSocial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkObraSocial.Checked)
            {
                habilitarcbo(false);
            }
            else
            {
                habilitarcbo(true);
                
                
            }

        }
    }
}

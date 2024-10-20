using DatosAcceso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDapper
{
    public partial class Form1 : Form
    {
        CustomerRepository CustomersR = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                CustomerID = txbCustomerID.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTittle.Text,
                Address = txbAddress.Text
            };

            return nuevo;
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = CustomersR.ObtenerTodo();
            dgvCustomers.DataSource = cliente;
        }

        private void btnObtenerID_Click(object sender, EventArgs e)
        {
            var cliente = CustomersR.ObtenerPorID(txbObtenerID.Text);
            List<Customers> Lista = new List<Customers>
            {
              cliente
            };
            if (cliente != null)
            {
                llenarCampos(cliente);
            }
            dgvCustomers.DataSource = Lista;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearCliente();
            var insertado = CustomersR.insertarCliente(nuevoCliente);
            MessageBox.Show($"{insertado} registros insertados");

        }

        private void llenarCampos(Customers customers)
        {
            txbCustomerID.Text = customers.CustomerID;
            txbContactTittle.Text = customers.ContactTitle;
            txbContactName.Text = customers.ContactName;    
            txbCompanyName.Text = customers.CompanyName;    
            txbAddress.Text = customers.Address;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var actualizado = CrearCliente();
            var actualizados = CustomersR.Update(actualizado);
            var cliente = CustomersR.ObtenerPorID(actualizado.CustomerID);
            dgvCustomers.DataSource = new List<Customers> { cliente };


            MessageBox.Show($"filas actualizadas {actualizados} , {actualizado.CustomerID}");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminadas = CustomersR.Eliminar(txbObtenerID.Text);
            MessageBox.Show($"Se ha eliminado {eliminadas} filas de manera correcta");

        }
    }

    
}


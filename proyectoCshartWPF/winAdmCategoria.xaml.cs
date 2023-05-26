using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using DAO;//PARA USAR DAO AGREGO REFERENCIA
using DAO.Models;
using DAO.Implementacion;
using System.Data;

namespace proyectoCshartWPF
{
    /// <summary>
    /// Lógica de interacción para winAdmCategoria.xaml
    /// </summary>
    public partial class winAdmCategoria : Window
    {
        Categoria t;
        CategoriaImp impCategoria;
        byte opcion = 0;
        public winAdmCategoria()
        {
            InitializeComponent();
            Select();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void EnableSave() {
            btnInsert.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnUpdate.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;

            txtnombre.IsEnabled = true;
            txtdescripcion.IsEnabled = true;

            txtnombre.Focus();
        }
        void DesableSave() {
            btnInsert.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;

            txtnombre.Text = "";
            txtdescripcion.Text = "";

            txtnombre.IsEnabled = false;
            txtdescripcion.IsEnabled = false;

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            opcion = 1;

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableSave();
            opcion = 2;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DesableSave();
        }

        void Select() {
            try
            {
                impCategoria = new CategoriaImp();
                dtcategorias.ItemsSource = null;
                dtcategorias.ItemsSource = impCategoria.Select().DefaultView;
                //dtcategorias.Columns[0].Visibility= Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (opcion) {
                case 1:
                    //guardar
                    t = new Categoria(txtnombre.Text, txtdescripcion.Text);
                    try
                    {
                        impCategoria = new CategoriaImp();
                        int n = impCategoria.Insert(t);
                        if (n > 0) {
                            MessageBox.Show("Registro Insertado con Exito");
                            Select();
                            DesableSave();
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 2:
                    //actualizar
                    t.Nombre=txtnombre.Text;
                    t.Descripcion= txtdescripcion.Text;
                    try
                    {
                        impCategoria = new CategoriaImp();
                        int n=impCategoria.Update(t);
                        if(n > 0)
                        {
                            MessageBox.Show("Registro Actualizado");
                            Select();
                            DesableSave();
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    break;
            }
        }

        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (t != null && dtcategorias.SelectedItem != null)
            {
                if (MessageBox.Show("Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        impCategoria = new CategoriaImp();
                        int n = impCategoria.Delete(t);
                        if (n > 0)
                        {
                            MessageBox.Show("Regitro eliminado con exito");
                            Select();
                            txtnombre.Text = "";
                            txtdescripcion.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            else {
                MessageBox.Show("ELIJAA");
            }
        }

        private void dtcategorias_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (dtcategorias.Items.Count > 0 && dtcategorias.SelectedItem != null)
            {
                try
                {
                    DataRowView row = (DataRowView)dtcategorias.SelectedItem;
                    byte id = byte.Parse(row.Row.ItemArray[0].ToString());

                    t = null;
                    impCategoria = new CategoriaImp();
                    t = impCategoria.Get(id);
                    if (t != null)
                    {
                        txtnombre.Text = t.Nombre;
                        txtdescripcion.Text = t.Descripcion;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
    }
}

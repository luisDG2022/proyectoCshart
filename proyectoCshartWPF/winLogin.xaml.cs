using System;
using System.Collections.Generic;
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
using DAO.Models;
using DAO.Implementacion;
using System.Data;

namespace proyectoCshartWPF
{
    /// <summary>
    /// Lógica de interacción para winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        public winLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioImp impUsuario = new UsuarioImp();
                DataTable tabla =  impUsuario.login(txtusuario.Text, txtcontrasenia.Password);
                if (tabla.Rows.Count > 0)
                {
                    //valores de sesion
                    SesionClass.SessionID = byte.Parse(tabla.Rows[0][0].ToString());
                    SesionClass.SessionFullName = tabla.Rows[0][1].ToString();
                    SesionClass.SessionRole = tabla.Rows[0][2].ToString();
                    SesionClass.SessionUserName = tabla.Rows[0][3].ToString();

                    winAdministrador winAdministrador = new winAdministrador();
                    winCajero winCajero = new winCajero();
                    switch (SesionClass.SessionRole) {
                        case "Administrador":
                            
                            winAdministrador.Show();
                            this.Visibility = Visibility.Hidden;
                            break;
                        case "Cajero":
                            
                            winCajero.Show();   
                            winAdministrador.Visibility = Visibility.Hidden;
                            break;
                    }
                    
                }
                else {
                    lblmensaje.Content = "nombre usuario o contrasena incorrctos";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

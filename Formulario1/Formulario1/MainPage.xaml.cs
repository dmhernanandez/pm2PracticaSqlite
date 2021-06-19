using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Formulario1.NewFolder4;
namespace Formulario1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void btnVerLista_Clicked(object sender, EventArgs e)
        { 
      //      Task<Persona> = App.GetDataBase.GetAllPersons();
            await Navigation.PushAsync(new Lista());
        }

        private async void btnEnviar_Clicked(object sender, EventArgs e)
        {
            //Validamos que al menos el nombre no este vacio
           if(!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text))
            {
                DateTime FechaNacimiento = dpkFecha.Date; //Guardamos la fecha para despues guardar unicamente el valor de fecha
               if(string.IsNullOrEmpty(txtId.Text))
                {
                   await App.GetDataBase.GuardarPersona(
                    new Persona
                    {

                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        FechaNacimiento = FechaNacimiento.ToShortDateString()
                    });

                }
                else
                {
                  await App.GetDataBase.UpdatePersonAsync(
                   new Persona
                   {
                       Id = Convert.ToInt32(txtId.Text),
                       Nombre = txtNombre.Text,
                       Apellido = txtApellido.Text,
                       Correo = txtCorreo.Text,
                       FechaNacimiento = FechaNacimiento.ToShortDateString()
                   });
                }   
                txtId.Text = "";
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtCorreo.Text = "";
             //   dpkFecha = DateTime.Now();
               
               
            }
           
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
    }
}

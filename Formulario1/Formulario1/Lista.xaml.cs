using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Formulario1.NewFolder4;
namespace Formulario1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {

        private Persona personaSeleccionada;
        public Lista()
        {
          
            InitializeComponent();

        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaPersonas.ItemsSource = await App.GetDataBase.GetAllPersons();
        }

        private async void ListaPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            personaSeleccionada = e.SelectedItem as Persona;
            await DisplayAlert("Eliminar personas", "¿Desea eliminar a esta persona?", "Si", "No");
            //await  DisplayAlert("Persona Seleccionada","ID = "+seleccionado.Id,"Cancelar");
        }

        private void btnBorrar_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnBorrar_Clicked_1(object sender, EventArgs e)
        {

            if (personaSeleccionada != null)
            {
                bool respuesta = await DisplayAlert("Eliminar personas", "¿Desea eliminar a esta persona?", "Si", "No");
                if (respuesta)
                {
                   await App.GetDataBase.DeletePersonAsync(personaSeleccionada);
                    personaSeleccionada = null;
                }
            }
            else
                await DisplayAlert("Aviso","Debe seleccionar una fila","Listo");

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (personaSeleccionada != null)
            { 
                    var datos = new {
                    Id = personaSeleccionada.Id,
                    Nombre = personaSeleccionada.Nombre,
                    Apellido = personaSeleccionada.Apellido,
                    Correo = personaSeleccionada.Correo,
                    FechaNacimiento = Convert.ToDateTime(personaSeleccionada.FechaNacimiento)
                };
                    var secondPage = new MainPage();
                    secondPage.BindingContext = personaSeleccionada;
                    await Navigation.PushAsync(secondPage);
             
            }
            else
                await DisplayAlert("Aviso", "Debe seleccionar una fila", "Listo");
        }

  

  
    }
}
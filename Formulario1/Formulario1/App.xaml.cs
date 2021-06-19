using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Formulario1.ManagerDataBase;
using System.IO;
namespace Formulario1
{
    public partial class App : Application
    {
        /*
         Se crea una instacia de la clase que maneja la base de datos, se declara privada y estatica
        de manera que persista durante la vida de la aplicación, pero que solo sea accesible por medio del 
        metodo getDB
         */
        static DataBase instanciaDB;


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public  App(string dbpath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());


        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
        //Con este metodo se accede a la base de datos una vez que se ha creado
        public static DataBase GetDataBase
        {
            get{
                if(instanciaDB == null)
                {
                    string dbname = "dbdany.sqlite";
                    string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                    // Se unen las dos rutas para formar el espacio donde se almacenara la DB
                    string finalpath = Path.Combine(folderpath, dbname); 
                    
                    //Se crea una instancia de la base de datos
                    instanciaDB = new DataBase(finalpath);

                    }
                return instanciaDB;
            }
        }
    }
}

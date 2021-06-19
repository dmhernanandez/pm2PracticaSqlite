using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Formulario1.NewFolder4;

namespace Formulario1.ManagerDataBase
{
   
   public  class DataBase
    {   
        readonly SQLiteAsyncConnection dataBase;
     
        public DataBase(String finalpath)
        {
            dataBase = new SQLiteAsyncConnection(finalpath);
            dataBase.CreateTableAsync<Persona>(); //Se crea la tabla Persona, sin embargo el metodo Wait() especifica que debe esperar que se termine la tarea
        }

        //Metodo para guardar un nuevo registro en la BD
        public Task<int> GuardarPersona( Persona persona)
        {
           
                return dataBase.InsertAsync(persona);
               
        }

        public Task<List<Persona>> GetAllPersons()
        {
            return dataBase.Table<Persona>().ToListAsync();

        }
    
        //Elimina una persona de la base de datos
        public Task<int> DeletePersonAsync(Persona persona) 
        {
            return dataBase.DeleteAsync(persona);
        }

        //Actualiza los datos de una persona
        public Task<int> UpdatePersonAsync(Persona persona)
        {
            return dataBase.UpdateAsync(persona);
        }
    }
}

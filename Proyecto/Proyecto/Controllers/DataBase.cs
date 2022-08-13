using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;
using SQLite;

namespace Proyecto.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            dbase.CreateTableAsync<Persistencia>();
            dbase.CreateTableAsync<Productos>();
            dbase.CreateTableAsync<Usuario>();
            dbase.CreateTableAsync<User>();
        }

        #region Persistencia
        public async Task<int> PersistenciaSave(Persistencia persistencia)
        {
            var registro = await obtenerPersistencia(persistencia.Id);

            if (registro != null) {  return await dbase.UpdateAsync(persistencia); }

            return await dbase.InsertAsync(persistencia);
        }

        // Read
        public Task<List<Persistencia>> obtenerListaPersistencia()
        {
            return dbase.Table<Persistencia>().ToListAsync();
        }

        // Read V2
        public Task<Persistencia> obtenerPersistencia(int pid)
        {
            return dbase.Table<Persistencia>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> PersistenciaDelete(Persistencia persistencia)
        {
            return dbase.DeleteAsync(persistencia);
        }

        //Delete ALL
        public Task<int> PersistenciaDeleteAll()
        {
            return dbase.DropTableAsync<Persistencia>();
        }
        #endregion

        
        #region Usuario
        // CRUD - Create - Read - Update - Delete
        // Create
        public Task<int> UsuarioSave(User usuario)
        {
            if (usuario.Id != 0)
            {
                return dbase.UpdateAsync(usuario); // Update
            }
            else
            {
                return dbase.InsertAsync(usuario);
            }
        }

        public async Task<int> ListaUsuarioSave(List<Usuario> usuario)
        {
            for (int i = 0; i < usuario.Count; i++)
            {
                var user = await obtenerUsuario(2, usuario[i].correo);

                if (user == null) { await dbase.InsertAsync(usuario[i]); }
                else { await dbase.UpdateAsync(usuario[i]); }
            }

            return 1;
        }

        // Read
        public Task<List<Usuario>> obtenerListaUsuario()
        {
            return dbase.Table<Usuario>().ToListAsync();
        }

        // Read un registro
        public Task<User> obtenerUsuario(int operacion, string dato)
        {
            

            switch (operacion)
            {
                case 1:
                    int usuarioid = int.Parse(dato);
                    return dbase.Table<User>()
                    .Where(i => i.Id == usuarioid)
                    .FirstOrDefaultAsync();
                case 2:
                    return dbase.Table<User>()
                    .Where(i => i.nombre == dato)
                    .FirstOrDefaultAsync();
                case 3:
                    return dbase.Table<User>()
                    .Where(i => i.correo == dato)
                    .FirstOrDefaultAsync();
                case 4:
                    return dbase.Table<User>()
                    .Where(i => i.telefono == dato)
                    .FirstOrDefaultAsync();
                case 5:
                    return dbase.Table<User>()
                    .Where(i => i.apellido == dato)
                    .FirstOrDefaultAsync();
                case 6:
                    return dbase.Table<User>()
                    .Where(i => i.uid == dato)
                    .FirstOrDefaultAsync();
            }

            return null;
        }
        #endregion

        #region cuenta
        public async Task<int> CuentaSave(int operacion, User cuenta)
        {
            //1 Save
            //2 Update

            //RETURNS
            //2 ya existe una cuenta con ese codigo de cuenta
            //3 el usuario ya tiene 2 cuentas, no puede crear más

            switch (operacion)
            {
                case 1:
                    if (await obtenerCuenta(cuenta.correo) == null)
                    {
                        /*List<Cuenta> cuentas = new List<Cuenta>();
                        cuentas = await obtenerCuentasUsuario(cuenta.CodigoUsuario);

                        if(cuentas.Count >= 2)
                        {
                            return 3;
                        }
                        else
                        {
                            return await dbase.InsertAsync(cuenta);
                        }*/

                        return await dbase.InsertAsync(cuenta);
                    }
                    else
                    {
                        return 2;
                    }
                case 2:
                    return await dbase.UpdateAsync(cuenta); // Update
            }

            return 0;
        }

        // Read un registro
        public Task<User> obtenerCuenta(string ccuenta)
        {
            return dbase.Table<User>()
                    .Where(i => i.correo == ccuenta)
                    .FirstOrDefaultAsync();
        }

        public Task<User> obtenerCuentaUser(int operacion, string dato)
        {


            switch (operacion)
            {
                case 1:
                    int usuarioid = int.Parse(dato);
                    return dbase.Table<User>()
                    .Where(i => i.Id == usuarioid)
                    .FirstOrDefaultAsync();
                case 2:
                    return dbase.Table<User>()
                    .Where(i => i.nombre == dato)
                    .FirstOrDefaultAsync();
                case 3:
                    return dbase.Table<User>()
                    .Where(i => i.correo == dato)
                    .FirstOrDefaultAsync();
                case 4:
                    return dbase.Table<User>()
                    .Where(i => i.telefono == dato)
                    .FirstOrDefaultAsync();
                case 5:
                    return dbase.Table<User>()
                    .Where(i => i.apellido == dato)
                    .FirstOrDefaultAsync();
                case 6:
                    return dbase.Table<User>()
                    .Where(i => i.uid == dato)
                    .FirstOrDefaultAsync();
            }

            return null;
        }
        #endregion
    }
}
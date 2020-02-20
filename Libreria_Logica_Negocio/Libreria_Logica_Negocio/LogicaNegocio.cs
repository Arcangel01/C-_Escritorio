using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibConexionBD;
using LibLlenarGrids;

namespace Libreria_Logica_Negocio
{
    public class LogicaNegocio
    {
        #region Atributos
        private string Error,Nombre, Apellido, Identificacion;
        private int Edad;
        SqlDataReader objReader;
        #endregion
        #region Constructor
        public LogicaNegocio()
        {
            Nombre = "";
            Apellido = "";
            Identificacion = "";
            Edad1 = 0;
        }
        #endregion
        #region Propiedades 
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public string Identificacion1 { get => Identificacion; set => Identificacion = value; }
        public string Error1 { get => Error; set => Error = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public SqlDataReader ObjReader { get => objReader; set => objReader = value; }
        #endregion
        #region Metodos Publicos
        public bool ConsultarP()
        {
            if (Nombre == "")
            {
                Error = "Ingresa un nombre Valido";
                return false;
            }
            ClsConexion br = new ClsConexion();
            string Sentencia = "SP_BUSCAR_USER '" + Identificacion + "'";
            if (!br.Consultar(Sentencia, false))
            {
                objReader = br.Reader;
                br = null;
                return true;
            }
            else
            {
                Error = br.Error;
                br = null;
                return false;
            }
        }
        public bool Registrar()
        {
            ClsConexion br = new ClsConexion();
            if (!ValidarP())
            {
                MessageBox.Show(Error);
                return false;
            }
            else
            {
                try {
                    string Sentencia = "SP_INSERT_USER '" + Identificacion + "','" + Nombre + "','" + Apellido + "','" + Edad + "'";
                    if (!br.EjecutarSentencia(Sentencia, false))
                    {
                        Error = br.Error;
                        br = null;
                        return false;
                    }
                    br = null;
                    return true;

                } catch(Exception m)
                {
                    Error = m.Message;
                    return false;
                }
            }
        }
        public bool Actualizar()
        {
            ClsConexion br = new ClsConexion();
            if (!ValidarP())
            {
                MessageBox.Show(Error);
                return false;
            }
            else
            {
                try
                {
                    string Sentencia = "SP_UPDATE_USER '" + Identificacion + "'";
                    if (!br.EjecutarSentencia(Sentencia, false))
                    {
                        Error = br.Error;
                        br = null;
                        return false;
                    }
                    br = null;
                    return true;

                }
                catch (Exception m)
                {
                    Error = m.Message;
                    return false;
                }
            }
        }
        public bool Eliminar()
        {
            ClsConexion br = new ClsConexion();
            if (!ValidarP())
            {
                MessageBox.Show(Error);
                return false;
            }
            else
            {
                try
                {
                    string Sentencia = "SP_DELETE_USER '" + Identificacion + "'";
                    if (!br.EjecutarSentencia(Sentencia, false))
                    {
                        Error = br.Error;
                        br = null;
                        return false;
                    }
                    br = null;
                    return true;

                }
                catch (Exception m)
                {
                    Error = m.Message;
                    return false;
                }
            }
        }
        public bool Listar(DataGridView grd)
        {
            try
            {
                ClsLLenarGrids grid = new ClsLLenarGrids();
                grid.SQL = "SP_LISTAR ";
                grid.NombreTabla = "Users";
                if (!grid.LlenarGrid(grd))
                {
                    Error = grid.ERROR;
                    grid = null;
                    return false;
                }
                grid = null;
                return true;
            }
            catch (Exception x)
            {
                Error = x.Message;
                return false;
            }
        }
        #endregion
        #region Metodos privados
        private bool ValidarP()
        {
           if (Nombre == "")
            {
                Error = "Ingresa un nombre Valido";
                return false;
            }
            if (Apellido == "")
            {
                Error = "Ingresa un apellido Valido";
                return false;
            }
            if (Edad < 0)
            {
                Error = "Ingresa una edad Valida";
                return false;
            }
            if (Identificacion == "")
            {
                Error = "Ingresa una identificacion Valida";
                return false;
            }
            return true;
        }
        #endregion
    }
}

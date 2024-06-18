namespace HelpPeople.Generic
{
    public class HelpPeopleMessages
    {
        ///************************************************************************ 
        /// SUCCESS MESSAGES ********************************************************
        /// ***********************************************************************
        public static string SUCCES001 = "Consulta realizada de forma exitosa";
        public static string SUCCES002 = "Registro eliminado de forma exitosa";


        ///************************************************************************ 
        /// ERROR MESSAGES ********************************************************
        /// ***********************************************************************

        public static string ERROR001 = "Error al consultar en la base de datos";
        public const string _ERROR002 = "El campo '{0}' no es valido";
        public static string ERROR002(string campo)
        {
            return string.Format(_ERROR002, campo);
        }

        public static string ERROR003 = "El registro que desea ingresar ya existe";
        public static string ERROR004 = "Error al guardar en la base de datos";
        public static string ERROR005 = "El registro consultado no existe";
        public static string ERROR006 = "El registro no se pudo eliminar de forma exitosa";
        public const string _ERROR007 = "Los campos '{0}' no son validos";
        public static string ERROR007(string campo)
        {
            return string.Format(_ERROR007, campo);
        }
        public const string _ERROR008 = "Error al consultar en la base de datos";
    }
}

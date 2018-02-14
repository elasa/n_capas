using agenda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Test_N_capas.Clases.Negocio
{
    public class Agenda : Entidad.Telefono
    {
        Conexion conexion = new Conexion();

        public Agenda()
        {

        }

        public DataTable getTablaAgenda()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select t.Id as ID, t.numeroTelefono as Telefono, t.idUsuario as idUsuario, u.nombre as Nombres, u.correo as 'Correo electónico'");
            sb.AppendLine("from Telefono as t inner join Usuario as u on t.idUsuario = u.Id");
            sb.AppendLine("where t.estado='Activo'");

            DataTable dt = conexion.getDataTable(sb.ToString());
            return dt;
        }

        public DataTable getTablaAgendaByID(int idTelefono)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select t.Id as ID, t.numeroTelefono as Telefono, u.nombre as Nombres, u.correo as 'Correo electónico'");
            sb.AppendLine("from Telefono as t inner join Usuario as u on t.idUsuario = u.Id where t.id="+idTelefono);

            DataTable dt = conexion.getDataTable(sb.ToString());
            return dt;
        }

        public DataTable getUsusrios()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select id, nombre, correo from usuario");
            DataTable dt = conexion.getDataTable(sb.ToString());
            return dt;
        }

        public void addTelefono(int idUsuario, int numeroTelefono, string estado)
        {
            conexion.updateQuery("insert into telefono(idUsuario,numeroTelefono,estado) values("+idUsuario+","+numeroTelefono+",'"+estado+"')");

        }

        public void updateTelefono(int id, int idUsuario, int numeroTelefono, string estado)
        {

            conexion.updateQuery("update Telefono set idUsuario="+idUsuario+",numeroTelefono="+numeroTelefono+",estado='"+estado+"' where id="+id);
        }

        public void updateTelefonoExiste(int id, int idUsuario, string estado)
        {

            conexion.updateQuery("update Telefono set idUsuario=" + idUsuario +",estado='" + estado + "' where id=" + id);
        }

        public void updateEstado(int id, string estado)
        {
            conexion.updateQuery("update Telefono set estado='"+estado+"' where id="+id);
        }

        public DataTable getTelefonosTEST(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select t.Id as ID, t.numeroTelefono as Telefono, t.idUsuario as idUsuario, u.nombre as Nombres, u.correo as 'Correo electónico'");
            sb.AppendLine("from Telefono as t inner join Usuario as u on t.idUsuario = u.Id");
            sb.AppendLine("where t.estado='Activo' and t.id="+id);
            DataTable dt = conexion.getDataTable(sb.ToString());
            return dt;
        }

        public int telefonoExiste(int telefono)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*) from Telefono as t left join Usuario as u on t.idUsuario = u.Id");
            sb.AppendLine("where t.numeroTelefono="+telefono);
            return conexion.getCount(sb.ToString()); // revisar consulta....zzz..
        }

        //ddl cascada pais ciudad 

        public DataTable get_pais_cascade()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select id,nombre from Pais where estado='Activo'");
            DataTable dt = conexion.getDataTable(sb.ToString());
            return dt;
        }

        public DataTable get_ciudad_cascade(int idpais)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select id, nombre from Ciudad where idPais="+ idpais + "");
            sb.AppendLine("and estado='Activo'");
            DataTable dt = conexion.getDataTable(sb.ToString());
            return dt;
        }
    }
}
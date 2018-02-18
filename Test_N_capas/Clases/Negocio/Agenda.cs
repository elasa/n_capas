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

        public Agenda(int id, int idUsuario, int telefonos, string estado, int idPais, int idCiudad)
        {
            Id = id;
            IdUsuario = idUsuario;
            Telefonos = telefonos;
            Estado = estado;
            IdPais = idPais;
            IdCiudad = idCiudad;
        }

        public Agenda(int id)
        {

            DataTable dt = conexion.getDataTable("SELECT id, idUsuario, numeroTelefono, estado, idPais, idCiudad FROM telefono WHERE id=" + id);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                Id = int.Parse(row["id"].ToString());

                if (IdUsuario != 0 && Telefonos != 0 && !String.IsNullOrEmpty(Estado) && IdPais != 0 && IdCiudad != 0)
                {
         
                    IdUsuario = int.Parse(row["idUsuario"].ToString());
                    Telefonos = int.Parse(row["numeroTelefono"].ToString());
                    Estado = row["estado"].ToString();
                    IdPais = int.Parse(row["idPais"].ToString());
                    IdCiudad = int.Parse(row["idCiudad"].ToString());
                }
            }
        }

        public void update()
        {
            StringBuilder sb = new StringBuilder();

            if (IdUsuario != 0 && Telefonos != 0 && !String.IsNullOrEmpty(Estado) && IdPais != 0 && IdCiudad != 0)
            {
                sb.AppendLine("UPDATE telefono");
                sb.AppendLine("SET idUsuario=" + IdUsuario + ",numeroTelefono=" + Telefonos + ",estado='" + Estado + "', idPais=" + IdPais + ", idCiudad=" + IdCiudad + "");
                sb.AppendLine("WHERE id=" + Id);
                conexion.updateQuery(sb.ToString());
            }
            else
            {
                sb.AppendLine("UPDATE telefono SET idUsuario=");

                if(IdUsuario == 0)
                {
                    sb.Append("NULL");
                }
                else
                {
                    sb.Append(IdUsuario.ToString());
                }

                sb.AppendLine(", numeroTelefono="+Telefonos+", estado='"+Estado+"',idPais=");

                if(IdPais == 0){

                    sb.Append("NULL");
                }
                else
{
                    sb.Append(IdPais.ToString());
                }

                sb.AppendLine(", idCiudad=");
                
                if(IdCiudad == 0)
                {
                    sb.Append("NULL");
                }
                else
                {
                    sb.Append(IdCiudad.ToString());
                }

                sb.AppendLine(" WHERE id="+Id+"");

                conexion.updateQuery(sb.ToString());
            }
                
            
        }

        public void insert()
        {
            StringBuilder sb = new StringBuilder();

            if (telefonoExiste(Telefonos) == 0 && Telefonos != 0)
            {
                if (IdUsuario != 0 && Telefonos != 0 && !String.IsNullOrEmpty(Estado) && IdPais != 0 && IdCiudad != 0)
                {
                    sb.AppendLine("INSERT INTO telefono(idUsuario, numeroTelefono, estado, idPais, idCiudad)");
                    sb.AppendLine("VALUES(" + IdUsuario + "," + Telefonos + ",'" + Estado + "', " + IdPais + ", " + IdCiudad + ")");
                    conexion.updateQuery(sb.ToString());
                }
                else
                {
                    sb.AppendLine("INSERT INTO telefono(idUsuario, numeroTelefono, estado, idPais, idCiudad)");
                    sb.AppendLine("VALUES(");

                    if (IdUsuario == 0)
                    {
                        sb.Append("NULL");
                    }
                    else
                    {
                        sb.Append(IdUsuario.ToString());
                    }

                    sb.AppendLine("," + Telefonos + ",'" + Estado + "',");

                    if (IdPais == 0)
                    {
                        sb.Append("NULL");
                    }
                    else
                    {
                        sb.Append(IdPais.ToString());
                    }

                    sb.AppendLine(",");

                    if(IdCiudad == 0)
                    {
                        sb.Append("NULL");
                    }
                    else
                    {
                        sb.Append(IdCiudad.ToString());
                    }

                    sb.AppendLine(")");

                    conexion.updateQuery(sb.ToString());
                }
            }
        }

        public DataTable getTablaAgenda()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT t.Id AS ID, t.numeroTelefono AS Telefono, t.idUsuario AS idUsuario, ISNULL(u.nombre,'No asignado') AS Nombres, t.idPais AS IdPais, p.nombre AS Pais, t.idCiudad AS IdCiudad, c.nombre AS Ciudad");
            sb.AppendLine("FROM Telefono AS t LEFT JOIN Usuario AS u ON t.idUsuario = u.Id");
            sb.AppendLine("LEFT JOIN Pais AS p ON t.idPais = p.Id");
            sb.AppendLine("LEFT JOIN Ciudad AS c ON t.idCiudad = c.Id");
            sb.AppendLine("WHERE t.estado='Activo'");
            sb.AppendLine("ORDER BY t.id ASC");


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
            sb.AppendLine("select count(*) from Telefono where numeroTelefono="+telefono+"");
            return conexion.getCount(sb.ToString()); 
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
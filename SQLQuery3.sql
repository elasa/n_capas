select t.Id as ID, t.numeroTelefono as Telefono, t.idUsuario as idUsuario, ISNULL(u.nombre,'No asignado') as Nombres, p.nombre as Pais, c.nombre as Ciudad
from Telefono as t left join Usuario as u on t.idUsuario = u.Id 
left join Pais as p on t.idPais = p.Id
left join Ciudad as c on t.idCiudad = p.Id 
where t.estado='Activo' 
order by t.id asc
select COUNT(*) from Telefono

select id, nombre from Ciudad where idPais=3

update Telefono set idCiudad=NULL where id=1

select * from Ciudad

select * from Telefono
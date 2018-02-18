

select t.Id as ID, t.numeroTelefono as Telefono, t.idUsuario as idUsuario, 
ISNULL( u.nombre,'No asignado') as Nombres, u.correo as 'Correo electónico'
from Telefono as t left join Usuario as u on t.idUsuario = u.Id
where t.estado='Activo'

select t.Id as ID, t.numeroTelefono as Telefono, t.idUsuario as idUsuario, 
u.nombre as Nombres, u.correo as 'Correo electónico'
from Telefono as t left join Usuario as u on t.idUsuario = u.Id
where t.estado='Activo'
select count(*) from Telefono

--truncate table Telefono

insert into Usuario(nombre, correo) values('Matt Huston','mhuston@mail.com')


select * from Usuario

select * from Telefono
select count(*) from Telefono where numeroTelefono=3



--INSERT INTO telefono(idUsuario, numeroTelefono, estado, idPais, idCiudad)
--VALUES(NULL,4,'Activo',NULL,NULL)
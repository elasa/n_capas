select u.nombre,t.numeroTelefono,t.estado from Telefono as t left join Usuario as u on t.idUsuario = u.Id

select * from Telefono


--insert into Usuario(nombre,correo) values('Romina Asencio','rasencio@gmail.com')
select * from Usuario

update Usuario set nombre='Marcela Jimenez', correo='mjimenex@gmail.com' where id=6

--update Telefono set estado ='Activo'

select count(*) from Telefono as t left join Usuario as u on t.idUsuario = u.Id
where u.nombre ='Martin Carcamo' and t.numeroTelefono=212223 and t.estado='Activo'

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Permiso
	DROP CONSTRAINT FK_Permiso_TipoPermiso
GO
ALTER TABLE dbo.TipoPermiso SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Permiso
	DROP COLUMN TipoPermisoId
GO
ALTER TABLE dbo.Permiso SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

drop table TipoPermiso;

insert into Permiso (Nombre) values ('Usuario Basico');
insert into Permiso (Nombre) values ('Administrador');
insert into Permiso (Nombre) values ('Web Master');
insert into Permiso (Nombre) values ('Login');

insert into PermisoPermiso (PermisoId, PermisoPadreId) values (4, 1);
insert into PermisoPermiso (PermisoId, PermisoPadreId) values (4, 2);
insert into PermisoPermiso (PermisoId, PermisoPadreId) values (4, 3);

insert into Usuario (Nombre, Apellido, Telefono, Email, Password)
values ('Admin', 'Administrador', '1149182290', 'admin@mail.com', 'hCVSu+oS1AOpATVrG+BVRWTCQAKpGx9uyA+Tl+Tg6gQ='); -- Password: admin
insert into Usuario (Nombre, Apellido, Telefono, Email, Password)
values ('Usuario', 'Basico', '1149182291', 'usuariobasico@mail.com', 'TRgMIB/OHCpe2yH2MfYsYtgBCVO8v3JYWWo5ivJVaac='); -- Password: usuariobasico
insert into Usuario (Nombre, Apellido, Telefono, Email, Password)
values ('Web', 'Master', '1149182292', 'webmaster@mail.com', '0HoKhyeCMio3BB5aHPABLUATZJWHqPfitHIv6FUsbjk='); -- Password: webmaster

insert into UsuarioPermiso (UsuarioId, PermisoId) values (1, 2);
insert into UsuarioPermiso (UsuarioId, PermisoId) values (2, 1);
insert into UsuarioPermiso (UsuarioId, PermisoId) values (3, 3);
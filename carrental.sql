create database carrental
use carrental

create table client(
idclient int primary key IDENTITY(1,1),
nom_cl varchar(30),
prenom_cl varchar(30),
tel_cl nvarchar(12),
adresse_cl nvarchar(50),
CIN_cl nvarchar(9))

create table contrat(
idcontrat int primary key IDENTITY(1,1),
idclient int foreign key references client(idclient),
date_debut datetime,
date_fin datetime,
montant_contrat money)

create table reservation(
idreserv int primary key IDENTITY(1,1),
idclient int  references client(idclient),
idcar int  references voiture(idcar),
objectif_reserv nvarchar(100),
kilometrage float,
date_debut datetime,
date_fin datetime)

create table voiture(
idcar int primary key IDENTITY(1,1),
idcat int references category(idcat),
idmodele int references modele(idmodele),
immat nvarchar(20),
carte_grise nvarchar(30),
nbporte int,
nbplace int,
puissance int,
date_aquis date,
datedebut_assurance datetime,
datefin_assurance datetime,
cout_assurance money,
typecarburant varchar(30))

create table category(
idcat int primary key identity(1,1),
libelle_cat nvarchar(50))
create table modele(
idmodele int primary key identity(1,1),
nom_modele nvarchar(50))
alter table voiture
add photo nvarchar(50)
create table marque(
idmarque int primary key identity(1,1),
nom_marque varchar(50),
logo nvarchar(100))



-------------------------------

create function ModeleByMarques (@id int)
Returns table 
return select * from dbo.modele where modele.idmarque=@id


create function ReservationByCar (@id int)
Returns table 
return select * from dbo.reservation where reservation.idcar=@id


create function ContratsByClient (@id int)
Returns table 
return select * from dbo.contrat where contrat.idclient=@id


create function ReservationByClient (@id int)
Returns table 
return select * from dbo.reservation where reservation.idclient=@id

create function contratByReservation (@id int)
Returns table 
return select * from dbo.contrat where contrat.idreserv=@id
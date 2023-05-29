use master;

drop database BeyondInfinity;

create database BeyondInfinity


use BeyondInfinity


create table djelatnik(
	id int not null primary key identity(1,1),
	ime varchar(50) not null,
	prezime varchar(50) not null,
	oib char(11),
	kontakt varchar(50),
	jedinstvenibroj int,
	vrsta_djelatnika int not null,	
);




create table korisnik(
	id int not null primary key identity(1,1),
	ime varchar(50) not null,
	prezime varchar(50) not null,
	oib  char(11),
	email varchar(50),
);






create table usluga(
	id int not null primary key identity(1,1),
	Naziv varchar(50),
	destinacija varchar(50),
	nacin_placanja bit,
	cijena decimal (18,2),
	broj_mjesta int,
);


create table usluga_korisnik(
	id int not null primary key identity(1,1),	
	usluga int,
	korisnik int,
	djelatnik int,
	datum datetime,
);



create table vozilo(
	id int not null primary key identity(1,1),
	naziv varchar(50),
	cijena decimal(18,2),
	datum_proizvodnje datetime,
	djelatnik int,
	tezina varchar(50),
);




create table vrsta_djelatnika(
	id int not null primary key identity(1,1),
	naziv varchar(50),
);


alter table djelatnik add foreign key (vrsta_djelatnika) references vrsta_djelatnika(id);
alter table vozilo add foreign key (djelatnik) references djelatnik(id);
alter table usluga_korisnik add foreign key (usluga) references usluga(id);
alter table usluga_korisnik add foreign key (korisnik) references korisnik(id);
alter table usluga_korisnik add foreign key (djelatnik) references djelatnik(id);


insert into korisnik (ime,prezime,oib,email) values('Devon','Wright','40472849171','devonholmes92@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('John','Make','44739201981','JohnMake86@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('Mark','Griffin','28475684917','markgriffinat@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('Luke','Goyle','80472848596','LukeGoyleoat@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('Corry','Holmes','23472192847','cHolmes@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('Kayle','Savannah','80472842342','KayleS@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('Jessy','Blake','23472832463','Jessiokaye@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('Jane','Vayne','82372324523','Vaynework@gmail.com');
insert into korisnik (ime,prezime,oib,email) values('Abby','Dioza','12372832643','abbydioza123@gmail.com');


insert into usluga (Naziv,destinacija,nacin_placanja,cijena,broj_mjesta) values('NovaFlight','ISS','1','80000','12');
insert into usluga (Naziv,destinacija,nacin_placanja,cijena,broj_mjesta) values('Earth','stratosphere','2','26000','18');
insert into usluga (Naziv,destinacija,nacin_placanja,cijena,broj_mjesta) values('Proxima','ProximaB','1','500000','20');
insert into usluga (Naziv,destinacija,nacin_placanja,cijena,broj_mjesta) values('SaturnV','Saturn','1','200000','20');
insert into usluga (Naziv,destinacija,nacin_placanja,cijena,broj_mjesta) values('ToTheMoon','Moon','2','50000','12');
insert into usluga (Naziv,destinacija,nacin_placanja,cijena,broj_mjesta) values('Martian','Mars','2','80000','16');



insert into vrsta_djelatnika (naziv)  values('Pilot');
insert into vrsta_djelatnika (naziv)  values('bookkeeper');
insert into vrsta_djelatnika (naziv)  values('Doctor');
insert into vrsta_djelatnika (naziv)  values('engineer');
insert into vrsta_djelatnika (naziv)  values('HumanResources');
insert into vrsta_djelatnika (naziv)  values('flightcontroller');
insert into vrsta_djelatnika (naziv)  values('maintenance');
insert into vrsta_djelatnika (naziv)  values('Commander');
insert into vrsta_djelatnika (naziv)  values('Lunarmodulepilot');
insert into vrsta_djelatnika (naziv)  values('Consultant');




insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('shaw','murphy','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('peter','Gale','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('mark','murphy','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('cody','zanders','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('neil','guy','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('luka','petrovic','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('theo','walcott','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('yurin','moskovich','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('dale','Roander','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('shaw','Griffin','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('meredith','McCall','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('jane','Shande','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('abby','murphy','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('katherine','lavenheing','06953847591','gmail','849653','1');
insert into djelatnik (ime,prezime,oib,kontakt,jedinstvenibroj,vrsta_djelatnika) values('kane','melvich','06953847591','gmail','849653','1');


insert into vozilo (naziv,cijena,datum_proizvodnje,djelatnik,tezina) values('FalconX','4800000','2023-05-11','1','2000Tons');
insert into vozilo (naziv,cijena,datum_proizvodnje,djelatnik,tezina) values('ELIGIUS','9800000','2023-02-26','2','2100Tons');
insert into vozilo (naziv,cijena,datum_proizvodnje,djelatnik,tezina) values('EarthEx','20000000','2023-12-15','3','3000Tons');
insert into vozilo (naziv,cijena,datum_proizvodnje,djelatnik,tezina) values('Voyager5','1900000','2023-08-14','4','2800Tons');
insert into vozilo (naziv,cijena,datum_proizvodnje,djelatnik,tezina) values('MartianExplorer','1900000','2023-11-04','5','1965Tons');
insert into vozilo (naziv,cijena,datum_proizvodnje,djelatnik,tezina) values('AlphaE','1600000','2023-09-18','6','3100Tons');




insert into usluga_korisnik (usluga,korisnik,djelatnik,datum) values('1','2','3','2024-05-09');
insert into usluga_korisnik (usluga,korisnik,djelatnik,datum) values('1','2','3','2024-11-18');
insert into usluga_korisnik (usluga,korisnik,djelatnik,datum) values('1','2','3','2024-05-24');
insert into usluga_korisnik (usluga,korisnik,djelatnik,datum) values('1','2','3','2024-01-12');
insert into usluga_korisnik (usluga,korisnik,djelatnik,datum) values('1','2','3','2024-02-11');
insert into usluga_korisnik (usluga,korisnik,djelatnik,datum) values('1','2','3','2024-05-14');
AppForNeuralabJobApp
====================

Simple application made by forking Neuralab-public-repo-utilities


Funkcionalnosti aplikacije:
- omogućiti zaposleniku (koji radi u aplikaciji) da dodaje nove usere u bazu
- omogućiti zaposleniku da izlista sve zapise iz baze
- omogućiti zaposleniku da ekporta bazu u XML ili CSV datoteku

Dodaci razvijanja aplikacije:
- kreirana nova stranica UserInput.aspx
- kreirana nova stranica UserInfo.aspx
- kreirana nova metoda generateRandomStringOnInputDictionary unutar klase TextStringUtils
- kreirana nova mapa "doc" unutar projekta za pohranu XML i CSV datoteka
- kreirana nova klasa DataExport
- kreirana nova metoda exportIntoXML unutar klase DataExport
- kreirana nova metoda exportIntoCSV unutar klase DataExport
  - kreirana nova metoda WriteToStream potrebna za exportIntoCSV
  - kreirana nova metoda WriteItem potrebna za exportIntoCSV

Algoritam:
Dodavanje novog usera u bazu (stranica UserInput):
- nakon klika na gumb za upisivanje, aplikacija učitava podatke iz textbox-ova (name,email,note)
- aplikacija provjerava sintaksnu ispravnost email-a uz pomoć metode checkEmailValidation,
  te ukoliko validacija nije uspiješna prikazuje poruku o pogrešci
- aplikacija generira dateString variablu uz pomoć metode enerateStringFromDate
- stringovi name,email,dateString spajaju se i proslijeđuju metodi generateRandomStringOnInputDictionary
  koja generira userKey variablu
- aplikacija zapisuje podatke o novom useru u bazu
Eksportiranje baze usera (UserInfo):
- upisom imena datoteke, te klikom na gumb Export to XML, aplikacija eksporta bazu podataka u XML datoteku
	- pritom provjerava postoji li datoteka istog imena u reprezitoriju i ukoliko postoji ispisuje poruku
- upisom imena datoteke, te klikom na gumb Export to CSV, aplikacija eksporta bazu podataka u CSV datoteku
	- pritom provjerava postoji li datoteka istog imena u reprezitoriju i ukoliko postoji ispisuje poruku
Prikazivanje svih zapisa iz baze usera (UserInfo):
- klikom na gumb "Show user data" aplikacija prikazuje usere u GridView kontroli

Podaci svakog usera u bazi:
ID - indentity column (int - auto increment)
Name - ime usera koje je zaposlenik upisao - obavezno (nvarchar50)
Email - email koji je zaposlenik upisao - obavezno (nvarchar50)
Note - bilješka koju je zaposlenik upisao - maksimalno 50 znakova - obavezno (nvarchar50)
Key - unique userKey - generira aplikacija (nvarchar50)


Dodatne informacije:
Određene funkcionalnosti aplikacije izvedive su puno jednostavnije kao npr. generiranje key-a,
no odlučio sam se za ovakav pristup radi ispunjenja glavnog zadatka (forkanje utilitija)
Imajte na umu da nisam totalni ekspert u programirnaju (iako tome težim) te se prilikom pisanja
programa često polužim google-om kako bi pronašao najefikasniji način izvođenja neke funkcionalnosti
(naravno, ne kod jednostavnih primjera kao što je ova aplikacija).
Imam instaliran VS2010 tako da sam izradio novi projekt i u namespace projekta "učitao" klase iz
reprezitorija.

S poštovanjem, Tomislav Burić ~ virtualist

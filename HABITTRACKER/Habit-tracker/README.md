# HABIT-TRACKER

Questa è la mia prima applicazione C# con l'utilizzo di Sqlite come database per tracciare le abitudini quotidiane.

Essa è un'applicazione CRUD (Create, Read, Update, Delete) che permette agli utenti di monitorare e gestire le loro abitudini giornaliere.

## Requisiti di progetto

- Questa applicazione darà la possibilità di registrare le abitudini quotidiane.
- Le abitudini aggiunte saranno gestite solo in termini di quantità.
- L'applicazione permetterà di aggiungere, visualizzare, modificare ed eliminare le abitudini.
- L'applicazione utilizzerà Sqlite come database per memorizzare le abitudini.
- All'avvio dell'applicazione, verrà creato un database Sqlite se non esiste già.
- All'avvio dell'applicazione, se non esiste già, verranno generate alcune abitudini predefinite per facilitare i test.
- L'applicazione è in grado di gestire tutti i possibili errori cosicché non si possa mai bloccare.
- La comunicazione con il database è gestita con ADO.NET.

## Caratteristiche

- Connessione al database
	-	Il programma utilizza una connessione al databse SQlite per memorizzare e leggere le informazioni.
	-	Se non esiste all'avvio, verrà creato un database con delle abitudini random per i test.

- L'interfaccia utente, basata su console, è semplice e intuitiva
- <img src="Interfaccia_utente.png" alt="Descrizione" width="500" height="300">

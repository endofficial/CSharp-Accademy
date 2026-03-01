namespace TCSA.OOP.LibraryManagementSystem;

//Un enum consente di definire un tipo che può accettare solo uno dei valori predefiniti.
//Questo limita i possibili valori che una variabile può contenere, riducendo gli errori.
//Sono particolarmente adatti per situazioni in cui si hanno solo poche opzioni.

// Questo enum rappresenta le opzioni del menu principale della nostra applicazione.
internal class Enums
{
    internal enum MenuAction
    {
        ViewItem,
        AddItem,
        DeleteItem
    }

    // Questo enum rappresenta i diversi tipi di elementi che possono essere presenti nella biblioteca.
    internal enum ItemType
    {
        Book,
        Magazine,
        Newspaper
    }
}

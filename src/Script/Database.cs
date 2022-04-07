using System.Collections.Generic;
using System;

//TODO creare un metodo per chiedere gli interi e sostituire tutte le richieste per interi fatte fino ad ora, in tutti i file

public class Database {
    public Database (){}

    private static void creaDatabase (){
        //patologie
        aggiungiPatologia (new Patologia (0, "Diabete", "Malattia cronica, inquadrabile nel gruppo delle patologie note come diabete mellito, caratterizzata da un'elevata concentrazione di glucosio nel sangue, che viene a sua volta causata da una carenza (assoluta o relativa) di insulina nell'organismo umano, o da un'alterata funzionalità dell'insulina stessa, ormone che stimolando l'assunzione del glucosio nelle cellule muscolari e adipose ne diminuisce la concentrazione nel sangue."));
        aggiungiPatologia (new Patologia (1, "Reflusso gastroesofageo", "La malattia da reflusso gastroesofageo è una malattia di interesse gastroenterologico, causata da complicanze patologiche del reflusso gastroesofageo: si parla di malattia quando il reflusso causa sintomi o quando, con la gastroscopia, si evidenziano lesioni infiammatorie a carico dell'esofago, o ulcere, o trasformazione metaplastica della mucosa."));
        aggiungiPatologia (new Patologia (2, "Allergia al nichel", "L'allergia alimentare è una reazione avversa che si sviluppa per una risposta immunitaria specifica e riproducibile all’ingestione di un determinato alimento"));
        aggiungiPatologia (new Patologia (3, "Malattia di Crohn", "La malattia di Crohn o morbo di Crohn, nota anche come enterite regionale, è una malattia infiammatoria cronica dell'intestino che può colpire qualsiasi parte del tratto gastrointestinale, provocando una vasta gamma di sintomi."));

        //clienti
        List <int> patologieCliente = new List <int> ();
        aggiungiCliente (new Cliente ("alessandro", 0, patologieCliente));
        patologieCliente.Add (0);
        aggiungiCliente (new Cliente ("giorgio", 1, patologieCliente));
        patologieCliente.Add (1);
        aggiungiCliente (new Cliente ("marco", 1, patologieCliente));
        patologieCliente.Add (2);
        patologieCliente.Add (3);
        aggiungiCliente (new Cliente ("saverio", 2, patologieCliente));
        
        //diete
        aggiungiDieta (new Dieta ("Vegana", "La dieta vegana è un regime alimentare che prevede l'esclusione di tutti i cibi di origine animale e, di conseguenza, l'assunzione esclusiva di alimenti vegetali"));
        aggiungiDieta (new Dieta ("Vegetariana", "La dieta vegetariana è un regime alimentare che prevede l'assunzione di cibi di origine animale, tranne per quanto riguarda la loro carne (quindi latte, uova, ...), oltre ai cibi di origine vegetale"));
        aggiungiDieta (new Dieta ("Onnivora", "La dieta onnivora è un regime alimentare che non esclude l'assunzione di nessun tipo di alimento"));
        
        //ingredienti
        List <int> listaIdPatologieCompatibili = new List <int> ();
        listaIdPatologieCompatibili.Add (0);
        listaIdPatologieCompatibili.Add (1);
        listaIdPatologieCompatibili.Add (2);
        listaIdPatologieCompatibili.Add (3);
        //id, nome, descrizione, 
        //costo, costoEco, nutriScore, dieta, listaIdPatologieCompatibili
        
        //TODO modificare i valori costo, costoEco, nutriScore, dieta e listaIdPatologieCompatibili
        aggiungiIngrediente (new Ingrediente (0, "Spaghetti", "Gli spaghetti sono un particolare formato di pasta prodotta esclusivamente con semole di grano duro e acqua, dalla forma lunga e sottile e di sezione tonda.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (1, "Aglio", "L'aglio (Allium sativum L.) è una pianta bulbosa della famiglia Amaryllidaceae (sottofamiglia Allioideae).",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (2, "Olio extravergine d'oliva", "L'olio di oliva è un olio alimentare estratto dalle olive, ovvero i frutti dell'olivo (Olea europaea). Il tipo vergine si ricava dalla spremitura meccanica delle olive.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (3, "Basilico", "Il basilico (Ocimum basilicum, L., 1753) è una pianta erbacea annuale, appartenente alla famiglia delle Lamiaceae, normalmente coltivata come pianta aromatica.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (4, "Sugo di pomodoro", "La salsa di pomodoro, o sugo di pomodoro, è un sugo ottenuto dalla cottura della polpa dei pomodori nell'olio di oliva e utilizzato nella cucina italiana come condimento per la pasta.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (5, "Peperoncino secco", "Il peperoncino è il nome comune dato alla bacca ottenuta da alcune varietà piccanti del genere di piante Capsicum utilizzata principalmente come condimento.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (6, "Acqua", "L'acqua è un ingrediente fondamentale in cucina. Il suo sapore determina il gusto di bevande come tè e caffè. La qualità dell'acqua utilizzata per cucinare condiziona anche la riuscita del processo di lievitazione così come la stessa ebollizione.",
         1, 1, 1, 0, listaIdPatologieCompatibili));

        aggiungiIngrediente (new Ingrediente (7, "Pane", "Il pane è un prodotto alimentare ottenuto dalla fermentazione, dalla formatura a cui segue una lievitazione, e successiva cottura in forno di un impasto a base di farina (normale o integrale), cereali e acqua, confezionato con diverse modalità, arricchito e caratterizzato frequentemente da ingredienti che si differenziano seguendo le tradizioni locali.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (8, "Carne di pollo", "La carne di pollo è la carne ricavata dalla macellazione del pollo.",
         1, 1, 1, 2, listaIdPatologieCompatibili));

        aggiungiIngrediente (new Ingrediente (9, "Philadelphia", "Philadelphia è il nome commerciale di un formaggio spalmabile di tipo quark prodotto dalla Kraft Foods negli Stati Uniti d'America e venduto in molti stati. In Italia è commercializzato dal 1971.",
         1, 1, 1, 1, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (10, "Mango", "Mango è il nome comune di un frutto tropicale e della pianta indiana che lo produce (Genere Mangifera); la specie più diffusa è senz'altro la M. indica, anche nota come mango comune o mango indiano.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        aggiungiIngrediente (new Ingrediente (11, "Spinaci", "Lo spinacio è una pianta erbacea della famiglia delle Amaranthaceae, sottofamiglia delle Chenopodioideae.",
         1, 1, 1, 0, listaIdPatologieCompatibili));
        
        
        //patologie gia aggiunte per cliente
        

        //piatti
        //ricetta vegana
        List <OggettoQuantita<int>> ingredientiQuantita = new List <OggettoQuantita<int>> ();
        ingredientiQuantita.Add (new OggettoQuantita<int> (0,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (1,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (2,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (3,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (4,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (5,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (6,1));
        aggiungiPiatto (new Piatto ("Spaghetti all'assassina", "State tranquilli, gli spaghetti all'assassina non si ispirano ai classici del cinema horror! Si tratta di un primo piatto che è entrato di recente a far parte della tradizione barese, oltre che un modo appetitoso per utilizzare il sugo avanzato. Il significato del suo nome non è ben chiaro, ma quel che è certo è che il suo gusto ha conquistato tutti: grazie alla cottura degli spaghetti direttamente in padella, infatti, otterrete una consistenza croccante e saporita particolarmente apprezzata dagli amanti della crosticina!", ingredientiQuantita));
        
        ingredientiQuantita = new List <OggettoQuantita<int>> ();
        ingredientiQuantita.Add (new OggettoQuantita<int> (7,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (8,1));
        aggiungiPiatto (new Piatto ("Panino con il pollo", "Panino tagliato a meta con carne di pollo al centro dei due bun", ingredientiQuantita));

        //ricetta onnivora
        ingredientiQuantita = new List <OggettoQuantita<int>> ();
        ingredientiQuantita.Add (new OggettoQuantita<int> (7,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (9,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (10,1));
        ingredientiQuantita.Add (new OggettoQuantita<int> (11,1));
        aggiungiPiatto (new Piatto ("Pane, mango, spinaci e philadelphia", "Ricetta dal sito ufficiale di philadelphia italia rielaborata", ingredientiQuantita));
        
        
        //player
        aggiungiPlayer (new Player ("Gianni", 4, ingredientiQuantita));

        //ristorante
        aggiungiRistorante (new Ristorante ("Da Gianni", 0, ingredientiQuantita));

        pulisciDatabase ();
    } 

    public static void aggiungiRistorante (Ristorante ristorante){
        while (ristorante.nome.Equals("")){
            ristorante.nome = getNewStringaFromUtente ("Inserisci il nome del ristorante");
        }

        while (ristorante.punteggio < 0){
            ristorante.punteggio = Ristorante.getNewPunteggioFromUtente ();
        }

        while (ristorante.magazzinoIngredienti.Count == 0){
            ristorante.magazzinoIngredienti = Ristorante.fillMagazzinoIngredienti ();
        }

        salvaNuovoOggettoSuFile (ristorante);
    }

    public static void aggiungiPlayer (Player player){
        while (player.nome.Equals("")){
            player.nome = getNewStringaFromUtente ("Inserisci il nome del player");
        }

        while (player.soldi == -1){
            try{
                Console.WriteLine ("Inserisci i soldi del player " + player.nome);
                int soldi = Int32.Parse (Console.ReadLine ());
                if (soldi >= 0){
                    player.soldi = soldi;
                }
            }
            catch (Exception e){
                Console.WriteLine ("Non hai inserito un numero valido");
            }
        }
        
        while (player.inventario.Count == 0){
            player.inventario = Player.popolaInventario ();
        }

        salvaNuovoOggettoSuFile (player);
    }

    public static void aggiungiPiatto (Piatto piatto){
        while (piatto.nome.Equals("")){
            piatto.nome = getNewStringaFromUtente ("Inserisci il nome del piatto");
        }
        
        Piatto piattoGiaPresente = Piatto.checkPiattoOnonimoGiaPresente (piatto.nome);
        if (piattoGiaPresente == null){
            while (piatto.descrizione.Equals("")){
                piatto.descrizione = getNewStringaFromUtente ("Inserisci la descrizione del piatto");
            }

            while (piatto.listaIdIngredientiQuantita.Count == 0){
                piatto.listaIdIngredientiQuantita = Piatto.getListaIdIngredientiQuantitaPiattoFromUtente (piatto.nome);
            }

            piatto.calcolaCosto ();
            piatto.calcolaCostoEco ();
            piatto.calcolaNutriScore ();

            salvaNuovoOggettoSuFile (piatto);    
        }
        
    }

    public static void aggiungiPatologia (Patologia patologia){
        patologia.idPatologia = Patologia.getNewIdDatabasePatologia(patologia);

        while (patologia.nome.Equals("")){
            patologia.nome = getNewStringaFromUtente ("Inserisci il nome della patologia");
        }
        
        while (patologia.descrizione.Equals("")){
            patologia.descrizione = getNewStringaFromUtente ("Inserisci la descrizione della patologia");
        }

        salvaNuovoOggettoSuFile (patologia);
    }

    public static void aggiungiIngrediente (Ingrediente ingrediente){
        while (ingrediente.nome.Equals("")){
            ingrediente.nome = getNewStringaFromUtente ("Inserisci il nome dell'ingrediente");
        }

        Ingrediente ingredienteGiaPresente = Ingrediente.checkIngredienteOnonimoGiaPresente (ingrediente.nome);
        if (ingredienteGiaPresente == null){
            ingrediente.idItem = Item.getNewIdDatabaseItem (ingrediente);
            
            while (ingrediente.descrizione.Equals("")){
                ingrediente.descrizione = getNewStringaFromUtente ("Inserisci la descrizione dell'ingrediente " + ingrediente.nome);
            }

            while (ingrediente.costo <= 0.0){
                ingrediente.costo = ingrediente.getNewNumeroIngredienteFromUtente ("Inserisci il costo dell'ingrediente " + ingrediente.nome, "Non hai inserito un numero valido, inserisci un numero a cifra decimale (con .)");
            }

            while (ingrediente.costoEco <= 0.0){
                ingrediente.costoEco = (int) ingrediente.getNewNumeroIngredienteFromUtente ("Inserisci il costo eco dell'ingrediente " + ingrediente.nome, "Non hai inserito un numero valido, inserisci un numero intero");
            }

            while (ingrediente.nutriScore <= 0.0){
                ingrediente.nutriScore = (int) ingrediente.getNewNumeroIngredienteFromUtente ("Inserisci il nutriscore dell'ingrediente " + ingrediente.nome, "Non hai inserito un numero valido, inserisci un numero intero");
            }

            while ((ingrediente.dieta < 0) || (ingrediente.dieta > 2)){
                ingrediente.dieta = Dieta.getNewDietaFromUtente ("Inserisci la dieta minima con la quale è compatibile l'ingrediente " + ingrediente.nome);
            }

            if (ingrediente.listaIdPatologieCompatibili.Count == 0){
                ingrediente.listaIdPatologieCompatibili = Patologia.getNewListaIdPatologieFromUtente ("Inserisci le patologie compatibili con l'ingrediente " + ingrediente.nome + " e la keyword 'fine' quando hai finito l'inserimento");
            }

            salvaNuovoOggettoSuFile (ingrediente);
        }
    }

    public static void aggiungiDieta (Dieta dieta){
        while (dieta.nome.Equals("")){
            dieta.nome = getNewStringaFromUtente ("Inserisci il nome della dieta");
        }
        
        while (dieta.descrizione.Equals("")){
            dieta.descrizione = getNewStringaFromUtente ("Inserisci la descrizione della dieta " + dieta.nome);
        }

        salvaNuovoOggettoSuFile (dieta);
    }

    public static void aggiungiCliente (Cliente cliente){
        while (cliente.nome.Equals("")){
            cliente.nome = cliente.getNewNomeClienteFromUtente ("Inserisci il nome del cliente");
        }
        
        while ((cliente.dieta != 0) && (cliente.dieta != 1) && (cliente.dieta != 2)){
            cliente.dieta = Dieta.getNewDietaFromUtente ("Inserisci il nome della dieta del cliente " + cliente.nome);
        }
        
        if (cliente.listaIdPatologie.Count == 0){
            cliente.listaIdPatologie = Patologia.getNewListaIdPatologieFromUtente ("Inserisci le patologie del cliente " + cliente.nome + " e la keyword 'fine' quando hai finito l'inserimento");
        }

        salvaNuovoOggettoSuFile (cliente);
    }

    private static void pulisciDatabase (){
        List <Ingrediente> temp = getDatabaseOggetto (new Ingrediente ());
        if (temp.Count > 0)
            if (temp[0].idItem == -1){
                temp.RemoveAt(0);
                Serializza.salvaOggettiSuFile (temp);
            }

        List <Patologia> temp1 = getDatabaseOggetto (new Patologia ());
        if (temp1.Count > 0)
            if (temp1[0].idPatologia == -1){
                temp1.RemoveAt(0);
                Serializza.salvaOggettiSuFile (temp1);
            }
    }

    public static bool oggettoGiaPresente <Oggetto> (Oggetto oggetto){
        List <Oggetto> databaseOggetto = getDatabaseOggetto (oggetto);
        if (databaseOggetto.Count > 0){
            foreach (Oggetto singoloOggetto in databaseOggetto){
                if (singoloOggetto.Equals (oggetto)){
                    return true;
                }
            }
        }
        return false;
    }

    public static void salvaNuovoOggettoSuFile <Oggetto> (Oggetto oggetto){   
        if (!(oggettoGiaPresente (oggetto))){
            List <Oggetto> oggettiVecchi = getDatabaseOggetto (oggetto);
            if (!(oggettiVecchi.Contains (oggetto))){
                oggettiVecchi.Add (oggetto);
            }
            Serializza.salvaOggettiSuFile (oggettiVecchi);
        }
    }

    public static string getNewStringaFromUtente (string output){
        Console.WriteLine (output);
        return Console.ReadLine();
    }

    public static Oggetto getUltimoOggettoAggiuntoAlDatabase <Oggetto> (Oggetto oggetto){
        List <Oggetto> databaseOggetto = getDatabaseOggetto (oggetto);
        return databaseOggetto [databaseOggetto.Count - 1];
    }

    public static List <Oggetto> getDatabaseOggetto <Oggetto> (Oggetto oggetto){
        string pathJson = Serializza.getJsonPath (oggetto);
        return Serializza.leggiOggettiDaFile <Oggetto> (pathJson);
    }

    private static void creaDatabaseVuoto (){
        creaDatabaseVuotoCliente ();
        creaDatabaseVuotoDieta ();
        creaDatabaseVuotoIngrediente ();
        creaDatabaseVuotoItem ();
        creaDatabaseVuotoPatologia ();
        creaDatabaseVuotoPiatto ();
        creaDatabaseVuotoPlayer ();
        creaDatabaseVuotoRistorante ();
    }

    private static void creaDatabaseVuotoCliente (){
        //Cliente
        List <Cliente> tempCliente = new List<Cliente> ();
        //tempCliente.Add(new Cliente ());
    
        Serializza.salvaOggettiSuFile <Cliente> (tempCliente);
    }

    private static void creaDatabaseVuotoDieta (){
        //Dieta
        List <Dieta> tempDieta = new List<Dieta> ();
        //tempDieta.Add(new Dieta ());

        Serializza.salvaOggettiSuFile <Dieta> (tempDieta);
    }

    private static void creaDatabaseVuotoIngrediente (){
        //Ingrediente
        List <Ingrediente> tempIngrediente = new List<Ingrediente> ();
        tempIngrediente.Add(new Ingrediente ());

        Serializza.salvaOggettiSuFile <Ingrediente> (tempIngrediente);
    }

    private static void creaDatabaseVuotoItem (){
        //Item
        List <Item> tempItem = new List<Item> ();
        tempItem.Add(new Item ());

        Serializza.salvaOggettiSuFile <Item> (tempItem);
    }

    private static void creaDatabaseVuotoPatologia (){
        //Patologia
        List <Patologia> tempPatologia = new List<Patologia> ();
        tempPatologia.Add(new Patologia ());

        Serializza.salvaOggettiSuFile <Patologia> (tempPatologia);
    }

    private static void creaDatabaseVuotoPiatto (){
        //Piatto
        List <Piatto> tempPiatto = new List<Piatto> ();
        //tempPiatto.Add(new Piatto ());

        Serializza.salvaOggettiSuFile <Piatto> (tempPiatto);
    }

    private static void creaDatabaseVuotoPlayer (){
        //Player
        List <Player> tempPlayer = new List<Player> ();
        //tempPlayer.Add(new Player ());

        Serializza.salvaOggettiSuFile <Player> (tempPlayer);
    }

    private static void creaDatabaseVuotoRistorante (){
    //Ristorante
        List <Ristorante> tempRistorante = new List<Ristorante> ();
        //tempRistorante.Add(new Ristorante ());
        
        Serializza.salvaOggettiSuFile <Ristorante> (tempRistorante);
    }
}
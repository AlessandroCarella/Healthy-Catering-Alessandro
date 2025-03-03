using System;
using System.Collections.Generic;

public class Piatto
{
    public string nome = "";
    public string descrizione = "";

    private float costo = 0;
    private float costoEco = 0;
    private int nutriScore = 0; //media fra i nutriScore degli ingredienti ma approssimata per difetto all'intero più vicino

    //                          int al posto di ingredienti perché sono gli id degli ingredienti
    public List<OggettoQuantita<int>> listaIdIngredientiQuantita = null;

    private int percentualeGuadagnoSulPiatto = 10;

    public Piatto(string nome, string descrizione, List<OggettoQuantita<int>> listaIdIngredientiQuantita)
    {
        this.nome = nome;
        this.descrizione = descrizione;
        this.listaIdIngredientiQuantita = listaIdIngredientiQuantita;
        
        List<Ingrediente> databaseIngredienti = Costanti.databaseIngredienti;
        this.costo = calcolaCostoBase(databaseIngredienti);
        this.costoEco = calcolaCostoEco(databaseIngredienti);
        this.nutriScore = calcolaNutriScore(databaseIngredienti);
    }

    public Piatto()
    {
        this.nome = "";
        this.descrizione = "";
        this.costo = -1;
        this.costoEco = -1;
        this.nutriScore = -1;
        this.listaIdIngredientiQuantita = new List<OggettoQuantita<int>>();
    }

    public Piatto(string nomePiatto) : base()
    {
        this.nome = nomePiatto;
    }

    public override bool Equals(object obj)
    {
        // If the passed object is null
        if (obj == null)
        {
            return false;
        }
        if (!(obj is Piatto))
        {
            return false;
        }
        return (this.nome.Equals(((Piatto)obj).nome))
            && (this.descrizione.Equals(((Piatto)obj).descrizione))
            && (this.costo == ((Piatto)obj).costo)
            && (this.costoEco == ((Piatto)obj).costoEco)
            && (this.nutriScore == ((Piatto)obj).nutriScore)
            && OggettoQuantita<int>.listeIdQuantitaUguali(this.listaIdIngredientiQuantita, ((Piatto)obj).listaIdIngredientiQuantita);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        string output = this.descrizione + "\n\n" +
        "Costo: " + this.calcolaCostoBase() + "\n" +
        "Costo eco: " + this.calcolaCostoEco() + "\n" +
        "Nutriscore: " + this.calcolaNutriScore() + "\n";
        /*
        if (listaIdIngredientiQuantita.Count > 0)
        { 
            output = output + this.getListaIngredientiQuantitaToString();
        }*/

        return output;/* = output + "Fine piatto " + this.nome;*/
    }

    public string getListaIngredientiQuantitaToString()
    {
        string ingredientiQuantitaString = "";
        //se non lo prendo prima viene ricreato ogni volta che viene chiamato il metodo idToIngrediente
        List<Ingrediente> databaseIngredienti = Costanti.databaseIngredienti;

        foreach (OggettoQuantita<int> ingredienteQuantita in listaIdIngredientiQuantita)
        {
            Ingrediente temp = Ingrediente.idToIngrediente(ingredienteQuantita.oggetto, databaseIngredienti);
            if (temp.idIngrediente != -1)
                ingredientiQuantitaString = ingredientiQuantitaString + temp.nome + " x" + ingredienteQuantita.quantita.ToString() + "\n";
        }

        return ingredientiQuantitaString;
    }

    ~Piatto()
    {

    }

    public float calcolaCostoBase(List <Ingrediente> databaseIngredienti = null)
    {
        databaseIngredienti ??= Costanti.databaseIngredienti;

        float costo = 0;
        foreach (OggettoQuantita<int> ingredienteQuantita in this.listaIdIngredientiQuantita)
            costo = costo + (Ingrediente.idToIngrediente(ingredienteQuantita.oggetto, databaseIngredienti).costo * ingredienteQuantita.quantita);

        return costo + ((costo * percentualeGuadagnoSulPiatto) / 100);
    }

    public float calcolaCostoConBonus (bool affine, float costoBase){
        if (affine){
            float output;
            int posizioneNellaListaMigliori;

            output = costoBase;
            output += Utility.calcolaCostoPercentuale(costoBase, 7);
            
            posizioneNellaListaMigliori = this.getListaAffinitaOrdinata ().IndexOf(this);
            if (posizioneNellaListaMigliori == 0 ||posizioneNellaListaMigliori == 1 || posizioneNellaListaMigliori == 2){
                output += Utility.calcolaCostoPercentuale(costoBase, posizioneNellaListaMigliori + 1);
            }
            return output;
        }

        return costoBase - Utility.calcolaCostoPercentuale(costoBase, 5);
    }

    private List <Piatto> getListaAffinitaOrdinata(List <Piatto> databasePiatti = null){
        databasePiatti ??= Database.getDatabaseOggetto (this);
        
        databasePiatti.Sort (new PiattiComparer());
        return databasePiatti;
    }

    private class PiattiComparer : IComparer<Piatto>
    {
        //Compare returns -1 (less than), 0 (equal), or 1 (greater)
        //nutriScore costoEco costo
        public int Compare(Piatto first, Piatto second)
        {
            if (first.nutriScore > second.nutriScore){
                if (first.costoEco < second.costoEco){   
                    return 1;
                }
            }    
            else if ((first.nutriScore == second.nutriScore) && (first.costoEco == second.costoEco)){
                if (first.costo == second.costo){
                    return 0;
                }    
                else if (first.costo < second.costo){
                    return 1;
                }
                else{
                    return -1;
                }
            }
            
            return -1;
        }
    }

    public float calcolaCostoEco(List <Ingrediente> databaseIngredienti = null)
    {
        databaseIngredienti ??= Costanti.databaseIngredienti;
        
        float costoEco = 0;
        foreach (OggettoQuantita<int> ingredienteQuantita in this.listaIdIngredientiQuantita)
            costoEco = costoEco + (Ingrediente.idToIngrediente(ingredienteQuantita.oggetto, databaseIngredienti).costoEco * ingredienteQuantita.quantita);

        return costoEco;
    }

    public int calcolaNutriScore(List <Ingrediente> databaseIngredienti = null)
    {
        databaseIngredienti ??= Costanti.databaseIngredienti;
        
        int sommanutriScore = 0;
        int numeroIngredienti = 0;

        foreach (OggettoQuantita<int> ingredienteQuantita in this.listaIdIngredientiQuantita)
        {
            sommanutriScore = sommanutriScore + (Ingrediente.idToIngrediente(ingredienteQuantita.oggetto, databaseIngredienti).nutriScore * ingredienteQuantita.quantita);
            numeroIngredienti = numeroIngredienti + ingredienteQuantita.quantita;
        }

        return (int)(sommanutriScore / numeroIngredienti);
    }

    private List<int> getPatologieCompatibili(List<Ingrediente> databaseIngredienti = null)
    {
        databaseIngredienti ??= Costanti.databaseIngredienti;

        List<Ingrediente> ingredientiPiatto = this.getIngredientiPiatto(databaseIngredienti);
        List<int> IdtutteLePatologie = Patologia.getListIdTutteLePatologie();

        foreach (Ingrediente ingrediente in ingredientiPiatto)
            foreach (int id in IdtutteLePatologie)
                if (!(ingrediente.listaIdPatologieCompatibili.Contains(id)))
                    IdtutteLePatologie.Remove(id);

        return IdtutteLePatologie;
    }

    private int getDietaMinimaCompatibile(List<Ingrediente> databaseIngredienti = null)
    {
        databaseIngredienti ??= Costanti.databaseIngredienti;

        List<Ingrediente> ingredientiPiatto = this.getIngredientiPiatto(databaseIngredienti);
        int output = -1;

        foreach (Ingrediente ingrediente in ingredientiPiatto)
            if (output < ingrediente.dieta)
                output = ingrediente.dieta;

        return output;
    }

    public List<Ingrediente> getIngredientiPiatto(List<Ingrediente> databaseIngredienti = null)
    {
        databaseIngredienti ??= Costanti.databaseIngredienti;

        List<Ingrediente> ingredientiPiatto = new List<Ingrediente>();

        int i = 0;
        foreach (OggettoQuantita<int> ingredienteQuantita in this.listaIdIngredientiQuantita)
        {
            foreach (Ingrediente ingrediente in databaseIngredienti)
                if (ingredienteQuantita.oggetto == ingrediente.idIngrediente)
                    ingredientiPiatto.Add(ingrediente);
            i++;
        }

        return ingredientiPiatto;
    }

    public bool checkAffinitaConCliente (Cliente cliente)
    {
        bool patologieCompatibili = checkAffinitaPatologiePiatto(this.listaIdIngredientiQuantita, cliente.listaIdPatologie);
        bool dietaCompatibile = checkAffinitaDietaPiatto(this.listaIdIngredientiQuantita, cliente.dieta);

        return (patologieCompatibili && dietaCompatibile);
    }

    public bool checkAffinitaPatologiePiatto(List <OggettoQuantita <int>> listaIdIngredientiQuantita, List <int> listaIdPatologieCliente)
    {
        foreach (int idPatologiaCliente in listaIdPatologieCliente)
        {
            foreach (OggettoQuantita<int> idIngredienteEQuantita in listaIdIngredientiQuantita) 
            {
                Ingrediente ingrediente = Ingrediente.idToIngrediente(idIngredienteEQuantita.oggetto);
                if (!ingrediente.listaIdPatologieCompatibili.Contains (idPatologiaCliente)){
                    return false;
                }
            }
        }
        return true;
    }

    public bool checkAffinitaDietaPiatto(List <OggettoQuantita<int>> listaIdIngredientiQuantita, int dietaCliente)
    {
        foreach (OggettoQuantita<int> idIngredienteEQuantita in listaIdIngredientiQuantita)
        {
            Ingrediente ingrediente = Ingrediente.idToIngrediente(idIngredienteEQuantita.oggetto);

            if (ingrediente.dieta > dietaCliente)
                return false;
        }
        return true;
    }

    public static Piatto getPiattoFromNomeBottone(string nomePiattoBottone, List <Piatto> databasePiatti = null)
    {
        databasePiatti ??= Costanti.databasePiatti;

        Piatto piattoSelezionato = new Piatto();
        foreach (Piatto piatto in databasePiatti)
        {
            if (nomePiattoBottone.Contains(piatto.nome))//contains perché viene aggiunta la stringa ingredienti nel nome del bottone
            {
                piattoSelezionato = piatto;
                break;
            }
        }
        return piattoSelezionato;
    }

    public bool piattoInInventario(List <OggettoQuantita<int>> inventario)
    {
        bool ingredienteTrovato = false;
        foreach (OggettoQuantita<int> ingredientePiatto in listaIdIngredientiQuantita)
        {
            ingredienteTrovato = false;
            foreach (OggettoQuantita<int> ingredienteInventario in inventario)
            {
                if (ingredientePiatto.oggetto == ingredienteInventario.oggetto)
                {
                    ingredienteTrovato = true;
                    if (ingredientePiatto.quantita > ingredienteInventario.quantita)
                    {
                        return false;
                    }
                }
            }
            if (!ingredienteTrovato)
            {
                return false;
            }
            ingredienteTrovato = false;
        }

        return true;
    }

    //FUNZIONI PER DATABASE
    public static Piatto checkPiattoOnonimoGiaPresente(string nomePiatto, List<Piatto> piattiConNomeSimileInDatabase = null)
    {
        piattiConNomeSimileInDatabase ??= getPiattiConNomeSimileInDatabase(nomePiatto);

        if (piattiConNomeSimileInDatabase.Count > 0)
        {
            int scelta = Database.getNewIntFromUtente(getStringaStampaPiattiConNomeSimilePerSceltaUtente(nomePiatto, piattiConNomeSimileInDatabase));
            if (scelta != -1)
                return piattiConNomeSimileInDatabase[scelta - 1];
        }

        return null;
    }
    
    private static List<Piatto> getPiattiConNomeSimileInDatabase(string nomePiatto, List<Piatto> databasePiatti = null)
    {
        databasePiatti ??= Costanti.databasePiatti;

        List<Piatto> output = new List<Piatto>();
        string nomePiattoPerConfronto = nomePiatto.ToLower();

        foreach (Piatto piattoTemp in databasePiatti)
            if ((piattoTemp.nome.ToLower().Contains(nomePiattoPerConfronto)) || (nomePiattoPerConfronto.Contains(piattoTemp.nome.ToLower())))
                output.Add(piattoTemp);

        return output;
    }

    private static string getStringaStampaPiattiConNomeSimilePerSceltaUtente(string nomePiatto, List<Piatto> piattiConNomeSimileInDatabase)
    {
        string output = "Il nome del piatto che hai inserito (" + nomePiatto + ") non è stato trovato ma sono stati trovati piatti con nomi simili, intendi uno di questi? Inserisci 'no' per uscire da questo menu\n";

        int i = 1;
        foreach (Piatto piatto in piattiConNomeSimileInDatabase)
            output = i.ToString() + ") " + piatto.nome + "\n";

        return output;
    }

    private static List<string> getNomeIngredientiFromUtente(string nomePiatto)
    {
        Console.WriteLine("Inserisci il nome degli ingredienti del piatto " + nomePiatto + " e la keyword 'fine' quando vuoi finire l'inserimento");

        List<string> nomiIngredienti = new List<string>();
        string input = "";

        while (true)
        {
            input = Console.ReadLine();
            if (input.Equals("fine"))
                break;
            nomiIngredienti.Add(input);
        }

        return nomiIngredienti;
    }


    private static int getQuantitaIngredienteNelPiattoFromUtente(string nomeIngrediente, string nomePiatto)
    {
        while (true)
        {
            int numero = Database.getNewIntFromUtente("Qual'è la quantita di " + nomeIngrediente + " nel piatto " + nomePiatto);

            if (numero > 0)
                return numero;
        }
    }

    public static Piatto nomeToPiatto (string nome)
    {
        foreach (Piatto temp in Costanti.databasePiatti)
        {
            if (nome.Contains (temp.nome))
                return temp;
        }

        return new Piatto();
    }

}
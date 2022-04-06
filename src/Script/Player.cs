using System.Reflection.Emit;
public class Player
{
    public string nome = "";
    
    public float soldi = 0;

    public List <OggettoQuantita<int>> inventario = new List<OggettoQuantita<int>> ();

    public Player(string nome, int soldi, List<OggettoQuantita<int>> inventario)
    {
        this.nome = nome;
        this.soldi = soldi;
        this.inventario = inventario;
    }

    public Player (){
        this.nome = "";
        this.soldi = -1;
        this.inventario = new List<OggettoQuantita<int>> (); //int perchè sono gli id degli item e non gli item veri e propri
    }

    public static List<OggettoQuantita<int>> popolaInventario (List <Item> itemGiaPresenti = null){
        itemGiaPresenti ??= new List<Item> ();

        itemGiaPresenti = aggiungiAltriItem (itemGiaPresenti);

        List <int> quantitaItemGiaPresenti = new List<int> ();

        quantitaItemGiaPresenti = chiediQuantitaItem (itemGiaPresenti);

        return creaInventarioFromListaItemEQuantita (itemGiaPresenti, quantitaItemGiaPresenti);
    }

    private static List <Item> aggiungiAltriItem (List <Item> itemGiaPresenti){
        while (true){
            Console.WriteLine("Inserisci la keyword 'inizia' o la keyword 'continua' per inserire un nuovo item e la parola 'fine' per concludere l'inserimento");
            string input = Console.ReadLine ();
            if (input.Equals ("fine")){
                break;
            }
            itemGiaPresenti.Add(Item.creaNuovoItem ());
        }
        
        return itemGiaPresenti;
    }

    private static List <int> chiediQuantitaItem (List <Item> itemGiaPresenti){
        List <int> quantita = new List<int> ();
        foreach (Item item in itemGiaPresenti){
            int numeroInput = -1;
            Console.WriteLine ("Quanti " + item.nome + " devono essere presenti nell'inventario?");
            while (true){
                string input = Console.ReadLine();
                try{
                    numeroInput = Int32.Parse (input);
                    if (numeroInput >= 0){
                        quantita.Add (numeroInput);
                        break;
                    } 
                }
                catch (Exception e){
                    Console.WriteLine ("Non hai inserito un numero");
                }
                Console.WriteLine ("Non hai inserito un numero valido"); 
            }
        }
        return quantita;
    }

    private static List<OggettoQuantita<int>> creaInventarioFromListaItemEQuantita(List <Item> itemGiaPresenti, List <int> quantitaItemGiaPresenti){
        if (itemGiaPresenti.Count == quantitaItemGiaPresenti.Count){
            List<OggettoQuantita<int>> output = new List<OggettoQuantita<int>> ();
            int i = 0;
            while (i < itemGiaPresenti.Count){
                output.Add (new OggettoQuantita <int> (itemGiaPresenti [i].idItem, quantitaItemGiaPresenti [i]));
                i++;
            }
            return output;
        }
        throw new Exception ("Le dimensioni della lista contente gli item e le quantita di essi non corrispondo");
    }

    ~Player()
    {
        
    }
    
}